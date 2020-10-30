using QQMini.PluginFramework.Utility.Core;
using QQMini.PluginInterface.Core;
using QQMini.PluginSDK.Core.Model;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Runtime.InteropServices;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 提供 QQMini 应用程序日志的调用实现
	/// </summary>
	[Serializable]
	public sealed class QMLog
	{
		#region --字段--
		private readonly int _authCode;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前程序域的 <see cref="QMLog"/> 实例
		/// </summary>
		public static QMLog CurrentApi => (QMLog)MemoryCache.Default.Get ($"QMLOG{AppDomain.CurrentDomain.Id}");
		/// <summary>
		/// 获取当前调用接口的授权码
		/// </summary>
		public int AuthCode => this._authCode;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMLog"/> 类的新实例
		/// </summary>
		/// <param name="authCode">用于给 QMLog 授权的授权码</param>
		private QMLog (int authCode)
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
		/// 创建一个新的 <see cref="QMLog"/> 接口实例
		/// </summary>
		/// <param name="authCode">与此实例相关联的授权码</param>
		/// <returns>如果成功创建新实例, 则返回 <see cref="QMApi"/>对象</returns>
		internal static QMLog CreateNew (int authCode)
		{
			QMLog log = new QMLog (authCode);
			MemoryCache.Default.Add ($"QMLOG{AppDomain.CurrentDomain.Id}", log, new CacheItemPolicy ()
			{
				AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration,
				Priority = CacheItemPriority.NotRemovable,
				SlidingExpiration = ObjectCache.NoSlidingExpiration
			});
			return log;
		}
		/// <summary>
		/// 销毁一个指定的 <see cref="QMLog"/> 接口实例
		/// </summary>
		internal static void Destroy ()
		{
			MemoryCache.Default.Remove ($"QMLOG{AppDomain.CurrentDomain.Id}");
		}
		/// <summary>
		/// 设置一条指定等级的日志信息到框架
		/// </summary>
		/// <param name="level">设置日志的等级</param>
		/// <param name="message">日志的详细信息</param>
		public void Log (LogLevel level, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				int result = QQMiniApi.QMApi_SetLogger (this.AuthCode, (int)level, messageHandle.AddrOfPinnedObject ());
				CheckResultThrowException (result);
			}
			finally
			{
				messageHandle.Free ();
			}
		}
		/// <summary>
		/// 设置一条 "调试" 级别的日志信息到框架
		/// </summary>
		/// <param name="message">日志的详细信息</param>
		public void Debug (string message)
		{
			this.Log (LogLevel.Debug, message);
		}
		/// <summary>
		/// 设置一条 "信息" 级别的日志信息到框架
		/// </summary>
		/// <param name="message">日志的详细信息</param>
		public void Info (string message)
		{
			this.Log (LogLevel.Infomaction, message);
		}
		/// <summary>
		/// 设置一条 "警告" 级别的日志信息到框架
		/// </summary>
		/// <param name="message">日志的详细信息</param>
		public void Warning (string message)
		{
			this.Log (LogLevel.Warning, message);
		}
		/// <summary>
		/// 设置一条 "错误" 级别的日志信息到框架
		/// </summary>
		/// <param name="message">日志的详细信息</param>
		public void Error (string message)
		{
			this.Log (LogLevel.Error, message);
		}
		/// <summary>
		/// 设置一条致命错误信息. (注意: 设置后将导致框架停止运行)
		/// </summary>
		/// <param name="code">错误代码</param>
		/// <param name="message">异常消息</param>
		/// <returns>设置成功返回 <see langword="true"/>, 否则返回 <see langword="false"/></returns>
		public bool Fatal (int code, string message)
		{
			GCHandle messageHandle = message.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				return QQMiniApi.QMApi_SetFatal (this.AuthCode, code, messageHandle.AddrOfPinnedObject ()) == 0;
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
		public bool Fatal (Exception innerException)
		{
			if (innerException == null)
			{
				return false;
			}

			return this.Fatal (innerException.HResult, $"{Environment.NewLine}{innerException}");
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
				case QMExceptionCodes.LoggerLevelNotFound: throw new QMLoggerLevelNotFountException ();
				case QMExceptionCodes.LoggerMessageIsEmpty: throw new QMLoggerMessageIsEmptyException ();
			}
		}
		#endregion
	}
}
