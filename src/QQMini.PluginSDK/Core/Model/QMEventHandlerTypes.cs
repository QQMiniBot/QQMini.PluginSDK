using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示事件处理类型的枚举
	/// </summary>
	public enum QMEventHandlerTypes
	{
		/// <summary>
		/// 继续
		/// </summary>
		Continue = 0,
		/// <summary>
		/// 拦截
		/// </summary>
		Intercept = 1,
		/// <summary>
		/// 异常
		/// </summary>
		Exception = 2,
	}
}
