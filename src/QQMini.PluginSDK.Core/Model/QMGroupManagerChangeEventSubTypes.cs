using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架群组管理员改变事件子类型的枚举
	/// </summary>
	public enum QMGroupManagerChangeEventSubTypes
	{
		/// <summary>
		/// 成为管理员
		/// </summary>
		BecomeManager = 1,
		/// <summary>
		/// 取消管理员
		/// </summary>
		CanceledManager = 2
	}
}
