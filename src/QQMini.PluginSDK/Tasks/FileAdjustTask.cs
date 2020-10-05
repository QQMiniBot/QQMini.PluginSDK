using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using QQMini.PluginSDK.Core;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace QQMini.PluginSDK.Tasks
{
	/// <summary>
	/// 文件调整任务
	/// </summary>
	public class FileAdjustTask : Task
	{
		#region --属性--
		/// <summary>
		/// 获取或设置程序集名称
		/// </summary>
		public string BuildAssemblyName { get; set; }
		/// <summary>
		/// 获取或设置编译过程中输出的程序集
		/// </summary>
		public string BuildOutputAssembly { get; set; }
		/// <summary>
		/// 获取或设置编译过程中的输出目录
		/// </summary>
		public string BuildOutputPath { get; set; }
		/// <summary>
		/// 获取或设置编译过程中的输出目标目录
		/// </summary>
		public string BuildOutTargetPath { get; set; }
		/// <summary>
		/// 获取或设置编译过程中不移动的文件列表
		/// </summary>
		public string[] NotMoveFiles { get; set; }
		/// <summary>
		/// 获取或设置编译过程中删除的文件列表
		/// </summary>
		public string[] DeleteFiles { get; set; }
		#endregion

		#region --公开方法--
		/// <summary>
		/// 执行任务
		/// </summary>
		/// <returns></returns>
		public override bool Execute ()
		{
			Log.LogMessage (MessageImportance.High, $"执行最后任务...");
			if (!Path.IsPathRooted (this.BuildOutputPath))
			{
				this.BuildOutputPath = Path.GetFullPath (this.BuildOutputPath);
			}
			if (!Path.IsPathRooted (this.BuildOutTargetPath))
			{
				this.BuildOutTargetPath = Path.GetFullPath (this.BuildOutTargetPath);
			}

			List<string> tempDelFils = new List<string> (this.DeleteFiles);
			for (int i = 0; i < tempDelFils.Count; i++)
			{
				foreach (string item in this.NotMoveFiles)
				{
					if (string.Compare (Path.GetFileName (tempDelFils[i]), Path.GetFileName (item), true) == 0)
					{
						tempDelFils.RemoveAt (i);
						i--;
					}
				}
			}

			Log.LogMessage (MessageImportance.High, $"整理编译依赖...");
			MoveFiles (this.BuildOutputPath, this.BuildOutTargetPath, this.NotMoveFiles, tempDelFils.ToArray ());
			Log.LogMessage (MessageImportance.High, $"整理编译依赖 -> 成功");

			// 将所有文件转移到 Assembly 目录
			Log.LogMessage (MessageImportance.High, $"整理编译目录...");
			string targetPath = Path.Combine (this.BuildOutputPath, this.BuildAssemblyName);
			MoveFiles (this.BuildOutputPath, targetPath, new string[0], new string[0]);
			Log.LogMessage (MessageImportance.High, $"整理编译目录 -> 成功");

			Log.LogMessage (MessageImportance.High, $"打包编译结果...");
			string zipName = $"{this.BuildAssemblyName}.MQ.dll";              // 原版压缩文件的名称
			string zipPath = Path.Combine (this.BuildOutputPath, zipName);      // 原版压缩文件的路径
			ZipFile.CreateFromDirectory (targetPath, zipPath, CompressionLevel.Fastest, false);

			Log.LogMessage (MessageImportance.High, $"打包编译结果 -> 成功");
			return true;
		}
		#endregion

		#region --私有方法--
		private void MoveFiles (string srcPath, string descPath, string[] notMoveFiles, string[] delFiles)
		{
			if (Path.IsPathRooted (srcPath) && Path.IsPathRooted (descPath))
			{
				if (!Directory.Exists (descPath))
				{
					Directory.CreateDirectory (descPath);
				}

				if (Directory.Exists (srcPath))
				{
					foreach (string item in Directory.GetFileSystemEntries (srcPath))
					{
						if (string.Compare (descPath, item, true) == 0)
						{
							continue;
						}
						if (File.Exists (item))
						{
							string fileName = Path.GetFileName (item);
							if (delFiles.Any (p => string.Compare (Path.GetFileName (p), fileName, true) == 0))
							{
								File.Delete (item);
								Log.LogMessage (MessageImportance.High, $"删除文件: {fileName}");
							}
							else if (!notMoveFiles.Any (p => string.Compare (Path.GetFileName (p), fileName, true) == 0))
							{
								File.Move (item, Path.Combine (descPath, fileName));
								Log.LogMessage (MessageImportance.High, $"移动文件: {fileName} -> {descPath}");
							}
							else
							{
								Log.LogMessage (MessageImportance.High, $"跳过文件: {fileName}");
							}
						}
						else
						{
							string dirName = Path.GetFileName (item);
							string descDir = Path.Combine (descPath, dirName);
							if (!Directory.Exists (descDir))
							{
								Directory.CreateDirectory (descDir);
							}

							MoveFiles (item, descDir, notMoveFiles, delFiles);
							Directory.Delete (item, true);
							Log.LogMessage (MessageImportance.High, $"移动目录: {dirName} -> {descDir}");
						}
					}
				}
			}
		}
		#endregion
	}
}
