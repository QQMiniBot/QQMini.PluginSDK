using Newtonsoft.Json.Linq;

using System;
using System.Runtime.Remoting.Lifetime;

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
		/// 获取控制此实例的生存期策略的生存期服务对象
		/// </summary>
		/// <returns><see cref="ILease"/> 类型的对象，用于控制此实例的生存期策略。这是此实例当前的生存期服务对象（如果存在）；否则为初始化为 <see cref="LifetimeServices.LeaseManagerPollTime"/> 属性的值的新生存期服务对象</returns>
		public override object InitializeLifetimeService ()
		{
			return null;
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			JObject root = new JObject
			{
				{ "PackageID", this.PackageId },
				{ "Name", this.Name },
				{ "Version", this.Version.ToString () },
				{ "Author", this.Author },
				{ "Description", this.Description },
				{ "SDKVersion", this.SDKVersion },
				{ "DeveloperKey", this.DeveloperKey }
			};

			return root.ToString ();
		}
		#endregion
	}
}
