using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
