using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示程序集、QQMini 插件的基本信息. 此类不能被继承
	/// </summary>
	[Serializable]
	public sealed class PluginInfo : MarshalByRefObject
	{
		#region --属性--
		/// <summary>
		/// 插件包名
		/// </summary>
		public string PackageId { get; set; }
		/// <summary>
		/// 插件名称
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 插件版本号
		/// </summary>
		public Version Version { get; set; }
		/// <summary>
		/// 插件作者
		/// </summary>
		public string Author { get; set; }
		/// <summary>
		/// 插件说明
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// SDK版本, 默认: 3
		/// </summary>
		public int SDKVersion { get; set; } = 3;
		/// <summary>
		/// 开发人员序列号, 请勿随意改动此序列号
		/// </summary>
		public string DeveloperKey { get; set; } = "5A09222C13D7";
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="PluginInfo"/> 类的新实例
		/// </summary>
		public PluginInfo ()
		{ }
		#endregion

		#region --公开方法--
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			JObject root = new JObject ();
			root.Add ("PackageID", this.PackageId);
			root.Add ("Name", this.Name);
			root.Add ("Version", this.Version.ToString ());
			root.Add ("Author", this.Author);
			root.Add ("Description", this.Description);
			root.Add ("SDKVersion", this.SDKVersion);
			root.Add ("DeveloperKey", this.DeveloperKey);

			return root.ToString ();
		}
		#endregion
	}
}
