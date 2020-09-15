using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QQMini.PluginSDK.Core.Core;
using QQMini.PluginSDK.Core.Model;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 提供 QQMini 应用程序公开接口的调用实现
	/// </summary>
	[Serializable]
	public sealed class QMApi
	{
		#region --字段--
		private readonly int _authCode;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMApi"/> 类的新实例
		/// </summary>
		/// <param name="authCode">用于给 QMApi 授权的授权码</param>
		public QMApi (int authCode)
		{
			this._authCode = authCode;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 获取当前运行的 QQMini 框架的版本
		/// </summary>
		/// <returns><see cref="QQMiniFrameworkTypes"/> 的枚举值</returns>
		public QQMiniFrameworkTypes GetFrameType ()
		{
			return (QQMiniFrameworkTypes)QQMiniApi.QMApi_GetFrameType (this._authCode);
		}
		#endregion
	}
}
