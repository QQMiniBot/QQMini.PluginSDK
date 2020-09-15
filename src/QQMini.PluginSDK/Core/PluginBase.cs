using System;

using QQMini.PluginSDK.Core.Model;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 提供一种符合 QQMini 扩展应用程序的运行机制
	/// </summary>
	[Serializable]
	public abstract class PluginBase : MarshalByRefObject, IPlugin
	{
		#region --字段--
		private QMApi _api;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前应用程序相关联的应用程序 Api
		/// </summary>
		public QMApi Api { get => this._api; }
		/// <summary>
		/// 当在派生类中重写时, 设置应用程序的信息
		/// </summary>
		public abstract PluginInfo AppInfo { get; }
		#endregion

		#region --公开方法--
		/// <summary>
		/// 获取插件的基本信息
		/// </summary>
		/// <returns>返回插件信息字符串</returns>
		public string GetInfomaction ()
		{
			return AppInfo.ToString ();
		}
		/// <summary>
		/// 设置插件的授权信息
		/// </summary>
		/// <param name="authCode">插件授权码</param>
		public void SetAuthorize (int authCode)
		{
			this._api = new QMApi (authCode);
		}
		/// <summary>
		/// 当在派生类中重写时, 对当前插件进行初始化
		/// </summary>
		public virtual void OnInitialize ()
		{ }
		/// <summary>
		/// 当在派生类中重写时, 对当前插件进行反初始化
		/// </summary>
		public virtual void OnUninitialize ()
		{ }
		/// <summary>
		/// 当在派生类中重写时, 打开当前插件的设置菜单
		/// </summary>
		public virtual void OnOpenSettingMenu ()
		{ }
		#endregion
	}
}
