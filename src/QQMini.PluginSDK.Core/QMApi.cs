using QQMini.PluginFramework.Utility.Core;
using QQMini.PluginSDK.Core.Model;
using QQMini.PluginInterface.Core;

using System;
using System.Runtime.InteropServices;

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
		private readonly int _authCode;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前调用接口的授权码
		/// </summary>
		public int AuthCode => this._authCode;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMApi"/> 类的新实例
		/// </summary>
		/// <param name="authCode">用于给 QMApi 授权的授权码</param>
		public QMApi (int authCode)
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
				int result = QQMiniApi.QMApi_SendMessage (this._authCode, robotQQ, MSG_FRIEND, 0, sendQQ, messagehandle.AddrOfPinnedObject (), 0);
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
				int result = QQMiniApi.QMApi_SendMessage (this._authCode, robotQQ, MSG_GROUP, sendGroup, 0, messageHandle.AddrOfPinnedObject (), 0);
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
				int result = QQMiniApi.QMApi_SendMessage (this._authCode, robotQQ, MSG_DISUCSS, sendDiscuss, 0, messageHandle.AddrOfPinnedObject (), 0);
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
				int result = QQMiniApi.QMApi_SendMessage (this._authCode, robotQQ, MSG_GROUP_TEMP, fromGroup, sendQQ, messageHandle.AddrOfPinnedObject (), 0);
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
				int result = QQMiniApi.QMApi_SendMessage (this._authCode, robotQQ, MSG_DISCUSS_TEMP, fromDiscuss, sendQQ, messageHandle.AddrOfPinnedObject (), 0);
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
				int result = QQMiniApi.QMApi_SendMessage (this._authCode, robotQQ, MSG_ONLINE_TEMP, 0, sendQQ, messageHandle.AddrOfPinnedObject (), 0);
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
				int result = QQMiniApi.QMApi_SendMessage (this._authCode, robotQQ, MSG_FRIEND_RESPONSE, 0, sendQQ, messageHandle.AddrOfPinnedObject (), 0);
				CheckResultThrowException (result);
				return new Message (0, 0, message);
			}
			finally
			{
				messageHandle.Free ();
			}
		}
		/// <summary>
		/// 设置一条致命错误信息. (注意: 设置后将导致框架停止运行)
		/// </summary>
		/// <param name="code">错误代码</param>
		/// <param name="message">异常消息</param>
		/// <returns>设置成功返回 <see langword="true"/>, 否则返回 <see langword="false"/></returns>
		public bool SetFatal (int code, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				return QQMiniApi.QMApi_SetFatal (this._authCode, code, messageHandle.AddrOfPinnedObject ()) == 0;
			}
			finally
			{
				messageHandle.Free ();
			}

		}
		/// <summary>
		/// 设置一条致命错误信息. (注意: 设置后将导致框架停止运行)
		/// </summary>
		/// <param name="innerException"></param>
		/// <returns>设置成功返回 <see langword="true"/>, 否则返回 <see langword="false"/></returns>
		public bool SetFatal (Exception innerException)
		{
			if (innerException == null)
			{
				return false;
			}

			return this.SetFatal (innerException.HResult, $"{Environment.NewLine}{innerException}");
		}
		#endregion

		#region --私有方法--
		private void CheckResultThrowException (int resultCode)
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
			}
		}
		#endregion
	}
}
