using QQMini.PluginFramework.Utility.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含被好友删除事件数据的类
	/// </summary>
	public class QMBeFriendDeleteEventArgs : QMEventArgs
	{
		#region --属性--
		/// <summary>
		/// 指示当前事件的子类型
		/// </summary>
		public QMBeFriendDeleteEventSubTypes SubType { get; }
		/// <summary>
		/// 指示当前事件的来源QQ
		/// </summary>
		public QQ FromQQ { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMBeFriendDeleteEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="fromQQ">来源QQ</param>
		/// <param name="appendMessage">附加消息</param>
		public QMBeFriendDeleteEventArgs (int type, int subType, long robotQQ, long fromQQ, IntPtr appendMessage)
			: base (type, robotQQ)
		{
			SubType = (QMBeFriendDeleteEventSubTypes)subType;
			FromQQ = new QQ (fromQQ);
		}
		#endregion
	}
}
