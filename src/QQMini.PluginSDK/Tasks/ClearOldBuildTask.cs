using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using System.Diagnostics;
using System.IO;
using System.Linq;

namespace QQMini.PluginSDK.Tasks
{
	/// <summary>
	/// 清除旧编译任务
	/// </summary>
	public class ClearOldBuildTask : Task
	{
		#region --属性--
		/// <summary>
		/// 获取或设置程序集名称
		/// </summary>
		public string BuildAssemblyName { get; set; }
		/// <summary>
		/// 获取或设置编译输出路径
		/// </summary>
		public string BuildOutputPath { get; set; }

		#endregion

		#region --公开方法--
		/// <summary>
		/// 执行任务
		/// </summary>
		/// <returns></returns>
		public override bool Execute ()
		{
			Log.LogMessage (MessageImportance.High, "清理上次编译结果...");
			if (!Path.IsPathRooted (this.BuildOutputPath))
			{
				this.BuildOutputPath = Path.GetFullPath (this.BuildOutputPath);
			}

			if (CheckDirectoryOrThrow (this.BuildOutputPath))
			{
				string deletePath = Path.Combine (this.BuildOutputPath, this.BuildAssemblyName);
				DeleteFiles (deletePath, true);

				string deleteFile = Path.Combine (this.BuildOutputPath, $"{this.BuildAssemblyName}.MQ.dll");
				if (File.Exists (deleteFile))
				{
					File.Delete (deleteFile);
					Log.LogMessage (MessageImportance.High, $"删除文件: {deleteFile}");
				}

				Log.LogMessage (MessageImportance.High, "清理上次编译结果 -> 成功");
				return true;
			}

			return false;
		}
		#endregion

		#region --私有方法--
		private bool CheckDirectoryOrThrow (string path)
		{
			if (Path.IsPathRooted (path))
			{
				//判断文件夹是否还存在
				if (Directory.Exists (path))
				{
					if (Directory.GetFiles (path, "*.sln").Length > 0 ||
						Directory.GetFiles (path, "*.csproj").Length > 0 ||
						Directory.GetFiles (path, "*.fsproj").Length > 0 ||
						Directory.GetFiles (path, "*.vbproj").Length > 0)
					{
						Log.LogError ($"编译路径不能是解决方案或项目的根路径. 错误路径: {path}");
						return false;
					}
				}
			}

			return true;
		}
		private void DeleteFiles (string path, bool isDelPath)
		{
			if (Path.IsPathRooted (path))
			{
				//判断文件夹是否还存在
				if (Directory.Exists (path))
				{
					new DirectoryInfo (path)
					{
						Attributes = FileAttributes.Normal & FileAttributes.Directory
					};
					File.SetAttributes (path, FileAttributes.Normal);

					foreach (string item in Directory.GetFileSystemEntries (path))
					{
						if (File.Exists (item))
						{
							//如果有子文件删除文件
							File.Delete (item);
							Log.LogMessage (MessageImportance.High, $"删除文件: {item}");
						}
						else
						{
							//循环递归删除子文件夹
							DeleteFiles (item, false);
							Directory.Delete (item);
							Log.LogMessage (MessageImportance.High, $"删除目录: {item}");
						}
					}

					if (isDelPath)
					{
						Directory.Delete (path, isDelPath);
						Log.LogMessage (MessageImportance.High, $"删除根目录: {path}");
					}
				}
			}
		}
		#endregion
	}
}
