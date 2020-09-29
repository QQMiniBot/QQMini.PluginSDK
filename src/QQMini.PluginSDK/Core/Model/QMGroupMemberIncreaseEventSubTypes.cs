using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架群组成员增加事件子类型的枚举
	/// </summary>
	public enum QMGroupMemberIncreaseEventSubTypes
	{
		/// <summary>
		/// 被批准加入群组
		/// </summary>
		BeAllowAddGroup = 1,
		/// <summary>
		/// 我加入了群组
		/// </summary>
		MyAddGroup = 2,
		/// <summary>
		/// 被邀请加入了群组
		/// </summary>
		BeInviteAddGroup = 3
	}
}
