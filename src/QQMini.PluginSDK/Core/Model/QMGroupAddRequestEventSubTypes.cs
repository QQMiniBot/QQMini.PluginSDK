using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架群组添加请求事件子类型的枚举
	/// </summary>
	public enum QMGroupAddRequestEventSubTypes
	{
		/// <summary>
		/// 申请加群
		/// </summary>
		ApplyAddGroup = 1,
		/// <summary>
		/// 邀请加群
		/// </summary>
		InviteMyAddGroup = 2
	}
}
