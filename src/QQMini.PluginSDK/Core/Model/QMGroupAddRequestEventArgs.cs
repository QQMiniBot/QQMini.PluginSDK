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
	public class QMGroupAddRequestEventArgs : QMEventArgs
	{
		#region --属性--
		/// <summary>
		/// 指示当前事件的子类型
		/// </summary>
		public QMGroupAddRequestEventSubTypes SubType { get; }
		/// <summary>
		/// 指示当前事件的来源群号
		/// </summary>
		public Group FromGroup { get; }
		/// <summary>
		/// 指示当前事件的来源QQ
		/// </summary>
		public QQ FromQQ { get; }
		/// <summary>
		/// 指示当前事件的操作QQ
		/// </summary>
		public QQ OperateQQ { get; }
		/// <summary>
		/// 指示当前事件的请求
		/// </summary>
		public Request Request { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMGroupAddRequestEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="fromGroup">来源群组</param>
		/// <param name="fromQQ">来源QQ</param>
		/// <param name="operateQQ">操作QQ</param>
		/// <param name="responseFlag">反馈标识</param>
		public QMGroupAddRequestEventArgs (int type, int subType, long robotQQ, long fromGroup, long fromQQ, long operateQQ, IntPtr responseFlag)
			: base (type, robotQQ)
		{
			SubType = (QMGroupAddRequestEventSubTypes)subType;
			FromGroup = new Group (fromGroup);
			FromQQ = new QQ (fromQQ);
			OperateQQ = new QQ (operateQQ);
			Request = new Request (responseFlag.ToString (Global.DefaultEncoding));
		}
		#endregion
	}
}
