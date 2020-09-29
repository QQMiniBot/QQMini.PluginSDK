using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架群组匿名状态改变事件子类型的枚举
	/// </summary>
	public enum QMGroupAnonymousChangeEventSubTypes
	{
		/// <summary>
		/// 群组匿名开启
		/// </summary>
		GroupAnonymousOpen = 1,
		/// <summary>
		/// 群组匿名关闭
		/// </summary>
		GroupAnonymousClose = 2,
	}
}
