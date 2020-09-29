using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架群组成员减少事件子类型的枚举
	/// </summary>
	public enum QMGroupMemberDecreaseEventSubTypes
	{
		/// <summary>
		/// 群组成员离开
		/// </summary>
		GroupMemberLeave = 1,
		/// <summary>
		/// 群管理员移除成员
		/// </summary>
		GroupManagerRemoveMember = 2
	}
}
