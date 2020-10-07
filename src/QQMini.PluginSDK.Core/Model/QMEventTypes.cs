using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 插件事件类型的枚举
	/// </summary>
	public enum QMEventTypes
	{
		/// <summary>
		/// 私聊消息
		/// </summary>
		PrivateMessage = 1,
		/// <summary>
		/// 群组消息
		/// </summary>
		GroupMessage = 2,
		/// <summary>
		/// 讨论组消息
		/// </summary>
		DiscussMessage = 3,
		/// <summary>
		/// 好友添加请求
		/// </summary>
		FriendAddRequest = 4,
		/// <summary>
		/// 好友添加响应
		/// </summary>
		FriendAddResponse = 5,
		/// <summary>
		/// 被好友删除
		/// </summary>
		BeFriendDelete = 6,
		/// <summary>
		/// 群组添加请求
		/// </summary>
		GroupAddRequest = 7,
		/// <summary>
		/// 群组成员加入
		/// </summary>
		GroupMemberInstance = 8,
		/// <summary>
		/// 群组成员离开
		/// </summary>
		GroupMemberDecrease = 9,
		/// <summary>
		/// 群组被解散
		/// </summary>
		GroupDissmiss = 10,
		/// <summary>
		/// 群组管理员改变
		/// </summary>
		GroupManagerChange = 11,
		/// <summary>
		/// 群组成员名片改变
		/// </summary>
		GroupMemberCardChange = 12,
		/// <summary>
		/// 群名片改变
		/// </summary>
		GroupNameChange = 13,
		/// <summary>
		/// 群组禁言
		/// </summary>
		GroupBanSpeak = 14,
		/// <summary>
		/// 群组成员禁言
		/// </summary>
		GroupMemberBanSpeak = 15,
		/// <summary>
		/// 群匿名改变
		/// </summary>
		GroupAnonymousChange = 16,
		/// <summary>
		/// 群成员撤回消息
		/// </summary>
		GroupMemberRemoveMessage = 17
	}
}
