using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using System.IO;


namespace QQMini.PluginSDK.Tasks
{
	/// <summary>
	/// 清除旧编译任务
	/// </summary>
	public class ClearOldBuildTask : Task
	{
		#region --属性--
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

			DeleteFiles (this.BuildOutputPath, false);
			Log.LogMessage (MessageImportance.High, "清理上次编译结果 -> 成功");
			return true;
		}
		#endregion

		#region --私有方法--
		private void DeleteFiles (string path, bool isDelPath)
		{
			if (Path.IsPathRooted (path))
			{
				new DirectoryInfo (path)
				{
					Attributes = FileAttributes.Normal & FileAttributes.Directory
				};
				File.SetAttributes (path, FileAttributes.Normal);

				//判断文件夹是否还存在
				if (Directory.Exists (path))
				{
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
