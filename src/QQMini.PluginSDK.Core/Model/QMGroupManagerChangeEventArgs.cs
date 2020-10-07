using QQMini.PluginFramework.Utility.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含群组管理员改变事件数据的类
	/// </summary>
	public class QMGroupManagerChangeEventArgs : QMEventArgs
	{
		#region --属性--
		/// <summary>
		/// 指示当前事件的子类型
		/// </summary>
		public QMGroupManagerChangeEventSubTypes SubType { get; }
		/// <summary>
		/// 指示当前事件的来源群号
		/// </summary>
		public Group FromGroup { get; }
		/// <summary>
		/// 指示当前事件的来源QQ
		/// </summary>
		public QQ FromQQ { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMGroupManagerChangeEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="fromGroup">来源群组</param>
		/// <param name="fromQQ">来源QQ</param>
		public QMGroupManagerChangeEventArgs (int type, int subType, long robotQQ, long fromGroup, long fromQQ)
			: base (type, robotQQ)
		{
			SubType = (QMGroupManagerChangeEventSubTypes)subType;
			FromGroup = new Group (fromGroup);
			FromQQ = new QQ (fromQQ);
		}
		#endregion
	}
}
