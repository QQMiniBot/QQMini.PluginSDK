using QQMini.PluginFramework.Utility.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含群组成员名片改变事件数据的类
	/// </summary>
	public class QMGroupMemberCardChangeEventArgs : QMEventArgs
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
		/// <summary>
		/// 指示当前事件的新名片
		/// </summary>
		public string NewCard { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMGroupMemberCardChangeEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="fromGroup">来源群组</param>
		/// <param name="fromQQ">来源QQ</param>
		/// <param name="newCard">新名片</param>
		public QMGroupMemberCardChangeEventArgs (int type, int subType, long robotQQ, long fromGroup, long fromQQ, IntPtr newCard)
			: base (type, robotQQ)
		{
			SubType = (QMGroupManagerChangeEventSubTypes)subType;
			FromGroup = new Group (fromGroup);
			FromQQ = new QQ (fromQQ);
			NewCard = newCard.ToString (Global.DefaultEncoding);
		}
		#endregion
	}
}
