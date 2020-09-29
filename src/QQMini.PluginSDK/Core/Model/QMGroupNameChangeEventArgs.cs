using QQMini.PluginFramework.Utility.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含群组名称改变事件数据的类
	/// </summary>
	public class QMGroupNameChangeEventArgs : QMEventArgs
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
		/// 指示当前事件的新名片
		/// </summary>
		public string NewCard { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMGroupNameChangeEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="fromGroup">来源群组</param>
		/// <param name="newCard">新名片</param>
		public QMGroupNameChangeEventArgs (int type, int subType, long robotQQ, long fromGroup, IntPtr newCard)
			: base (type, robotQQ)
		{
			SubType = (QMGroupManagerChangeEventSubTypes)subType;
			FromGroup = new Group (fromGroup);
			NewCard = newCard.ToString (Global.DefaultEncoding);
		}
		#endregion
	}
}
