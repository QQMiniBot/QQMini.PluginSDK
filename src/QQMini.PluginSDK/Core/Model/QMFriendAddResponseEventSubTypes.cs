using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架好友添加响应事件子类型的枚举
	/// </summary>
	public enum QMFriendAddResponseEventSubTypes
	{
		/// <summary>
		/// 同意添加好友
		/// </summary>
		AgreeAddFriend = 1,
		/// <summary>
		/// 拒绝添加好友
		/// </summary>
		RefuseAddFriend = 2
	}
}
