using QQMini.PluginFramework.Utility.Core;
using QQMini.PluginSDK.Core.Model;
using QQMini.PluginInterface.Core;

using System;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 提供 QQMini 应用程序公开接口的调用实现
	/// </summary>
	[Serializable]
	public sealed class QMApi
	{
		#region --常量--
		const int MSG_FRIEND = 1;
		const int MSG_GROUP = 2;
		const int MSG_DISUCSS = 3;
		const int MSG_GROUP_TEMP = 4;
		const int MSG_DISCUSS_TEMP = 5;
		const int MSG_ONLINE_TEMP = 6;
		const int MSG_FRIEND_RESPONSE = 7;
		#endregion

		#region --字段--
		private static readonly ConcurrentDictionary<int, QMApi> _caches;
		private readonly int _authCode;
		private int _id;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前程序域的 <see cref="QMApi"/> 实例
		/// </summary>
		public static QMApi CurrentApi
		{
			get
			{
				if (!_caches.ContainsKey (AppDomain.CurrentDomain.Id))
				{
					return null;
				}

				return _caches[AppDomain.CurrentDomain.Id];
			}
		}
		/// <summary>
		/// 获取当前实例的唯一标识
		/// </summary>
		public int Id => _id;
		/// <summary>
		/// 获取当前调用接口的授权码
		/// </summary>
		public int AuthCode => this._authCode;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMApi"/> 静态实例
		/// </summary>
		static QMApi ()
		{
			_caches = new ConcurrentDictionary<int, QMApi> ();
		}
		/// <summary>
		/// 初始化 <see cref="QMApi"/> 类的新实例
		/// </summary>
		/// <param name="authCode">用于给 QMApi 授权的授权码</param>
		private QMApi (int authCode)
		{
			if (authCode <= 0)
			{
				throw new QMAuthCodeLessThanZeroException (authCode);
			}
			this._authCode = authCode;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 创建一个新的 <see cref="QMApi"/> 接口实例
		/// </summary>
		/// <param name="authCode">与此实例相关联的授权码</param>
		/// <returns>如果成功创建新实例, 则返回 <see cref="QMApi"/>对象</returns>
		internal static QMApi CreateNew (int authCode)
		{
			QMApi api = new QMApi (authCode)
			{
				_id = AppDomain.CurrentDomain.Id
			};
			return _caches.AddOrUpdate (api.Id, api, (key, value) => value = api);
		}
		/// <summary>
		/// 销毁一个指定的 <see cref="QMApi"/> 接口实例
		/// </summary>
		/// <param name="api">要销毁的接口实例</param>
		internal static void Destroy (QMApi api)
		{
			while (!_caches.TryRemove (api.Id, out QMApi _)) ;
		}
		/// <summary>
		/// 获取当前 QQMini 框架的框架类型
		/// </summary>
		/// <returns>如果获取成功返回 <see cref="QQMiniFrameworkTypes"/> 枚举的值</returns>
		public QQMiniFrameworkTypes GetFrameworkType ()
		{
			int result = QQMiniApi.QMApi_GetFrameType (this.AuthCode);
			CheckResultThrowException (result);
			return (QQMiniFrameworkTypes)result;
		}
		/// <summary>
		/// 获取当前 QQMini 框架的框架版本号
		/// </summary>
		/// <returns>如果获取成功返回表示框架版本号的 <see cref="Version"/> 对象</returns>
		public Version GetFrameworkVersion ()
		{
			int result = QQMiniApi.QMApi_GetFrameVersion (this.AuthCode, out IntPtr version);
			CheckResultThrowException (result);
			return Version.Parse (version.ToString (Global.DefaultEncoding));
		}
		/// <summary>
		/// 获取当前 QQMini 框架的时间戳
		/// </summary>
		/// <returns>如果获取成功返回以 "秒" 为单位的时间戳</returns>
		public long GetFrameworkTimpStmap ()
		{
			long result = QQMiniApi.QMApi_GetFrameTimeStamp (this.AuthCode);
			CheckResultThrowException (result);
			return result;
		}
		/// <summary>
		/// 获取当前插件的数据目录
		/// </summary>
		/// <returns>如果获取成功返回数据目录</returns>
		public string GetPluginDataDirectory ()
		{
			int result = QQMiniApi.QMApi_GetPluginDataDirectory (this.AuthCode, out IntPtr szDirectory);
			CheckResultThrowException (result);
			return szDirectory.ToString (Global.DefaultEncoding);
		}
		/// <summary>
		/// 向指定的指定的QQ好友发送一条消息
		/// </summary>
		/// <param name="robotQQ">响应此请求的QQ</param>
		/// <param name="sendQQ">接收消息的目标QQ</param>
		/// <param name="message">要发送的消息内容</param>
		/// <returns>返回发送的消息 <see cref="Message"/> 实例</returns>
		public Message SendFriendMessage (long robotQQ, long sendQQ, string message)
		{
			GCHandle messagehandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int result = QQMiniApi.QMApi_SendMessage (this.AuthCode, robotQQ, MSG_FRIEND, 0, sendQQ, messagehandle.AddrOfPinnedObject (), 0);
				CheckResultThrowException (result);
				return new Message (0, 0, message);
			}
			finally
			{
				messagehandle.Free ();
			}
		}
		/// <summary>
		/// 向指定的群组发送一条消息
		/// </summary>
		/// <param name="robotQQ">响应此请求的QQ</param>
		/// <param name="sendGroup">接收消息的目标群组</param>
		/// <param name="message">要发送的消息内容</param>
		/// <returns>返回发送的消息 <see cref="Message"/> 实例</returns>
		public Message SendGroupMessage (long robotQQ, long sendGroup, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int result = QQMiniApi.QMApi_SendMessage (this.AuthCode, robotQQ, MSG_GROUP, sendGroup, 0, messageHandle.AddrOfPinnedObject (), 0);
				CheckResultThrowException (result);
				return new Message (0, 0, message);
			}
			finally
			{
				messageHandle.Free ();
			}
		}
		/// <summary>
		/// 向指定的讨论组发送一条消息
		/// </summary>
		/// <param name="robotQQ">响应此请求的QQ</param>
		/// <param name="sendDiscuss">接收消息的目标讨论组</param>
		/// <param name="message">要发送的消息内容</param>
		/// <returns>返回发送的消息 <see cref="Message"/> 实例</returns>
		public Message SendDiscussMessage (long robotQQ, long sendDiscuss, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int result = QQMiniApi.QMApi_SendMessage (this.AuthCode, robotQQ, MSG_DISUCSS, sendDiscuss, 0, messageHandle.AddrOfPinnedObject (), 0);
				CheckResultThrowException (result);
				return new Message (0, 0, message);
			}
			finally
			{
				messageHandle.Free ();
			}
		}
		/// <summary>
		/// 向指定的QQ发送一条群组临时消息
		/// </summary>
		/// <param name="robotQQ">响应此请求的QQ</param>
		/// <param name="fromGroup">目标QQ所在的群组</param>
		/// <param name="sendQQ">接收消息的目标QQ</param>
		/// <param name="message">要发送的消息内容</param>
		/// <returns>返回发送的消息 <see cref="Message"/> 实例</returns>
		public Message SendGroupTempMessage (long robotQQ, long fromGroup, long sendQQ, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int result = QQMiniApi.QMApi_SendMessage (this.AuthCode, robotQQ, MSG_GROUP_TEMP, fromGroup, sendQQ, messageHandle.AddrOfPinnedObject (), 0);
				CheckResultThrowException (result);
				return new Message (0, 0, message);
			}
			finally
			{
				messageHandle.Free ();
			}
		}
		/// <summary>
		/// 向指定的QQ发送一条讨论组临时消息
		/// </summary>
		/// <param name="robotQQ">响应此请求的QQ</param>
		/// <param name="fromDiscuss">目标QQ所在的群组</param>
		/// <param name="sendQQ">接收消息的目标QQ</param>
		/// <param name="message">要发送的消息内容</param>
		/// <returns>返回发送的消息 <see cref="Message"/> 实例</returns>
		public Message SendDiscussTempMessage (long robotQQ, long fromDiscuss, long sendQQ, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int result = QQMiniApi.QMApi_SendMessage (this.AuthCode, robotQQ, MSG_DISCUSS_TEMP, fromDiscuss, sendQQ, messageHandle.AddrOfPinnedObject (), 0);
				CheckResultThrowException (result);
				return new Message (0, 0, message);
			}
			finally
			{
				messageHandle.Free ();
			}
		}
		/// <summary>
		/// 向指定的QQ发送一条在线临时消息
		/// </summary>
		/// <param name="robotQQ">响应此请求的QQ</param>
		/// <param name="sendQQ">接收消息的目标QQ</param>
		/// <param name="message">要发送的消息内容</param>
		/// <returns>返回发送的消息 <see cref="Message"/> 实例</returns>
		public Message SendOnlineTempMessage (long robotQQ, long sendQQ, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int result = QQMiniApi.QMApi_SendMessage (this.AuthCode, robotQQ, MSG_ONLINE_TEMP, 0, sendQQ, messageHandle.AddrOfPinnedObject (), 0);
				CheckResultThrowException (result);
				return new Message (0, 0, message);
			}
			finally
			{
				messageHandle.Free ();
			}
		}
		/// <summary>
		/// 向指定的QQ发送好友验证回应消息
		/// </summary>
		/// <param name="robotQQ">响应此请求的QQ</param>
		/// <param name="sendQQ">接收消息的目标QQ</param>
		/// <param name="message">要发送的消息内容</param>
		/// <returns>返回发送的消息 <see cref="Message"/> 实例</returns>
		public Message SendFriendResponseMessage (long robotQQ, long sendQQ, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int result = QQMiniApi.QMApi_SendMessage (this.AuthCode, robotQQ, MSG_FRIEND_RESPONSE, 0, sendQQ, messageHandle.AddrOfPinnedObject (), 0);
				CheckResultThrowException (result);
				return new Message (0, 0, message);
			}
			finally
			{
				messageHandle.Free ();
			}
		}
		/// <summary>
		/// 获取指定QQ用于操作网页的 Cookies
		/// </summary>
		/// <param name="robotQQ">要获取 Cookies 的QQ号</param>
		/// <returns>用于操作网页的 Cookies</returns>
		public string GetCookies (long robotQQ)
		{
			int result = QQMiniApi.QMApi_GetCookies (this.AuthCode, robotQQ, out IntPtr cookiesStr);
			CheckResultThrowException (result);

			return cookiesStr.ToString (Global.DefaultEncoding);
		}
		/// <summary>
		/// 获取指定QQ用于操作网页的 G_tk 或 bkn 值
		/// </summary>
		/// <param name="robotQQ">要获取 G_tk 或 bkn 值的QQ号</param>
		/// <returns>用于操作网页的 Cookies</returns>
		public string GetBkn (long robotQQ)
		{
			int result = QQMiniApi.QMApi_GetBkn (this.AuthCode, robotQQ, out IntPtr bkn);
			CheckResultThrowException (result);
			return bkn.ToString (Global.DefaultEncoding);
		}
		/// <summary>
		/// 获取指定QQ号的QQ在线状态
		/// </summary>
		/// <param name="robotQQ">用来获取在线状态的QQ号</param>
		/// <param name="targetQQ">要获取其在线状态的QQ号</param>
		/// <returns>QQ在线状态的枚举</returns>
		public OnlineStatusTypes GetOnlineStatus (long robotQQ, long targetQQ)
		{
			int result = QQMiniApi.QMApi_GetOnlineStatus (this.AuthCode, robotQQ, targetQQ, out int status);
			CheckResultThrowException (result);
			return (OnlineStatusTypes)status;
		}
		/// <summary>
		/// 获取指定群组禁言的状态
		/// </summary>
		/// <param name="robotQQ">用来获取在线状态的QQ号</param>
		/// <param name="targetGroup">要获取其禁言状态的群组</param>
		/// <returns>如果群组处于禁言状态返回 <see langword="true"/>; 否则返回 <see langword="false"/></returns>
		public bool GetGroupBanStatus (long robotQQ, long targetGroup)
		{
			int result = QQMiniApi.QMApi_GetGroupBanStatus (this.AuthCode, robotQQ, targetGroup, 0, out bool isBan);
			CheckResultThrowException (result);
			return isBan;
		}
		/// <summary>
		/// 获取指定群组成员禁言的状态
		/// </summary>
		/// <param name="robotQQ">用来获取在线状态的QQ号</param>
		/// <param name="targetGroup">要获取其禁言状态的群组</param>
		/// <param name="targetQQ">要获取其禁言状态的QQ号</param>
		/// <returns>如果群组处于禁言状态返回 <see langword="true"/>; 否则返回 <see langword="false"/></returns>
		public bool GetGroupMemberBanStatus (long robotQQ, long targetGroup, long targetQQ)
		{
			int result = QQMiniApi.QMApi_GetGroupBanStatus (this.AuthCode, robotQQ, targetGroup, targetQQ, out bool isBan);
			CheckResultThrowException (result);
			return isBan;
		}
		/// <summary>
		/// 获取指定QQ的好友验证方式
		/// </summary>
		/// <returns>好友验证方式的枚举</returns>
		public FriendVerifyTypes GetFriendVerifyMode (long robotQQ, long targetQQ)
		{
			int result = QQMiniApi.QMApi_GetFriendVerifyMode (this.AuthCode, robotQQ, targetQQ, out int friendVerify);
			CheckResultThrowException (result);
			return (FriendVerifyTypes)friendVerify;
		}
		/// <summary>
		/// 获取指定QQ是否在线
		/// </summary>
		/// <param name="robotQQ">要用来获取在线状态的QQ号</param>
		/// <param name="targetQQ">要获取其是否在线的QQ号</param>
		/// <returns>如果指定的QQ是在线的, 返回 <see langword="true"/>; 否则返回 <see langword="false"/></returns>
		public bool GetIsOnline (long robotQQ, long targetQQ)
		{
			int result = QQMiniApi.QMApi_GetIsOnline (this.AuthCode, robotQQ, targetQQ, out bool isOnline);
			CheckResultThrowException (result);
			return isOnline;
		}
		#endregion

		#region --私有方法--
		private void CheckResultThrowException (long resultCode)
		{
			if (resultCode >= 0)
				return;

			switch ((QMExceptionCodes)resultCode)
			{
				case QMExceptionCodes.AuthCodeInvalid: throw new QMAuthCodeInvalidException ();
				case QMExceptionCodes.PlugiNotEnable: throw new QMPluginNotEnableException ();
				case QMExceptionCodes.ResponseQQNotFound: throw new QMResponseQQNotFoundException ();
				case QMExceptionCodes.SendTypeError: throw new QMSendTypeErrorException ();
				case QMExceptionCodes.SendGroupOrDiscussIsEmpty: throw new QMSendGroupOrDiscussIsEmptyException ();
				case QMExceptionCodes.SendQQIsEmpty: throw new QMSendQQIsEmptyException ();
				case QMExceptionCodes.SendContentIsEmpty: throw new QMSendContentIsEmptyException ();
				case QMExceptionCodes.SendQQNotSupportTempMessage: throw new QMSendQQNotSupportTempMessageException ();
				case QMExceptionCodes.NotReceiveSendQQResponseMessage: throw new QMNotReceiveSendQQResponseMessageException ();
				case QMExceptionCodes.UnknownFrameworkType: throw new QMUnknownFrameworkTypeException ();
				case QMExceptionCodes.GroupNotFound: throw new QMGroupNotFoundException ();
				case QMExceptionCodes.QQNotFound: throw new QMQQNotFoundException ();
			}
		}
		#endregion
	}
}
