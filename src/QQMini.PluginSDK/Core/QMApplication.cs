using System;

using QQMini.PluginSDK.Core.Model;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 提供一种符合 QQMini 扩展应用程序的运行机制
	/// </summary>
	[Serializable]
	public abstract class QMApplication : MarshalByRefObject
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
		public abstract QMAppInfo AppInfo { get; }
		#endregion

		#region --公开方法--
		/// <summary>
		/// 获取应用程序信息
		/// </summary>
		/// <returns>返回应用程序信息</returns>
		public string GetAppInfo ()
		{
			return AppInfo.ToString ();
		}
		/// <summary>
		/// 设置应用程序授权
		/// </summary>
		public void SetAppAuthorize (int authCode)
		{
			this._api = new QMApi (authCode);
		}

		/// <summary>
		/// 当在派生类中重写时, 初始化应用程序
		/// </summary>
		public abstract void OnInitialized ();
		/// <summary>
		/// 当在派生类中重写时, 卸载应用程序
		/// </summary>
		public abstract void OnUninitialized ();
		/// <summary>
		/// 当在派生类中重写时, 打开设置窗体
		/// </summary>
		public virtual void OnOpenSettingsWindow ()
		{ }
		#endregion
	}
}
