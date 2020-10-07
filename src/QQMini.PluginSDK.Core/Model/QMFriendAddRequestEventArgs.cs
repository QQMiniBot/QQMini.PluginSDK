using QQMini.PluginFramework.Utility.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含好友添加请求事件数据的类
	/// </summary>
	public class QMFriendAddRequestEventArgs : QMEventArgs
	{
		#region --属性--
		/// <summary>
		/// 指示当前事件的子类型
		/// </summary>
		public QMFriendAddRequestEventSubTypes SubType { get; }
		/// <summary>
		/// 指示当前事件的来源QQ
		/// </summary>
		public QQ FromQQ { get; }
		/// <summary>
		/// 指示当前事件的附加消息
		/// </summary>
		public string AppendMessage { get; }
		/// <summary>
		/// 指示当前事件的请求
		/// </summary>
		public Request Request { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMFriendAddRequestEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="fromQQ">来源QQ</param>
		/// <param name="appendMsg">附加的验证消息</param>
		/// <param name="responseFlag">响应标识</param>
		/// <exception cref="ArgumentOutOfRangeException">参数 robotQQ 或 fromQQ 小于 <see cref="QQ.MinValue"/></exception>
		/// <exception cref="ArgumentNullException">参数 appendMsg 或 responseFlag 为 <see langword="null"/></exception>
		public QMFriendAddRequestEventArgs (int type, int subType, long robotQQ, long fromQQ, IntPtr appendMsg, IntPtr responseFlag)
			: base (type, robotQQ)
		{
			this.SubType = (QMFriendAddRequestEventSubTypes)subType;
			this.FromQQ = new QQ (fromQQ);
			this.AppendMessage = appendMsg.ToString (Global.DefaultEncoding);
			this.Request = new Request (responseFlag.ToString (Global.DefaultEncoding));
		}
		#endregion
	}
}
