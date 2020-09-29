using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架群组成员禁言事件子类型的枚举
	/// </summary>
	public enum QMGroupMemberBanSpeakEventSubTypes
	{
		/// <summary>
		/// 群组成员禁言
		/// </summary>
		GroupMemberSetBanSpeak = 1,
		/// <summary>
		/// 群组成员解除禁言
		/// </summary>
		GroupMemberRemoveBanSpeak = 2
	}
}
