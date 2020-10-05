using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示在 QQMini 插件执行过程中发生的授权码小于0的错误.
	/// </summary>
	[Serializable]
	public class QMAuthCodeLessThanZeroException : QMException
	{
		#region --属性--
		/// <summary>
		/// 获取导致当前异常的错误授权码
		/// </summary>
		public int ErrorAuthCode { get; }
		/// <summary>
		/// 获取描述当前异常的消息
		/// </summary>
		public override string Message => $"接收到的授权码无效. 错误的授权码: {this.ErrorAuthCode}";
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMAuthCodeLessThanZeroException"/> 类的新实例
		/// </summary>
		/// <param name="authCode">错误的授权码</param>
		public QMAuthCodeLessThanZeroException (int authCode)
			: base (QMExceptionCodes.AuthCodeLessThanZero)
		{
			ErrorAuthCode = authCode;
		}
		/// <summary>
		/// 用序列化数据初始化 <see cref="QMAuthCodeLessThanZeroException"/> 类的新实例
		/// </summary>
		/// <param name="info"><see cref="SerializationInfo"/>，它保存关于所引发异常的序列化对象数据</param>
		/// <param name="context"><see cref="StreamingContext"/>，它包含关于源或目标的上下文信息</param>
		protected QMAuthCodeLessThanZeroException (SerializationInfo info, StreamingContext context)
			: base (info, context)
		{
		}
		#endregion
	}
}
