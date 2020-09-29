using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QQMini.PluginSDK.Core.Model;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含 QQMini 事件数据的类的基类，并提供用于不包含事件数据的事件的值
	/// </summary>
	public class QMEventArgs : EventArgs
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的事件类型
		/// </summary>
		public QMEventTypes Type { get; }
		/// <summary>
		/// 获取接收到当前事件的机器人QQ
		/// </summary>
		public QQ RobotQQ { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="robotQQ">接收当前事件的机器人QQ</param>
		/// <exception cref="ArgumentOutOfRangeException">参数 robotQQ 小于 <see cref="QQ.MinValue"/></exception>
		public QMEventArgs (int type, long robotQQ)
		{
			this.Type = (QMEventTypes)type;
			this.RobotQQ = new QQ (robotQQ);
		}
		#endregion
	}
}
