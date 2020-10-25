using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 异常代码的枚举
	/// </summary>
	[Serializable]
	public enum QMExceptionCodes
	{
		/// <summary>
		/// 指示 AuthCode 的值不正确
		/// </summary>
		AuthCodeLessThanZero = -1,
		/// <summary>
		/// 指示传递给接口的 AuthCode 无效
		/// </summary>
		AuthCodeInvalid = -100,
		/// <summary>
		/// 指示当前插件未被启用
		/// </summary>
		PlugiNotEnable = -101,
		/// <summary>
		/// 指示响应QQ找不到
		/// </summary>
		ResponseQQNotFound = -102,
		/// <summary>
		/// 指示发送类型错误
		/// </summary>
		SendTypeError = -103,
		/// <summary>
		/// 指示发送群组或讨论组为空
		/// </summary>
		SendGroupOrDiscussIsEmpty = -104,
		/// <summary>
		/// 指示发送QQ为空
		/// </summary>
		SendQQIsEmpty = -105,
		/// <summary>
		/// 指示发送内容为空
		/// </summary>
		SendContentIsEmpty = -106,
		/// <summary>
		/// 发送QQ不支持临时消息
		/// </summary>
		SendQQNotSupportTempMessage = -107,
		/// <summary>
		/// 未收到发送QQ响应消息
		/// </summary>
		NotReceiveSendQQResponseMessage = -108,
		/// <summary>
		/// 日志等级找不到
		/// </summary>
		LoggerLevelNotFound = -109,
		/// <summary>
		/// 日志信息是空
		/// </summary>
		LoggerMessageIsEmpty = -110,
		/// <summary>
		/// 未知的框架类型
		/// </summary>
		UnknownFrameworkType = -111,
		/// <summary>
		/// 群组未找到
		/// </summary>
		GroupNotFound = -112,
		/// <summary>
		/// QQ未找到
		/// </summary>
		QQNotFound = -113,
	}
}
