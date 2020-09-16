using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QQMini.PluginSDK.Core.Core;
using QQMini.PluginSDK.Core.Model;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 提供 QQMini 应用程序公开接口的调用实现
	/// </summary>
	[Serializable]
	public sealed class QMApi
	{
		#region --字段--
		private readonly int _authCode;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMApi"/> 类的新实例
		/// </summary>
		/// <param name="authCode">用于给 QMApi 授权的授权码</param>
		public QMApi (int authCode)
		{
			this._authCode = authCode;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 获取当前运行的 QQMini 框架的版本
		/// </summary>
		/// <returns><see cref="QQMiniFrameworkTypes"/> 的枚举值</returns>
		public QQMiniFrameworkTypes GetFrameType()
		{
			return (QQMiniFrameworkTypes)QQMiniApi.QMApi_GetFrameType(this._authCode);
		}
		/// <summary>
		/// 获取框架版本号
		/// </summary>
		/// <returns>版本号以 "x.x.x.x" 表示当前框架的版本</returns>
		public IntPtr GetFrameVersion()
		{
			return QQMiniApi.QMApi_GetFrameVersion(this._authCode);
		}
		/// <summary>
		/// 获取框架内部时间戳
		/// </summary>
		/// <returns>以秒为单位的时间戳</returns>
		public long GetFrameTimeStamp()
		{
			return QQMiniApi.QMApi_GetFrameTimeStamp(this._authCode);
		}
		/// <summary>
		/// 获取插件数据目录
		/// </summary>
		/// <returns>绝对路径</returns>
		public IntPtr GetPluginDataDirectory()
		{
			return QQMiniApi.QMApi_GetPluginDataDirectory(this._authCode);
		}
		/// <summary>
		/// 获取指定QQ的好友列表
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="bUseCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <param name="szFriendList">存放获取到的好友列表. 此参数为 Base64 字符串, 需要转换为字节集进行解析</param>
		/// <returns>如果成功返回 0, 否则返回负值</returns>
		public int GetFriendList(long lResponseQQ, IntPtr szFriendList, bool bUseCache = true)
		{
			return QQMiniApi.QMApi_GetFriendList(this._authCode, lResponseQQ, bUseCache, szFriendList);
		}
		/// <summary>
		/// 获取指定QQ的好友信息,
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要获取好友信息的目标QQ</param>
		/// <param name="bUseCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <param name="szFriendInfo">存放获取到的好友列表. 此参数为 Base64 字符串, 需要转换为字节集进行解析</param>
		/// <returns>如果成功返回 0, 否则返回负值</returns>
		public int GetFriendInfo(long lResponseQQ, long lDestQQ, IntPtr szFriendInfo, bool bUseCache = true)
		{
			return QQMiniApi.QMApi_GetFriendInfo(this._authCode, lResponseQQ, lDestQQ, bUseCache, szFriendInfo);
		}
		/// <summary>
		/// 获取指定QQ的陌生人信息
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要获取陌生人信息的目标QQ</param>
		/// <param name="szStrangerInfo">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <param name="bUseCache">存放获取到的陌生人信息</param>
		/// <returns>如果成功返回 0, 否则返回负值</returns>
		public int GetStrangerInfo(long lResponseQQ, long lDestQQ, IntPtr szStrangerInfo, bool bUseCache = true)
		{
			return QQMiniApi.QMApi_GetStrangerInfo(this._authCode, lResponseQQ, lDestQQ, bUseCache, szStrangerInfo);
		}
		/// <summary>
		/// 获取指定QQ的群组列表
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szGroupList">存放获取到的群组列表, 此参数为 Base64 字符串, 需要转换为字节集进行解析</param>
		/// <param name="bUseCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>如果成功返回 0, 否则返回负值</returns>
		public int GetGroupList(long lResponseQQ, IntPtr szGroupList, bool bUseCache = true)
		{
			return QQMiniApi.QMApi_GetGroupList(this._authCode, lResponseQQ, bUseCache, szGroupList);
		}
		/// <summary>
		/// 获取指定QQ指定群组的群组信息
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要获取群组信息的目标群组</param>
		/// <param name="bUseCache"></param>
		/// <param name="szGroupInfo">存放获取到的群组列表, 此参数为 Base64 字符串, 需要转换为字节集进行解析</param>
		/// <returns>如果成功返回 0, 否则返回负值</returns>
		public int GetGroupInfo(long lResponseQQ, long lDestGroup, bool bUseCache, IntPtr szGroupInfo)
		{
			return QQMiniApi.QMApi_GetGroupInfo(this._authCode, lResponseQQ, lDestGroup, bUseCache, szGroupInfo);
		}
		/// <summary>
		/// 获取指定QQ在指定群组的群成员信息.
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要获取群组成员列表的目标群组</param>
		/// <param name="szGroupManagerList">存放获取到的群组列表, 此参数为 Base64 字符串, 需要转换为字节集进行解析</param>
		/// <param name="bUseCache"></param>
		/// <returns>如果成功返回 0, 否则返回负值</returns>
		public int GetGroupMemberList(long lResponseQQ, long lDestGroup, IntPtr szGroupManagerList, bool bUseCache = true)
		{
			return QQMiniApi.QMApi_GetGroupMemberList(this._authCode, lResponseQQ, lDestGroup, bUseCache, szGroupManagerList);
		}
		/// <summary>
		/// 获取指定QQ在指定群组的群成员信息
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要获取群组成员信息的目标群组</param>
		/// <param name="lDestQQ">要在群组内获取其成员信息的目标QQ</param>
		/// <param name="szGroupMemberInfo">存放获取到的群组成员信息,  此参数为 Base64 字符串, 需要转换为字节集进行解析</param>
		/// <param name="bUseCache"></param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetGroupMemberInfo(long lResponseQQ, long lDestGroup, long lDestQQ, IntPtr szGroupMemberInfo, bool bUseCache = true)
		{
			return QQMiniApi.QMApi_GetGroupMemberInfo(this._authCode, lResponseQQ, lDestGroup, lDestQQ, bUseCache, szGroupMemberInfo);
		}
		/// <summary>
		/// 获取指定QQ指定群组的管理员列表
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要获取群组管理员列表的目标群组</param>
		/// <param name="szGroupManagerList">存放获取到的群组管理员列表</param>
		/// <param name="bUseCache"></param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetGroupManagerList(long lResponseQQ, long lDestGroup, IntPtr szGroupManagerList, bool bUseCache = true)
		{
			return QQMiniApi.QMApi_GetGroupManagerList(this._authCode, lResponseQQ, lDestGroup, bUseCache, szGroupManagerList);
		}
		/// <summary>
		/// 获取指定QQ的讨论组列表
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szDiscussList">存放获取到的讨论组列表</param>
		/// <param name="bUseCache"></param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetDiscussList(long lResponseQQ, IntPtr szDiscussList, bool bUseCache = true)
		{
			return QQMiniApi.QMApi_GetDiscussList(this._authCode, lResponseQQ, bUseCache, szDiscussList);
		}
		/// <summary>
		/// 获取指定QQ指定讨论组的讨论组成员列
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestDiscuss">要获取讨论组成员列表的目标讨论组</param>
		/// <param name="bUseCache"></param>
		/// <param name="szDiscussMemberList"></param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetDiscussMemberList(long lResponseQQ, long lDestDiscuss, bool bUseCache, IntPtr szDiscussMemberList)
		{
			return QQMiniApi.QMApi_GetDiscussMemberList(this._authCode, lResponseQQ, lDestDiscuss, bUseCache, szDiscussMemberList);
		}
		/// <summary>
		/// 获取指定QQ网页操作用的 Cookies
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szCookies">存放获取到的 Cookies 字符串.</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetCookies(long lResponseQQ, IntPtr szCookies)
		{
			return QQMiniApi.QMApi_GetCookies(this._authCode, lResponseQQ, szCookies);
		}
		/// <summary>
		/// 获取指定QQ网页操作用的 G_tk 或 Bkn 参数
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szBkn">存放获取到的 G_tk 或 Bkn 字符串.</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetBkn(long lResponseQQ, IntPtr szBkn)
		{
			return QQMiniApi.QMApi_GetBkn(this._authCode, lResponseQQ, szBkn);
		}
		/// <summary>
		/// 获取指定QQ的在线状态.
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要查询在线状态的QQ. 如果为空则查询 lResponseQQ</param>
		/// <param name="nOnlineStatus">存放在线状态. 在线(1), Q我吧(2), 离开(3), 忙碌(4), 请勿打扰(5), 隐身(6). 参考 #STATUS_ 常量</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetOnlineStatus(long lResponseQQ, long lDestQQ, IntPtr nOnlineStatus)
		{
			return QQMiniApi.QMApi_GetOnlineStatus(this._authCode, lResponseQQ, lDestQQ, nOnlineStatus);
		}
		/// <summary>
		/// 获取群组或群组成员的禁言状态.
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要查询是否被禁言群组</param>
		/// <param name="lDestQQ">要查询是否被禁言群组内的QQ</param>
		/// <param name="bIsBan">存放查询结果.</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetGroupBanStatus(long lResponseQQ, long lDestGroup, long lDestQQ, bool bIsBan)
		{
			return QQMiniApi.QMApi_GetGroupBanStatus(this._authCode, lResponseQQ, lDestGroup, lDestQQ, bIsBan);
		}

		/// <summary>
		/// 获取指定QQ的好友验证方式.
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="IDestQQ">要查询其好友验证方式的目标QQ</param>
		/// <param name="nFriendVerify">存放查询到目标QQ的好友验证方式. 无验证(0), 需身份验证(1), 需正确答案(3), 需回答问题(4), 已成为好友(99). 参考 #VERIFY_ 常量</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetFriendVerifyMode(long lResponseQQ, long IDestQQ, int nFriendVerify)
		{
			return QQMiniApi.QMApi_GetFriendVerifyMode(this._authCode, lResponseQQ, IDestQQ, nFriendVerify);
		}
		/// <summary>
		/// 获取指定的QQ是否在线
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="IDestQQ">要查询其是否在线的目标QQ</param>
		/// <param name="bIsOnline">存放查询到目标QQ是否在线</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetIsOnline(long lResponseQQ, long IDestQQ, bool bIsOnline)
		{
			return QQMiniApi.QMApi_GetIsOnline(this._authCode, lResponseQQ, IDestQQ, bIsOnline);
		}
		/// <summary>
		/// 获取指定QQ是否接收在线临时消息
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="IDestQQ">要查询其是否在线的目标QQ</param>
		/// <param name="bIsOnline">存放查询到目标QQ是否在线</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetIsReceiveOnlineTempMessage(long lResponseQQ, long IDestQQ, bool bIsOnline)
		{
			return QQMiniApi.QMApi_GetIsReceiveOnlineTempMessage(this._authCode, lResponseQQ, IDestQQ, bIsOnline);
		}
		/// <summary>
		/// 获取指定讨论组的名称
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestDiscuss">要获取其名称的目标讨论组</param>
		/// <param name="szDiscussName">存放获取的讨论组名称</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetDiscussName(long lResponseQQ, long lDestDiscuss, IntPtr szDiscussName)
		{
			return QQMiniApi.QMApi_GetDiscussName(this._authCode, lResponseQQ, lDestDiscuss, szDiscussName);
		}
		/// <summary>
		/// 获取指定讨论组的加入链接
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestDiscuss">要获取加入链接的目标讨论组</param>
		/// <param name="szDiscussAddLink">存放讨论组加入链接</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetDiscussAddLink(long lResponseQQ, long lDestDiscuss, IntPtr szDiscussAddLink)
		{
			return QQMiniApi.QMApi_GetDiscussAddLink(this._authCode, lResponseQQ, lDestDiscuss, szDiscussAddLink);
		}
		/// <summary>
		/// 获取收到的群组礼物
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szGiftList">存放查询到的礼物列表</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetGroupGiftList(long lResponseQQ, IntPtr szGiftList)
		{
			return QQMiniApi.QMApi_GetGroupGiftList(this._authCode, lResponseQQ, szGiftList);
		}
		/// <summary>
		/// 随机获取群礼物(需要Lv5群聊等级).
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup"></param>
		/// <param name="szGift">存放查询到的礼物</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int GetRandomGroupGift(long lResponseQQ, long lDestGroup, IntPtr szGift)
		{
			return QQMiniApi.QMApi_GetRandomGroupGift(this._authCode, lResponseQQ, lDestGroup, szGift);
		}
		/// <summary>
		/// 设置一条日志信息到框架
		/// </summary>
		/// <param name="nLevel">类型: 调试(0), 信息(1), 警告(2), 错误(3), 严重错误(4). 若使用严重错误, 会使主程序停止运行</param>
		/// <param name="szMessage">日志的详细信息字符串</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetLogger(int nLevel, IntPtr szMessage)
		{
			return QQMiniApi.QMApi_SetLogger(this._authCode, nLevel, szMessage);
		}
		/// <summary>
		/// 设置指定QQ的在线状态.
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="nOnlineStatus">在线(1), Q我吧(2), 离开(3), 忙碌(4), 请勿打扰(5), 隐身(6). 参考 #STATUS_ 常量</param>
		/// <param name="szStatusMessage">要附加的在线状态信息. 最大255字节</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetOnlineStatus(long lResponseQQ, int nOnlineStatus, IntPtr szStatusMessage)
		{
			return QQMiniApi.QMApi_SetOnlineStatus(this._authCode, lResponseQQ, nOnlineStatus, szStatusMessage);
		}
		/// <summary>
		/// 设置QQ添加到黑名单列表
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要加入黑名单的目标QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetAddQQToBlacklist(long lResponseQQ, long lDestQQ)
		{
			return QQMiniApi.QMApi_SetAddQQToBlacklist(this._authCode, lResponseQQ, lDestQQ);
		}
		/// <summary>
		/// 设置群组或群组成员禁言
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要禁言的QQ所在的群组</param>
		/// <param name="lDestQQ">要在群组禁言的QQ</param>
		/// <param name="nTimeSpan">要禁言的时长.单位: 秒, 范围:1 - 2592000(30天). 0为解除禁言</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetGroupBanStatus(long lResponseQQ, long lDestGroup, long lDestQQ, int nTimeSpan)
		{
			return QQMiniApi.QMApi_SetGroupBanStatus(this._authCode, lResponseQQ, lDestGroup, lDestQQ, nTimeSpan);
		}
		/// <summary>
		/// 设置群组匿名功能状态
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要设置匿名功能的目标群组</param>
		/// <param name="bIsEnabled">如果此参数为真, 则启动该群的匿名功能. 否则关闭匿名功能. 默认值: 假</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetGroupAnonymousStatus(long lResponseQQ, long lDestGroup, bool bIsEnabled)
		{
			return QQMiniApi.QMApi_SetGroupAnonymousStatus(this._authCode, lResponseQQ, lDestGroup, bIsEnabled);
		}
		/// <summary>
		/// 设置群组屏蔽状态
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要设置屏蔽状态的群组</param>
		/// <param name="bIsShielded">如果该值为 "真" 屏蔽群消息, 否则为接受并提醒. 默认值: 假</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetGroupShieldedStatus(long lResponseQQ, long lDestGroup, bool bIsShielded)
		{
			return QQMiniApi.QMApi_SetGroupShieldedStatus(this._authCode, lResponseQQ, lDestGroup, bIsShielded);
		}
		/// <summary>
		/// 设置群组管理员
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要设置管理员的群组</param>
		/// <param name="IDestQQ">要在群组内设置为管理员的QQ</param>
		/// <param name="bIsManager">是否设置为管理员</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetGroupManager(long lResponseQQ, long lDestGroup, long IDestQQ, bool bIsManager)
		{
			return QQMiniApi.QMApi_SetGroupManager(this._authCode, lResponseQQ, lDestGroup, IDestQQ, bIsManager);
		}
		/// <summary>
		/// 设置群组成员名片
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要设置群名片的目标群组</param>
		/// <param name="lDestQQ">要在群组内设置群名片的目标QQ</param>
		/// <param name="szNewCard">要设置的新名片</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetGroupMemberCard(long lResponseQQ, long lDestGroup, long lDestQQ, IntPtr szNewCard)
		{
			return QQMiniApi.QMApi_SetGroupMemberCard(this._authCode, lResponseQQ, lDestGroup, lDestQQ, szNewCard);
		}
		/// <summary>
		/// 设置群组退出(机器人是群主则解散群). 如果成功返回 0, 否则返回负值
		/// </summary>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetGroupQuit()
		{
			return QQMiniApi.QMApi_SetGroupQuit();
		}
		/// <summary>
		///	设置讨论组名称
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestDiscuss">要执行修改名称的目标讨论组</param>
		/// <param name="szNewName">要修改的新名称</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetDiscussName(long lResponseQQ, long lDestDiscuss, IntPtr szNewName)
		{
			return QQMiniApi.QMApi_SetDiscussName(this._authCode, lResponseQQ, lDestDiscuss, szNewName);
		}
		/// <summary>
		/// 设置好友备注
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要执行备注修改的好友QQ</param>
		/// <param name="szNewNotes">要修改的新备注</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetFriendNotes(long lResponseQQ, long lDestQQ, IntPtr szNewNotes)
		{
			return QQMiniApi.QMApi_SetFriendNotes(this._authCode, lResponseQQ, lDestQQ, szNewNotes);
		}
		/// <summary>
		/// 设置个性签名
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szNewSignature">要修改的新个性签名</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetSignature(long lResponseQQ, IntPtr szNewSignature)
		{
			return QQMiniApi.QMApi_SetSignature(this._authCode, lResponseQQ, szNewSignature);
		}
		/// <summary>
		/// 设置性别
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="nGender">要设置的性别值. 男(1),女(2). 参考 #GENDER_ 常量</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetGender(long lResponseQQ, int nGender)
		{
			return QQMiniApi.QMApi_SetGender(this._authCode, lResponseQQ, nGender);
		}
		/// <summary>
		/// 设置昵称
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szNewNick">要修改的新昵称</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetNick(long lResponseQQ, IntPtr szNewNick)
		{
			return QQMiniApi.QMApi_SetNick(this._authCode, lResponseQQ, szNewNick);
		}
		/// <summary>
		/// 设置好友添加请求	
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要处理请求添加好友的目标QQ</param>
		/// <param name="nResponseType">处理该请求的方式. 同意(10). 拒绝(20), 忽略(30). 参考 #RESPONSE_ 常</param>
		/// <param name="szAppendMsg">处理请求时的附加信息</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetFriendAddRequest(long lResponseQQ, long lDestQQ, int nResponseType, IntPtr szAppendMsg)
		{
			return QQMiniApi.QMApi_SetFriendAddRequest(this._authCode, lResponseQQ, lDestQQ, nResponseType, szAppendMsg);
		}
		/// <summary>
		/// 设置群组添加请求
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要处理请求加入的目标群组</param>
		/// <param name="lDestQQ">要请求处理加入群组的目标QQ</param>
		/// <param name="szSeq">从事件处收到的请求标识</param>
		/// <param name="nResponseType">处理该请求的方式. 同意(10). 拒绝(20), 忽略(30). 参考 #RESPONSE_ 常量</param>
		/// <param name="szAppendMsg">处理请求时的附加信息</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SetGroupAddRequest(long lResponseQQ, long lDestGroup, long lDestQQ, IntPtr szSeq, int nResponseType, IntPtr szAppendMsg)
		{
			return QQMiniApi.QMApi_SetGroupAddRequest(this._authCode, lResponseQQ, lDestGroup, lDestQQ, szSeq, nResponseType, szAppendMsg);
		}
		/// <summary>
		/// 发送一条消息
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="nSendType">指定消息的发送类型, 参考 #MSG_ 常量</param>
		/// <param name="lDestTarget">发送到的目标群组或讨论组</param>
		/// <param name="IDestQQ">发送到的目标QQ</param>
		/// <param name="szMessage">要发送的详细信息</param>
		/// <param name="nXMLSubType">基本结构(0), 歌曲结构(2), 其他值不明. 参考 #XML_. 如果是普通消息和JSON消息, 本参数为空</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendMessage(long lResponseQQ, int nSendType, long lDestTarget, long IDestQQ, IntPtr szMessage, int nXMLSubType)
		{
			return QQMiniApi.QMApi_SendMessage(this._authCode, lResponseQQ, nSendType, lDestTarget, IDestQQ, szMessage, nXMLSubType);
		}
		/// <summary>
		/// 发送一个点赞
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="IDestQQ">要为其点赞的目标QQ</param>
		/// <param name="nCount">点赞的次数, 1-10. 默认: 1</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendLike(long lResponseQQ, long IDestQQ, IntPtr nCount)
		{
			return QQMiniApi.QMApi_SendLike(this._authCode, lResponseQQ, IDestQQ, nCount);
		}
		/// <summary>
		/// 向好友发送抖动窗口(移动端为"戳一戳")
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">欲抖动的好友</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendShake(long lResponseQQ, long lDestQQ)
		{
			return QQMiniApi.QMApi_SendShake(this._authCode, lResponseQQ, lDestQQ);
		}
		/// <summary>
		/// 向指定群发送群签到
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">欲接收此签到的群组</param>
		/// <param name="szPlaceName">签到地名(Pro可用)</param>
		/// <param name="szMessage">想法发表的内容</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendSignIn(long lResponseQQ, long lDestGroup, IntPtr szPlaceName, IntPtr szMessage)
		{
			return QQMiniApi.QMApi_SendSignIn(this._authCode, lResponseQQ, lDestGroup, szPlaceName, szMessage);
		}
		/// <summary>
		/// 向好友发送正在输入状态
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">欲接收此状态的目标QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendInputing(long lResponseQQ, long lDestQQ)
		{
			return QQMiniApi.QMApi_SendInputing(this._authCode, lResponseQQ, lDestQQ);
		}
		/// <summary>
		/// 向群组发送一条公告
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要发送公告的目标群组</param>
		/// <param name="szNotificationTitle">要发送群公告的标题</param>
		/// <param name="szNotificationContent">要发送群公告的内容</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendGroupNotification(long lResponseQQ, long lDestGroup, IntPtr szNotificationTitle, IntPtr szNotificationContent)
		{
			return QQMiniApi.QMApi_SendGroupNotification(this._authCode, lResponseQQ, lDestGroup, szNotificationTitle, szNotificationContent);
		}
		/// <summary>
		/// 向群组发送一条作业
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要发送作业的目标群组</param>
		/// <param name="szWorkName">作业的名称</param>
		/// <param name="szWorkTitle">作业的标题</param>
		/// <param name="szWorkContent">作业的内容</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendGroupWork(long lResponseQQ, long lDestGroup, IntPtr szWorkName, IntPtr szWorkTitle, IntPtr szWorkContent)
		{
			return QQMiniApi.QMApi_SendGroupWork(this._authCode, lResponseQQ, lDestGroup, szWorkName, szWorkTitle, szWorkContent);
		}
		/// <summary>
		/// 向群组成员发送群组礼物
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要送出礼物的群组</param>
		/// <param name="lDestQQ">要接收礼物的目标QQ</param>
		/// <param name="szGiftPid">要送出的礼物的 PID</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendGroupGift(long lResponseQQ, long lDestGroup, long lDestQQ, IntPtr szGiftPid)
		{
			return QQMiniApi.QMApi_SendGroupGift(this._authCode, lResponseQQ, lDestGroup, lDestQQ, szGiftPid);
		}
		/// <summary>
		/// 发送群添加请求
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">欲申请加入的群的群号码</param>
		/// <param name="szAppendMsg">附加的申请消息. 可为空 (需回答正确问题时, 请添加问题的答案)</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendGroupAddRequest(long lResponseQQ, long lDestGroup, IntPtr szAppendMsg)
		{
			return QQMiniApi.QMApi_SendGroupAddRequest(this._authCode, lResponseQQ, lDestGroup, szAppendMsg);
		}
		/// <summary>
		/// 发送好友添加请求
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">欲申请添加的目标QQ</param>
		/// <param name="szAppendMsg">附加的申请消息. 可为空</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendFriendAddRequest(long lResponseQQ, long lDestQQ, IntPtr szAppendMsg)
		{
			return QQMiniApi.QMApi_SendFriendAddRequest(this._authCode, lResponseQQ, lDestQQ, szAppendMsg);
		}
		/// <summary>
		/// 发送群组邀请请求
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要邀请进入的目标群组</param>
		/// <param name="lDestQQ">要邀请的目标QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendGroupInviteRequest(long lResponseQQ, long lDestGroup, long lDestQQ)
		{
			return QQMiniApi.QMApi_SendGroupInviteRequest(this._authCode, lResponseQQ, lDestGroup, lDestQQ);
		}
		/// <summary>
		/// 发送讨论组邀请请求
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestDiscuss">要邀请进入的目标讨论组</param>
		/// <param name="lDestQQ">被邀请进入讨论组的目标QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendDiscussInviteRequest(long lResponseQQ, long lDestDiscuss, IntPtr lDestQQ)
		{
			return QQMiniApi.QMApi_SendDiscussInviteRequest(this._authCode, lResponseQQ, lDestDiscuss, lDestQQ);
		}
		/// <summary>
		/// 接收指定的图片
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szPictureGUID">要接收图片的图片GUID, 例如: {xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx}.qqmini.image</param>
		/// <param name="szPicturePath">存放接收到图片位于本地服务器的绝对路径. </param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int DownloadPicture(long lResponseQQ, IntPtr szPictureGUID, IntPtr szPicturePath)
		{
			return QQMiniApi.QMApi_DownloadPicture(this._authCode, lResponseQQ, szPictureGUID, szPicturePath);
		}
		/// <summary>
		/// 接收指定的语音
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szVoiceGUID">要接收语音的语音GUID, 例如: {xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx}.qqmini.voice</param>
		/// <param name="szVoiceOutFormat">要接收语音的目标语音格式. </param>
		/// <param name="szVoicePath">存放接收到语音位于本地服务器的绝对路径. </param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int DownloadVoice(long lResponseQQ, IntPtr szVoiceGUID, int szVoiceOutFormat, IntPtr szVoicePath)
		{
			return QQMiniApi.QMApi_DownloadVoice(this._authCode, lResponseQQ, szVoiceGUID, szVoiceOutFormat, szVoicePath);
		}
		/// <summary>
		/// 上传指定的图片
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szPicturePath">要上传图片的图片位于本地服务器的绝对路径</param>
		/// <param name="szPictureGUID">存放要上传图片的图片 GUID, 该 GUID 用于发送, 发送时图片将会被上传</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int UploadPicture(long lResponseQQ, IntPtr szPicturePath, IntPtr szPictureGUID)
		{
			return QQMiniApi.QMApi_UploadPicture(this._authCode, lResponseQQ, szPicturePath, szPictureGUID);
		}
		/// <summary>
		/// 上传指定的语音
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szVoicePath">要上传图片的语音位于本地服务器的绝对路径</param>
		/// <param name="szVoiceGUID">存放要上传语音的语音 GUID, 该 GUID 用于发送.</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int UploadVoice(long lResponseQQ, IntPtr szVoicePath, IntPtr szVoiceGUID)
		{
			return QQMiniApi.QMApi_UploadVoice(this._authCode, lResponseQQ, szVoicePath, szVoiceGUID);
		}
		/// <summary>
		/// 上传指定QQ的头像
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szPicturePath">要设置的QQ头像位于本地服务器的绝对路径</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int UploadHeadPortraits(long lResponseQQ, IntPtr szPicturePath)
		{
			return QQMiniApi.QMApi_UploadHeadPortraits(this._authCode, lResponseQQ, szPicturePath);
		}
		/// <summary>
		/// 上传指定QQ的封面
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szPicturePath">要设置的QQ封面位于本地服务器的绝对路径</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int UploadCover(long lResponseQQ, IntPtr szPicturePath)
		{
			return QQMiniApi.QMApi_UploadCover(this._authCode, lResponseQQ, szPicturePath);
		}
		/// <summary>
		/// 从黑名单列表中移除QQ
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要移除黑名单的目标QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int RemoveFromBlacklist(long lResponseQQ, long lDestQQ)
		{
			return QQMiniApi.QMApi_RemoveFromBlacklist(this._authCode, lResponseQQ, lDestQQ);
		}
		/// <summary>
		/// 从好友列表中移除QQ
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要删除的目标QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int RemoveFriend(long lResponseQQ, long lDestQQ)
		{
			return QQMiniApi.QMApi_RemoveFriend(this._authCode, lResponseQQ, lDestQQ);
		}
		/// <summary>
		/// 移除一条消息
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="nMessageId">要撤回的消息的消息ID</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int RemoveMessage(long lResponseQQ, int nMessageId)
		{
			return QQMiniApi.QMApi_RemoveMessage(this._authCode, lResponseQQ, nMessageId);
		}
		/// <summary>
		/// 移除群组成员
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestGroup">要执行群成员移除的群组</param>
		/// <param name="lDestQQ">要被群组移除的QQ</param>
		/// <param name="bIsRefuseAccept">要被群组移除的QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int RemoveGroupMember(long lResponseQQ, long lDestGroup, long lDestQQ, bool bIsRefuseAccept)
		{
			return QQMiniApi.QMApi_RemoveGroupMember(this._authCode, lResponseQQ, lDestGroup, lDestQQ, bIsRefuseAccept);
		}
		/// <summary>
		/// 移除讨论组成员
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestDiscuss">要执行讨论组成员移除的讨论组</param>
		/// <param name="lDestQQ">要被讨论组移除的QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int RemoveDiscussMember(long lResponseQQ, long lDestDiscuss, long lDestQQ)
		{
			return QQMiniApi.QMApi_RemoveDiscussMember(this._authCode, lResponseQQ, lDestDiscuss, lDestQQ);
		}
		/// <summary>
		/// 创建讨论组
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="lDestQQ">要邀请进入讨论组的成员QQ</param>
		/// <param name="lDiscussId">存放创建成功的讨论组的讨论组ID</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int CreateDiscuss(long lResponseQQ, long lDestQQ, long lDiscussId)
		{
			return QQMiniApi.QMApi_CreateDiscuss(this._authCode, lResponseQQ, lDestQQ, lDiscussId);
		}
		/// <summary>
		/// 通过链接加入讨论组.
		/// </summary>
		/// <param name="lResponseQQ">要响应此接口的QQ</param>
		/// <param name="szDiscussLink">要加入的讨论组的讨论组链接</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int AddDiscussFromLink(long lResponseQQ, IntPtr szDiscussLink)
		{
			return QQMiniApi.QMApi_AddDiscussFromLink(this._authCode, lResponseQQ, szDiscussLink);
		}
		#endregion
	}
}
