using QQMini.PluginFramework.Utility.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含私聊消息事件数据的类
	/// </summary>
	public class QMPrivateMessageEventArgs : QMEventArgs
	{
		#region --属性--
		/// <summary>
		/// 指示当前事件的子类型
		/// </summary>
		public QMPrivateMessageEventSubTypes SubType { get; }
		/// <summary>
		/// 指示当前事件的来源QQ
		/// </summary>
		public QQ FromQQ { get; }
		/// <summary>
		/// 指示当前事件的消息
		/// </summary>
		public Message Message { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMPrivateMessageEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="_"></param>
		/// <param name="fromQQ">来源QQ</param>
		/// <param name="msgNumber">消息序号</param>
		/// <param name="msgId">消息ID</param>
		/// <param name="message">详细信息</param>
		/// <exception cref="ArgumentOutOfRangeException">参数 robotQQ 或 fromQQ 小于 <see cref="QQ.MinValue"/></exception>
		/// <exception cref="ArgumentNullException">参数 message 为 <see langword="null"/></exception>
		public QMPrivateMessageEventArgs (int type, int subType, long robotQQ, long _, long fromQQ, long msgNumber, int msgId, IntPtr message)
			: base (type, robotQQ)
		{
			SubType = (QMPrivateMessageEventSubTypes)subType;
			FromQQ = new QQ (fromQQ);
			Message = new Message (msgId, msgNumber, message.ToString (Global.DefaultEncoding));
		}
		#endregion
	}
}
