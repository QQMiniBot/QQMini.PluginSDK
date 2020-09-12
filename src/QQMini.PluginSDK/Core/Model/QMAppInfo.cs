using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示程序集、QQMini扩展应用程序的基本信息. 此类不能被继承
	/// </summary>
	[Serializable]
	public sealed class QMAppInfo : MarshalByRefObject
	{
		#region --属性--
		/// <summary>
		/// 获取或设置当前实例描述应用程序的唯一标识
		/// </summary>
		public string AppId { get; set; }
		/// <summary>
		/// 获取或设置当前实例描述应用程序的应用程序名称
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 获取或设置当前实例描述应用程序的版本号
		/// </summary>
		public Version Version { get; set; }
		/// <summary>
		/// 获取或设置当前实例描述应用程序的作者
		/// </summary>
		public string Author { get; set; }
		/// <summary>
		/// 获取或设置当前实例描述应用程序的说明
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// 获取或设置当前实例描述的应用程序开发包的版本号
		/// </summary>
		public int SDKVersion { get; set; }
		/// <summary>
		/// 获取或设置时当前实例描述的应用程序序列号
		/// </summary>
		public string SKey { get; set; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMAppInfo"/> 类的新实例
		/// </summary>
		public QMAppInfo ()
		{ }
		/// <summary>
		/// 使用指定的信息初始化 <see cref="QMAppInfo"/> 类的新实例
		/// </summary>
		/// <param name="applicationId">应用程序的唯一标识</param>
		/// <param name="name">描述应用程序的名称</param>
		/// <param name="version">应用程序的版本号</param>
		/// <param name="author">应用程序的作者</param>
		/// <param name="description">应用程序的详细介绍</param>
		/// <param name="sDKVersion">应用程序开发包的版本</param>
		/// <param name="sKey">引用程序的序列号</param>
		public QMAppInfo (string applicationId, string name, Version version, string author, string description, int sDKVersion, string sKey)
		{
			AppId = applicationId ?? throw new ArgumentNullException (nameof (applicationId));
			Name = name ?? throw new ArgumentNullException (nameof (name));
			Version = version ?? throw new ArgumentNullException (nameof (version));
			Author = author ?? throw new ArgumentNullException (nameof (author));
			Description = description ?? throw new ArgumentNullException (nameof (description));
			SDKVersion = sDKVersion;
			SKey = sKey ?? throw new ArgumentNullException (nameof (sKey));
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return $"{{AppId: {this.AppId}, 名称: {this.Name}, 版本号: {this.Version}, 作者: {this.Author}, 说明: {this.Description}, SDK版本: {this.SDKVersion}, SKey: {this.SKey}}}";
		}
		#endregion
	}
}
