using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 插件事件处理类型的枚举
	/// </summary>
	public enum QMEventHandlerTypes
	{
		/// <summary>
		/// 指示框架向后续的插件继续传递事件
		/// </summary>
		Continue = 0,
		/// <summary>
		/// 指示框架拦截事件, 禁止事件向后续的插件继续传递
		/// </summary>
		Intercept = 1,
		/// <summary>
		/// 指示框架当前事件出现了异常, 但是允许向后续的插件传递事件(本值为 .NET 插件专用)
		/// </summary>
		Exception = 2
	}
}
