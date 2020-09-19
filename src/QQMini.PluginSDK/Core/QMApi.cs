using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QQMini.PluginFramework.Utility.Core;
using QQMini.PluginSDK.Core.Core;
using QQMini.PluginSDK.Core.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;

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
		public QQMiniFrameworkTypes GetFrameType ()
		{
			return (QQMiniFrameworkTypes)QQMiniApi.QMApi_GetFrameType (this._authCode);
		}
		/// <summary>
		/// 获取框架版本号
		/// </summary>
		/// <returns>返回 QQMini 框架的版本号</returns>
		/// <exception cref="FormatException">转换字符串失败</exception> 
		public Version GetFrameVersion ()
		{
			IntPtr versionPtr = QQMiniApi.QMApi_GetFrameVersion (this._authCode);
			if (Version.TryParse (IntPtrUtility.ToString (versionPtr,Global.DefaultEncoding), out Version version))
			{
				return version;
			}
			throw new QQMiniPluginException (0,"无法解析指定的版本号");
		}
		/// <summary>
		/// 获取框架内部时间戳
		/// </summary>
		/// <returns>以秒为单位的时间戳</returns>
		public long GetFrameTimeStamp ()
		{
			return QQMiniApi.QMApi_GetFrameTimeStamp (this._authCode);
		}
		/// <summary>
		/// 获取插件数据目录
		/// </summary>
		/// <returns>绝对路径</returns>
		public string GetPluginDataDirectory ()
		{
			IntPtr intPtr = QQMiniApi.QMApi_GetPluginDataDirectory(this._authCode);
			return intPtr.ToString (Global.DefaultEncoding);
		}	
		/// <summary>
		/// 获取指定QQ的好友列表
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>好友列表集合</returns>
		public ReadOnlyCollection<object> GetFriendList (long responseQQ, bool useCache = true)
		{
			if (QQMiniApi.QMApi_GetFriendList (this._authCode, responseQQ,useCache,out IntPtr friendList) == 0)
			{
				string base64Data = friendList.ToString (Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String (base64Data);

				// TODO: 解析过程. 待定
				
				return null;
			}
			throw new QQMiniPluginException (1,$"【{responseQQ}】获取好友列表失败");
		}
		/// <summary>
		/// 获取指定QQ的好友信息,
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要获取好友信息的目标QQ</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>指定QQ的好友信息</returns>
		public int GetFriendInfo (long responseQQ, long destQQ, bool useCache = true)
		{
			if (QQMiniApi.QMApi_GetFriendInfo(this._authCode, responseQQ, destQQ, useCache,out IntPtr friendInfo) == 0)
            {
				string base64Data = friendInfo.ToString(Global.DefaultEncoding);

				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (2,$"【{responseQQ}】获取“{destQQ}”的好友信息失败");
		}
		/// <summary>
		/// 获取指定QQ的陌生人信息
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要获取陌生人信息的目标QQ</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>陌生人信息</returns>
		public int GetStrangerInfo (long responseQQ, long destQQ, bool useCache = true)
		{
			if (QQMiniApi.QMApi_GetStrangerInfo(this._authCode, responseQQ, destQQ, useCache,out IntPtr strangerInfo) == 0)
			{
				string base64Data = strangerInfo.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);
				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (3,$"【{responseQQ}】获取“{destQQ}”的陌生人信息失败");
		}
		/// <summary>
		/// 获取指定QQ的群组列表
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>群组列表</returns>
		public int GetGroupList (long responseQQ, bool useCache = true)
		{
			if (QQMiniApi.QMApi_GetGroupList(this._authCode, responseQQ, useCache,out IntPtr groupList) == 0)
			{
				string base64Data = groupList.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);
				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (4,$"【{responseQQ}】获取群组列表失败");
		}
		/// <summary>
		/// 获取指定QQ指定群组的群组信息
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要获取群组信息的目标群组</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>群组信息</returns>
		public int GetGroupInfo (long responseQQ, long destGroup, bool useCache)
		{
			if (QQMiniApi.QMApi_GetGroupInfo(this._authCode, responseQQ, destGroup, useCache,out IntPtr groupInfo) == 0)
			{
				string base64Data = groupInfo.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);
				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (5,$"【{responseQQ}】获取“{destGroup}”群组信息失败");
		}
		/// <summary>
		/// 获取指定QQ在指定群的成员群组列表.
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要获取群组成员列表的目标群组</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>成员群组列表</returns>
		public int GetGroupMemberList (long responseQQ, long destGroup, bool useCache = true)
		{
			if (QQMiniApi.QMApi_GetGroupMemberList(this._authCode, responseQQ, destGroup, useCache,out IntPtr groupManagerList) == 0)
			{
				string base64Data = groupManagerList.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);
				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (6,$"【{responseQQ}】获取“{destGroup}”成员群组列表失败");
		}
		//** 写到这里了哦！明天加油继续写！
		//今天加油继续写！
		/// <summary>
		/// 获取指定QQ在指定群组的群成员信息
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要获取群组成员信息的目标群组</param>
		/// <param name="destQQ">要在群组内获取其成员信息的目标QQ</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>群成员信息</returns>
		public int GetGroupMemberInfo (long responseQQ, long destGroup, long destQQ, bool useCache = true)
		{
			if (QQMiniApi.QMApi_GetGroupMemberInfo(this._authCode, responseQQ, destGroup, destQQ, useCache,out IntPtr groupMemberInfo) == 0)
			{
				string base64Data = groupMemberInfo.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);
				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (7,$"【{responseQQ}】获取“{destQQ}”的“{destGroup}”群成员信息失败");
		}
		/// <summary>
		/// 获取指定QQ指定群组的管理员列表
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要获取群组管理员列表的目标群组</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>管理员列表</returns>
		public int GetGroupManagerList (long responseQQ, long destGroup, bool useCache = true)
		{
			if (QQMiniApi.QMApi_GetGroupManagerList(this._authCode, responseQQ, destGroup, useCache,out IntPtr groupManagerList) == 0)
			{
				string base64Data = groupManagerList.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);
				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (8,$"【{responseQQ}】获取“{destGroup}”管理员列表失败");
		}
		/// <summary>
		/// 获取指定QQ的讨论组列表
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>讨论组列表</returns>
		public int GetDiscussList (long responseQQ, bool useCache = true)
		{
			if (QQMiniApi.QMApi_GetDiscussList(this._authCode, responseQQ, useCache,out IntPtr discussList) == 0)
			{
				string base64Data = discussList.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);
				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (9,$"【{responseQQ}】获取讨论组列表失败");
		}
		/// <summary>
		/// 获取指定QQ指定讨论组的讨论组成员列表
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destDiscuss">要获取讨论组成员列表的目标讨论组</param>
		/// <param name="useCache">指示是否从缓存中获取列表信息, 默认为 "真"</param>
		/// <returns>讨论组成员列表</returns>
		public int GetDiscussMemberList (long responseQQ, long destDiscuss, bool useCache )
		{
			if (QQMiniApi.QMApi_GetDiscussMemberList(this._authCode, responseQQ, destDiscuss, useCache,out IntPtr discussMemberList) == 0)
			{
				string base64Data = discussMemberList.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);
				// TODO: 解析过程. 待定

				return 0;
			}
			throw new QQMiniPluginException (10,$"【{responseQQ}】获取“{destDiscuss}”的讨论组成员列表失败");
		}
		/// <summary>
		/// 获取指定QQ网页操作用的 Cookies
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <returns>Cookies</returns>
		public Cookie GetCookies (long responseQQ)
		{
			if (QQMiniApi.QMApi_GetCookies(this._authCode, responseQQ, out IntPtr cookies) == 0)
			{
				string base64Data = cookies.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);

				

				// TODO: 解析过程. 待定

			}
			throw new QQMiniPluginException (11,$"【{responseQQ}】获取Cookies失败");
		}
		/// <summary>
		/// 获取指定QQ网页操作用的 G_tk 或 Bkn 参数
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <returns> G_tk 或 Bkn 参数</returns>
		public string GetBkn (long responseQQ)
		{
			if (QQMiniApi.QMApi_GetBkn(this._authCode, responseQQ,out IntPtr bkn) == 0)
			{
				// TODO: 解析过程. 待定

				return bkn.ToString();
			}
			throw new QQMiniPluginException (12,$"【{responseQQ}】获取G_tk 或 Bkn 参数失败");
		}
		/// <summary>
		/// 获取指定QQ的在线状态.
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要查询在线状态的QQ. 如果为空则查询 responseQQ</param>
		/// <returns>在线状态</returns>
		public StatusTypes GetOnlineStatus (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_GetOnlineStatus(this._authCode, responseQQ, destQQ,out int onlineStatus) == 0)
			{
				// TODO: 解析过程. 待定

				return (StatusTypes)onlineStatus;
			}
			throw new QQMiniPluginException (13,$"【{responseQQ}】获取“{destQQ}”在线状态获取失败");
		}
		/// <summary>
		/// 获取群组或群组成员的禁言状态.
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要查询是否被禁言群组</param>
		/// <param name="destQQ">要查询是否被禁言群组内的QQ</param>
		/// <returns>禁言状态</returns>
		public bool GetGroupBanStatus (long responseQQ, long destGroup, long destQQ)
		{
			if (QQMiniApi.QMApi_GetGroupBanStatus(this._authCode, responseQQ, destGroup, destQQ,out bool isBan) == 0)
			{
				// TODO: 解析过程. 待定

				return isBan;
			}
			throw new QQMiniPluginException (14,$"【{responseQQ}】获取“{destQQ}”禁言状态失败");
		}

		/// <summary>
		/// 获取指定QQ的好友验证方式.
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要查询其好友验证方式的目标QQ</param>
		/// <returns>好友验证方式</returns>
		public VerifyTypes GetFriendVerifyMode (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_GetFriendVerifyMode(this._authCode, responseQQ, destQQ, out int friendVerify) == 0)
			{
				// TODO: 解析过程. 待定

				return (VerifyTypes)friendVerify;
			}
			throw new QQMiniPluginException (15,$"【{responseQQ}】获取“{destQQ}”好友验证方式失败");
		}
		/// <summary>
		/// 获取指定的QQ是否在线
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要查询其是否在线的目标QQ</param>
		/// <returns>是否在线</returns>
		public bool GetIsOnline (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_GetIsOnline(this._authCode, responseQQ, destQQ ,out bool isOnline) == 0)
			{
				// TODO: 解析过程. 待定

				return isOnline;
			}
			throw new QQMiniPluginException (16,$"【{responseQQ}】获取“{destQQ}”是否在线失败");
		}
		/// <summary>
		/// 获取指定QQ是否接收在线临时消息
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要查询其是否在线的目标QQ</param>
		/// <returns>QQ是否接收在线临时消息</returns>
		public bool GetIsReceiveOnlineTempMessage (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_GetIsReceiveOnlineTempMessage(this._authCode, responseQQ, destQQ, out bool isOnline) == 0)
			{



				return isOnline;
				// TODO: 解析过程. 待定

			}
			throw new QQMiniPluginException (17,$"【{responseQQ}】获取“{destQQ}”是否接收在线临时消息失败");
		}
		/// <summary>
		/// 获取指定讨论组的名称
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destDiscuss">要获取其名称的目标讨论组</param>
		/// <returns>讨论组的名称</returns>
		public string GetDiscussName (long responseQQ, long destDiscuss)
		{
			if (QQMiniApi.QMApi_GetDiscussName(this._authCode, responseQQ, destDiscuss, out IntPtr discussName) == 0)
			{
				string base64Data = discussName.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);



				// TODO: 解析过程. 待定

			}
			throw new QQMiniPluginException (18,$"【{responseQQ}】获取“{destDiscuss}”讨论组的名称失败");
		}
		/// <summary>
		/// 获取指定讨论组的加入链接
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destDiscuss">要获取加入链接的目标讨论组</param>
		/// <returns>讨论组的加入链接</returns>
		public int GetDiscussAddLink (long responseQQ, long destDiscuss)
		{
			if (QQMiniApi.QMApi_GetDiscussAddLink(this._authCode, responseQQ, destDiscuss, out IntPtr discussAddLink) == 0)
			{
				string base64Data = discussAddLink.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);



				// TODO: 解析过程. 待定

			}
			throw new QQMiniPluginException (19,$"【{responseQQ}】获取“{destDiscuss}”讨论组的加入链接失败");
		}
		/// <summary>
		/// 获取收到的群组礼物
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <returns>收到的群组礼物</returns>
		public int GetGroupGiftList (long responseQQ)
		{
			if (QQMiniApi.QMApi_GetGroupGiftList(this._authCode, responseQQ,out IntPtr giftList) == 0)
			{
				string base64Data = giftList.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);



				// TODO: 解析过程. 待定

			}
			throw new QQMiniPluginException (20,$"【{responseQQ}】获取收到的群组礼物失败");
		}
		/// <summary>
		/// 随机获取群礼物(需要Lv5群聊等级).
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup"></param>
		/// <returns>查询到的礼物</returns>
		public int GetRandomGroupGift (long responseQQ, long destGroup)
		{
			if (QQMiniApi.QMApi_GetRandomGroupGift(this._authCode, responseQQ, destGroup, out IntPtr gift) == 0)
			{
				string base64Data = gift.ToString(Global.DefaultEncoding);
				byte[] buffer = Convert.FromBase64String(base64Data);



				// TODO: 解析过程. 待定

			}
			throw new QQMiniPluginException (21,$"【{responseQQ}】获取查询到的礼物失败");
		}
		/// <summary>
		/// 设置一条日志信息到框架
		/// </summary>
		/// <param name="nLevel">类型: 调试(0), 信息(1), 警告(2), 错误(3), 严重错误(4). 若使用严重错误, 会使主程序停止运行</param>
		/// <param name="message">日志的详细信息字符串</param>
		/// <returns>日志的详细信息字符串</returns>
		public int SetLogger (int nLevel, string message)
		{
			GCHandle gCHandle = message.GetStringGCHandle(Global.DefaultEncoding);
			try
            {
				if (QQMiniApi.QMApi_SetLogger(this._authCode, nLevel,gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (22,$"日志信息到框架执行失败");
			}
			finally
            {

				gCHandle.Free();
			}
		}
        /// <summary>
        /// 设置指定QQ的在线状态.
        /// </summary>
        /// <param name="responseQQ">要响应此接口的QQ</param>
        /// <param name="OnlineStatus">在线(1), Q我吧(2), 离开(3), 忙碌(4), 请勿打扰(5), 隐身(6)./param>
        /// <param name="statusMessage">要附加的在线状态信息. 最大255字节</param>
        public bool SetOnlineStatus(long responseQQ, StatusTypes onlineStatus, string statusMessage)
		{
			GCHandle gCHandle = statusMessage.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SetOnlineStatus(this._authCode, responseQQ, (int)onlineStatus, gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (23,$"【{responseQQ}】设置指定QQ的在线状态失败");
			}
			finally
			{

				gCHandle.Free();
			}
		}
		/// <summary>
		/// 设置QQ添加到黑名单列表
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要加入黑名单的目标QQ</param>
		public void SetAddQQToBlacklist (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_SetAddQQToBlacklist(this._authCode, responseQQ, destQQ) == 0)
			{

				// TODO: 解析过程. 待定

			}
			throw new QQMiniPluginException (24,$"【{responseQQ}】设置{destQQ}添加到黑名单列表失败");
		}
		/// <summary>
		/// 设置群组或群组成员禁言
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要禁言的QQ所在的群组</param>
		/// <param name="destQQ">要在群组禁言的QQ</param>
		/// <param name="nTimeSpan">要禁言的时长.单位: 秒, 范围:1 - 2592000(30天). 0为解除禁言</param>
		public void SetGroupBanStatus (long responseQQ, long destGroup, long destQQ, int nTimeSpan)
		{
			if (QQMiniApi.QMApi_SetGroupBanStatus(this._authCode, responseQQ, destGroup, destQQ, nTimeSpan) == 0)
			{

				// TODO: 解析过程. 待定

			}
			throw new QQMiniPluginException (25,$"【{responseQQ}】设置群组或群组成员禁言失败");
		}
		/// <summary>
		/// 设置群组匿名功能状态
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要设置匿名功能的目标群组</param>
		/// <param name="isEnabled">如果此参数为真, 则启动该群的匿名功能. 否则关闭匿名功能. 默认值: 假</param>
		public void SetGroupAnonymousStatus (long responseQQ, long destGroup, bool isEnabled=false)
		{
			if (QQMiniApi.QMApi_SetGroupAnonymousStatus(this._authCode, responseQQ, destGroup, isEnabled) == 0)
			{

				// TODO: 解析过程. 待定


			}
			throw new QQMiniPluginException (26,$"【{responseQQ}】设置群组或群组成员禁言失败");
		}
		/// <summary>
		/// 设置群组屏蔽状态
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要设置屏蔽状态的群组</param>
		/// <param name="isShielded">如果该值为 "真" 屏蔽群消息, 否则为接受并提醒. 默认值: 假</param>
		public void SetGroupShieldedStatus (long responseQQ, long destGroup, bool isShielded)
		{
			if (QQMiniApi.QMApi_SetGroupShieldedStatus(this._authCode, responseQQ, destGroup, isShielded) == 0)
			{

				// TODO: 解析过程. 待定


			}
			throw new QQMiniPluginException (27,$"【{responseQQ}】设置群组屏蔽状态失败");
		}
		/// <summary>
		/// 设置群组管理员
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要设置管理员的群组</param>
		/// <param name="destQQ">要在群组内设置为管理员的QQ</param>
		/// <param name="isManager">是否设置为管理员</param>
		/// <returns>成功返回真,失败返回假</returns>
		public void SetGroupManager (long responseQQ, long destGroup, long destQQ, bool isManager)
		{
			if (QQMiniApi.QMApi_SetGroupManager(this._authCode, responseQQ, destGroup, destQQ, isManager) == 0)
			{

				// TODO: 解析过程. 待定


			}
			throw new QQMiniPluginException (28,$"【{responseQQ}】设置群组屏蔽状态失败");
		}
		/// <summary>
		/// 设置群组成员名片
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要设置群名片的目标群组</param>
		/// <param name="destQQ">要在群组内设置群名片的目标QQ</param>
		/// <param name="NewCard">要设置的新名片</param>
		public void SetGroupMemberCard (long responseQQ, long destGroup, long destQQ, string NewCard)
		{

			GCHandle gCHandle = NewCard.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SetGroupMemberCard(this._authCode, responseQQ, destGroup, destQQ, gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (29,$"【{responseQQ}】设置{destGroup}群组{destQQ}成员名片失败");
			}
			finally
			{

				gCHandle.Free();
			}
		}
		/// <summary>
		/// 设置群组退出(机器人是群主则解散群). 如果成功返回 0, 否则返回负值
		/// </summary>
		public void SetGroupQuit ()
		{
			if (QQMiniApi.QMApi_SetGroupQuit() == 0)
			{

				// TODO: 解析过程. 待定


			}
			throw new QQMiniPluginException (30,$"设置群组退出失败");
		}
		/// <summary>
		///	设置讨论组名称
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destDiscuss">要执行修改名称的目标讨论组</param>
		/// <param name="NewName">要修改的新名称</param>
		public void SetDiscussName (long responseQQ, long destDiscuss, string NewName)
		{
			GCHandle gCHandle = NewName.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SetDiscussName(this._authCode, responseQQ, destDiscuss, gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (31,$"【{responseQQ}】设置{destDiscuss}讨论组{destDiscuss}新名称失败");
			}
			finally
			{

				gCHandle.Free();
			}
		}
		/// <summary>
		/// 设置好友备注
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要执行备注修改的好友QQ</param>
		/// <param name="NewNotes">要修改的新备注</param>
		public void SetFriendNotes (long responseQQ, long destQQ, string NewNotes)
		{
			GCHandle gCHandle = NewNotes.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SetFriendNotes(this._authCode, responseQQ, destQQ, gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (32,$"【{responseQQ}】设置{destQQ}新备注失败");
			}
			finally
			{

				gCHandle.Free();
			}
		}
		/// <summary>
		/// 设置个性签名
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="NewSignature">要修改的新个性签名</param>
		public void SetSignature (long responseQQ, string NewSignature)
		{
			GCHandle gCHandle = NewSignature.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SetSignature(this._authCode, responseQQ, gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (33,$"【{responseQQ}】设置新个性签名失败");
			}
			finally
			{

				gCHandle.Free();
			}
		}
		/// <summary>
		/// 设置性别
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="nGender">要设置的性别值. 男(1),女(2).</param>
		public void SetGender (long responseQQ, GenderTypes nGender)
		{
			if (QQMiniApi.QMApi_SetGender(this._authCode, responseQQ, (int)nGender) == 0)
			{

				// TODO: 解析过程. 待定


			}
			throw new QQMiniPluginException (34,$"【{responseQQ}】设置性别失败");
		}
		/// <summary>
		/// 设置昵称
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="NewNick">要修改的新昵称</param>
		public void SetNick (long responseQQ, string NewNick)
		{
			GCHandle gCHandle = NewNick.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SetNick(this._authCode, responseQQ, gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (35,$"【{responseQQ}】设置新个性签名失败");
			}
			finally
			{

				gCHandle.Free();
			}
		}
		/// <summary>
		/// 设置好友添加请求	
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要处理请求添加好友的目标QQ</param>
		/// <param name="nResponseType">处理该请求的方式. 同意(10). 拒绝(20), 忽略(30). </param>
		/// <param name="AppendMsg">处理请求时的附加信息</param>
		public void SetFriendAddRequest (long responseQQ, long destQQ, ResponseTypes responseType, string AppendMsg)
		{
			GCHandle gCHandle = AppendMsg.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SetFriendAddRequest(this._authCode, responseQQ, destQQ,(int)responseType, gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (36,$"【{responseQQ}】设置{destQQ}好友添加请求失败");
			}
			finally
			{

				gCHandle.Free();
			}
		}
		/// <summary>
		/// 设置群组添加请求
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要处理请求加入的目标群组</param>
		/// <param name="destQQ">要请求处理加入群组的目标QQ</param>
		/// <param name="Seq">从事件处收到的请求标识</param>
		/// <param name="nResponseType">处理该请求的方式. 同意(10). 拒绝(20), 忽略(30). 参考 #RESPONSE_ 常量</param>
		/// <param name="AppendMsg">处理请求时的附加信息</param>
		public void SetGroupAddRequest (long responseQQ, long destGroup, long destQQ, string Seq, ResponseTypes nResponseType, string AppendMsg)
		{
			GCHandle gCHandle = AppendMsg.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle gCHandle1 = Seq.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SetGroupAddRequest(this._authCode, responseQQ, destGroup, destQQ, gCHandle1.AddrOfPinnedObject(), (int)nResponseType, gCHandle.AddrOfPinnedObject()) == 0)
				{

					// TODO: 解析过程. 待定

				}
				throw new QQMiniPluginException (37,$"【{responseQQ}】设置群组{destGroup}的{destQQ}添加请求失败");
			}
			finally
			{

				gCHandle.Free();
				gCHandle1.Free();
			}
		}
		/// <summary>
		/// 发送一条消息
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="sendType">指定消息的发送类型, 参考 #MSG_ 常量</param>
		/// <param name="destTarget">发送到的目标群组或讨论组</param>
		/// <param name="destQQ">发送到的目标QQ</param>
		/// <param name="message">要发送的详细信息</param>
		/// <param name="xmlSubType">基本结构(0), 歌曲结构(2), 其他值不明. 如果是普通消息和JSON消息, 本参数为空</param>
		public void SendMessage (long responseQQ, int sendType, long destTarget, long destQQ, string message, XmlTypes? xmlSubType = null)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int flag=-1;
				if (xmlSubType != null) flag = (int)xmlSubType;
				if( QQMiniApi.QMApi_SendMessage(this._authCode, responseQQ, sendType, destTarget, destQQ, messageHandle.AddrOfPinnedObject(), flag) == 0)
                {

                }
				throw new QQMiniPluginException (38,$"【{responseQQ}】发送一条消息失败");
			}
			finally
			{
				messageHandle.Free ();      // 释放内存
			}
		}
		/// <summary>
		/// 发送一个点赞
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要为其点赞的目标QQ</param>
		/// <param name="count">点赞的次数, 1-10. 默认: 1</param>
		public void SendLike (long responseQQ, long destQQ, int count)
		{
			if (QQMiniApi.QMApi_SendLike(this._authCode, responseQQ, destQQ, count) == 0)
			{

			}
			throw new QQMiniPluginException (39,$"【{responseQQ}】发送一个点赞失败");
		}
		/// <summary>
		/// 向好友发送抖动窗口(移动端为"戳一戳")
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">欲抖动的好友</param>
		public void SendShake (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_SendShake(this._authCode, responseQQ, destQQ) == 0)
			{

			}
			throw new QQMiniPluginException (40,$"【{responseQQ}】向好友{destQQ}发送抖动窗口失败");
		}
		/// <summary>
		/// 向指定群发送群签到
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">欲接收此签到的群组</param>
		/// <param name="placeName">签到地名(Pro可用)</param>
		/// <param name="message">想法发表的内容</param>
		public void SendSignIn (long responseQQ, long destGroup, string placeName, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle messageHandle1 = placeName.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SendSignIn(this._authCode, responseQQ, destGroup, messageHandle1.AddrOfPinnedObject(), messageHandle.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (41,$"【{responseQQ}】发送一条消息失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
				messageHandle1.Free();
			}
		}
		/// <summary>
		/// 向好友发送正在输入状态
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">欲接收此状态的目标QQ</param>
		public void SendInputing (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_SendInputing(this._authCode, responseQQ, destQQ) == 0)
			{

			}
			throw new QQMiniPluginException (42,$"【{responseQQ}】向好友{destQQ}发送正在输入状态失败");
		}
		/// <summary>
		/// 向群组发送一条公告
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要发送公告的目标群组</param>
		/// <param name="notificationTitle">要发送群公告的标题</param>
		/// <param name="notificationContent">要发送群公告的内容</param>
		public void SendGroupNotification (long responseQQ, long destGroup, string notificationTitle, string notificationContent)
		{
			GCHandle messageHandle = notificationTitle.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle messageHandle1 = notificationContent.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SendGroupNotification(this._authCode, responseQQ, destGroup, messageHandle.AddrOfPinnedObject(), messageHandle1.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (43,$"【{responseQQ}】向群组{destGroup}发送一条公告失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
				messageHandle1.Free();
			}
		}
		/// <summary>
		/// 向群组发送一条作业
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要发送作业的目标群组</param>
		/// <param name="workName">作业的名称</param>
		/// <param name="workTitle">作业的标题</param>
		/// <param name="workContent">作业的内容</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendGroupWork (long responseQQ, long destGroup, string workName, string workTitle, string workContent)
		{
			GCHandle messageHandle = workName.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle messageHandle1 = workTitle.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle messageHandle2 = workContent.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SendGroupWork(this._authCode, responseQQ, destGroup, messageHandle.AddrOfPinnedObject(), messageHandle1.AddrOfPinnedObject(), messageHandle2.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (44,$"【{responseQQ}】向群组{destGroup}发送一条公告失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
				messageHandle1.Free();
				messageHandle2.Free();
			}
		}
		/// <summary>
		/// 向群组成员发送群组礼物
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要送出礼物的群组</param>
		/// <param name="destQQ">要接收礼物的目标QQ</param>
		/// <param name="giftPid">要送出的礼物的 PID</param>
		public void SendGroupGift (long responseQQ, long destGroup, long destQQ, string giftPid)
		{
			GCHandle messageHandle = giftPid.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SendGroupGift(this._authCode, responseQQ, destGroup, destQQ, messageHandle.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (45,$"【{responseQQ}】向群组{destGroup}成员{destQQ}发送群组礼物失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
			}
		}
		/// <summary>
		/// 发送群添加请求
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">欲申请加入的群的群号码</param>
		/// <param name="appendMsg">附加的申请消息. 可为空 (需回答正确问题时, 请添加问题的答案)</param>
		public void SendGroupAddRequest (long responseQQ, long destGroup, string appendMsg)
		{
			GCHandle messageHandle = appendMsg.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SendGroupAddRequest(this._authCode, responseQQ, destGroup, messageHandle.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (46,$"【{responseQQ}】向群组{destGroup}发送群添加请求失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
			}
		}
		/// <summary>
		/// 发送好友添加请求
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">欲申请添加的目标QQ</param>
		/// <param name="appendMsg">附加的申请消息. 可为空</param>
		public void SendfriendAddRequest (long responseQQ, long destQQ, string appendMsg)
		{
			GCHandle messageHandle = appendMsg.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_SendFriendAddRequest(this._authCode, responseQQ, destQQ, messageHandle.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (47,$"【{responseQQ}】向{destQQ}发送好友添加请求失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
			}
		}
		/// <summary>
		/// 发送群组邀请请求
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要邀请进入的目标群组</param>
		/// <param name="destQQ">要邀请的目标QQ</param>
		public void SendGroupInviteRequest (long responseQQ, long destGroup, long destQQ)
		{
			if (QQMiniApi.QMApi_SendGroupInviteRequest(this._authCode, responseQQ, destGroup, destQQ) == 0)
			{

			}
			throw new QQMiniPluginException (48,$"【{responseQQ}】从群组{destGroup}向好友{destQQ}发送群组邀请请求失败");
		}
		/// <summary>
		/// 发送讨论组邀请请求
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destDiscuss">要邀请进入的目标讨论组</param>
		/// <param name="destQQ">被邀请进入讨论组的目标QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int SendDiscussInviteRequest (long responseQQ, long destDiscuss, long destQQ)
		{
			if (QQMiniApi.QMApi_SendDiscussInviteRequest(this._authCode, responseQQ, destDiscuss, destQQ) == 0)
			{

			}
			throw new QQMiniPluginException (49,$"【{responseQQ}】从群组{destDiscuss}向好友{destQQ}发送群组邀请请求失败");
		}
		/// <summary>
		/// 接收指定的图片
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="pictureGUID">要接收图片的图片GUID, 例如: {xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx}.qqmini.image</param>
		/// <param name="picturePath">存放接收到图片位于本地服务器的绝对路径. </param>
		public void DownloadPicture (long responseQQ, string pictureGUID, string picturePath)
		{
			GCHandle messageHandle = pictureGUID.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle messageHandle1 = picturePath.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_DownloadPicture(this._authCode, responseQQ, messageHandle.AddrOfPinnedObject(), messageHandle1.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (50,$"【{responseQQ}】接收指定的图片失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
				messageHandle1.Free();
			}
		}
		/// <summary>
		/// 接收指定的语音
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="voiceGUID">要接收语音的语音GUID, 例如: {xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx}.qqmini.voice</param>
		/// <param name="voiceOutFormat">要接收语音的目标语音格式. </param>
		/// <param name="voicePath">存放接收到语音位于本地服务器的绝对路径. </param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int DownloadVoice (long responseQQ, string voiceGUID, VoiceTypes? voiceOutFormat, string voicePath)
		{
			GCHandle messageHandle = voiceGUID.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle messageHandle1 = voicePath.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				int flag = -1;
				if (voiceOutFormat != null) flag = (int)voiceOutFormat;
				if (QQMiniApi.QMApi_DownloadVoice(this._authCode, responseQQ, messageHandle.AddrOfPinnedObject(), flag, messageHandle1.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (51,$"【{responseQQ}】接收指定的语音失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
				messageHandle1.Free();
			}
		}
		/// <summary>
		/// 上传指定的图片
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="picturePath">要上传图片的图片位于本地服务器的绝对路径</param>
		/// <param name="pictureGUID">存放要上传图片的图片 GUID, 该 GUID 用于发送, 发送时图片将会被上传</param>
		public void UploadPicture (long responseQQ, string picturePath, string pictureGUID)
		{
			GCHandle messageHandle = picturePath.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle messageHandle1 = pictureGUID.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_UploadPicture(this._authCode, responseQQ, messageHandle.AddrOfPinnedObject(), messageHandle1.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (52,$"【{responseQQ}】上传指定的图片失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
				messageHandle1.Free();
			}
		}
		/// <summary>
		/// 上传指定的语音
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="voicePath">要上传图片的语音位于本地服务器的绝对路径</param>
		/// <param name="voiceGUID">存放要上传语音的语音 GUID, 该 GUID 用于发送.</param>
		public void UploadVoice (long responseQQ, string voicePath, string voiceGUID)
		{
			GCHandle messageHandle = voicePath.GetStringGCHandle(Global.DefaultEncoding);
			GCHandle messageHandle1 = voiceGUID.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_UploadVoice(this._authCode, responseQQ, messageHandle.AddrOfPinnedObject(), messageHandle1.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (53,$"【{responseQQ}】上传指定的语音失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
				messageHandle1.Free();
			}
		}
		/// <summary>
		/// 上传指定QQ的头像
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="picturePath">要设置的QQ头像位于本地服务器的绝对路径</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int UploadHeadPortraits (long responseQQ, string picturePath)
		{
			GCHandle messageHandle = picturePath.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_UploadHeadPortraits(this._authCode, responseQQ, messageHandle.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (54,$"【{responseQQ}】上传指定QQ的头像失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
			}
		}
		/// <summary>
		/// 上传指定QQ的封面
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="picturePath">要设置的QQ封面位于本地服务器的绝对路径</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int UploadCover (long responseQQ, string picturePath)
		{
			GCHandle messageHandle = picturePath.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_UploadCover(this._authCode, responseQQ, messageHandle.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (55,$"【{responseQQ}】上传指定QQ的封面失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
			}
		}
		/// <summary>
		/// 从黑名单列表中移除QQ
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要移除黑名单的目标QQ</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int RemoveFromBlacklist (long responseQQ, long destQQ)
		{
			return QQMiniApi.QMApi_RemoveFromBlacklist (this._authCode, responseQQ, destQQ);
		}
		/// <summary>
		/// 从好友列表中移除QQ
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要删除的目标QQ</param>
		public void Removefriend (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_RemoveFriend(this._authCode, responseQQ, destQQ) == 0)
			{

			}
			throw new QQMiniPluginException (56,$"【{responseQQ}】好友列表中移除{destQQ}失败");
		}
		/// <summary>
		/// 移除一条消息
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="messageId">要撤回的消息的消息ID</param>
		public void RemoveMessage (long responseQQ, int messageId)
		{
			if (QQMiniApi.QMApi_RemoveMessage(this._authCode, responseQQ, messageId) == 0)
			{

			}
			throw new QQMiniPluginException (57,$"【{responseQQ}】移除{messageId}消息失败");
		}
		/// <summary>
		/// 移除群组成员
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destGroup">要执行群成员移除的群组</param>
		/// <param name="destQQ">要被群组移除的QQ</param>
		/// <param name="isRefuseAccept">指定是否不再接收该QQ的加群申请, 如果为 "真" 则不再接收, 默认为 "假"</param>
		public void RemoveGroupMember (long responseQQ, long destGroup, long destQQ, bool isRefuseAccept=false)
		{
			if (QQMiniApi.QMApi_RemoveGroupMember(this._authCode, responseQQ, destGroup, destQQ, isRefuseAccept) == 0)
			{

			}
			throw new QQMiniPluginException (58,$"【{responseQQ}】从群组{destGroup}移除成员{destQQ}失败");
		}
		/// <summary>
		/// 移除讨论组成员
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destDiscuss">要执行讨论组成员移除的讨论组</param>
		/// <param name="destQQ">要被讨论组移除的QQ</param>
		public void RemoveDiscussMember (long responseQQ, long destDiscuss, long destQQ)
		{
			if (QQMiniApi.QMApi_RemoveDiscussMember(this._authCode, responseQQ, destDiscuss, destQQ) == 0)
			{

			}
			throw new QQMiniPluginException (59,$"【{responseQQ}】从讨论组{destDiscuss}移除成员{destQQ}失败");
		}
		/// <summary>
		/// 创建讨论组
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="destQQ">要邀请进入讨论组的成员QQ</param>
		/// <returns>讨论组ID</returns>
		public long CreateDiscuss (long responseQQ, long destQQ)
		{
			if (QQMiniApi.QMApi_CreateDiscuss(this._authCode, responseQQ, destQQ,out long discussId) == 0)
			{
				return discussId;
			}
			throw new QQMiniPluginException (60,$"【{responseQQ}】创建讨论组并邀请{destQQ}失败");
		}
		/// <summary>
		/// 通过链接加入讨论组.
		/// </summary>
		/// <param name="responseQQ">要响应此接口的QQ</param>
		/// <param name="discussLink">要加入的讨论组的讨论组链接</param>
		/// <returns>成功返回 0, 失败返回负值</returns>
		public int AddDiscussFromLink (long responseQQ, string discussLink)
		{
			GCHandle messageHandle = discussLink.GetStringGCHandle(Global.DefaultEncoding);
			try
			{
				if (QQMiniApi.QMApi_AddDiscussFromLink(this._authCode, responseQQ, messageHandle.AddrOfPinnedObject()) == 0)
				{

				}
				throw new QQMiniPluginException (61,$"【{responseQQ}】通过链接加入讨论组失败");
			}
			finally
			{
				messageHandle.Free();      // 释放内存
			}
		}
		#endregion
	}
}
