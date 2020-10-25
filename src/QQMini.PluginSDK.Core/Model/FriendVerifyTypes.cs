using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示好友验证方式的枚举
	/// </summary>
	public enum FriendVerifyTypes
	{
		/// <summary>
		/// 无验证
		/// </summary>
		NoVerify = 0,
		/// <summary>
		/// 需身份验证
		/// </summary>
		Authentication = 1,
		/// <summary>
		/// 需正确答案
		/// </summary>
		NeetCorrectAnswer = 3,
		/// <summary>
		/// 需回答问题
		/// </summary>
		NeedAnswers = 4,
		/// <summary>
		/// 已成为好友
		/// </summary>
		AlreadyFriend = 99
	}
}
