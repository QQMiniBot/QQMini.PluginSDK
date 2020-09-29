using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

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
		[JsonProperty (PropertyName = "PackageID")]
		public string PackageId { get; set; }
		/// <summary>
		/// 插件名称
		/// </summary>
		[JsonProperty (PropertyName = "Name")]
		public string Name { get; set; }
		/// <summary>
		/// 插件版本号
		/// </summary>
		[JsonProperty (PropertyName = "Version")]
		public Version Version { get; set; }
		/// <summary>
		/// 插件作者
		/// </summary>
		[JsonProperty (PropertyName = "Author")]
		public string Author { get; set; }
		/// <summary>
		/// 插件说明
		/// </summary>
		[JsonProperty (PropertyName = "Description")]
		public string Description { get; set; }
		/// <summary>
		/// SDK版本
		/// </summary>
		[JsonProperty (PropertyName = "SDKVersion")]
		public int SDKVersion { get; set; }
		/// <summary>
		/// 开发人员序列号
		/// </summary>
		[JsonProperty (PropertyName = "DeveloperKey")]
		public string DeveloperKey { get; set; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="PluginInfo"/> 类的新实例
		/// </summary>
		public PluginInfo ()
			: this ("com.jiegg.demo", "QQMini .NET 插件模板", new Version (1, 0, 0, 0), "JieGG", "QQMini机器人 .NET 开发框架模板 (V3应用机制)")
		{

		}
		/// <summary>
		/// 使用指定的信息初始化 <see cref="PluginInfo"/> 类的新实例
		/// </summary>
		/// <param name="packageId">应用程序的唯一标识</param>
		/// <param name="name">描述应用程序的名称</param>
		/// <param name="version">应用程序的版本号</param>
		/// <param name="author">应用程序的作者</param>
		/// <param name="description">应用程序的详细介绍</param>
		public PluginInfo (string packageId, string name, Version version, string author, string description)
			: this (packageId, name, version, author, description, 3, "ABCDEFG")
		{

		}
		/// <summary>
		/// 使用指定的信息初始化 <see cref="PluginInfo"/> 类的新实例
		/// </summary>
		/// <param name="packageId">应用程序的唯一标识</param>
		/// <param name="name">描述应用程序的名称</param>
		/// <param name="version">应用程序的版本号</param>
		/// <param name="author">应用程序的作者</param>
		/// <param name="description">应用程序的详细介绍</param>
		/// <param name="sDKVersion">应用程序开发包的版本</param>
		/// <param name="sKey">引用程序的序列号</param>
		public PluginInfo (string packageId, string name, Version version, string author, string description, int sDKVersion, string sKey)
		{
			PackageId = packageId ?? throw new ArgumentNullException (nameof (packageId));
			Name = name ?? throw new ArgumentNullException (nameof (name));
			Version = version ?? throw new ArgumentNullException (nameof (version));
			Author = author ?? throw new ArgumentNullException (nameof (author));
			Description = description ?? throw new ArgumentNullException (nameof (description));
			SDKVersion = sDKVersion;
			DeveloperKey = sKey ?? throw new ArgumentNullException (nameof (sKey));
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return JsonConvert.SerializeObject (this);
		}
		#endregion
	}
}
