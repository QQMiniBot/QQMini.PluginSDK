using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架私聊事件子类型的枚举
	/// </summary>
	public enum QMPrivateEventSubTypes
	{
		/// <summary>
		/// 好友消息
		/// </summary>
		Friend = 1,
		/// <summary>
		/// 群临时消息
		/// </summary>
		GroupTemp = 2,
		/// <summary>
		/// 讨论组临时消息
		/// </summary>
		DiscussTemp =3,
		/// <summary>
		/// 在线临时消息
		/// </summary>
		OnlineTemp = 4,
		/// <summary>
		/// 好友验证回复
		/// </summary>
		FriendVerify = 5
	}
}
