using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含讨论组私聊消息事件数据的类
	/// </summary>
	public class QMDiscussPrivateMessageEventArgs : QMPrivateMessageEventArgs
	{
		#region --属性--
		/// <summary>
		/// 表示当前事件的来源讨论组
		/// </summary>
		public Discuss FromDiscuss { get; set; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMDiscussPrivateMessageEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="fromDiscuss">来源讨论组</param>
		/// <param name="fromQQ">来源QQ</param>
		/// <param name="msgNumber">消息序号</param>
		/// <param name="msgId">消息ID</param>
		/// <param name="message">详细信息</param>
		/// <exception cref="ArgumentOutOfRangeException">参数 robotQQ 或 fromQQ 小于 <see cref="QQ.MinValue"/></exception>
		/// <exception cref="ArgumentNullException">参数 message 为 <see langword="null"/></exception>
		public QMDiscussPrivateMessageEventArgs (int type, int subType, long robotQQ, long fromDiscuss, long fromQQ, long msgNumber, long msgId, IntPtr message)
			: base (type, subType, robotQQ, 0, fromQQ, msgNumber, msgId, message)
		{
			this.FromDiscuss = new Discuss (fromDiscuss);
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 将此实例转换为其等效的字符串表示形式
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return JsonConvert.SerializeObject (this);
		}
		#endregion
	}
}