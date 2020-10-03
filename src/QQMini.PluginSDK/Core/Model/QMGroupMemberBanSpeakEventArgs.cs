using QQMini.PluginFramework.Utility.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示包含群组成员禁言事件数据的类
	/// </summary>
	public class QMGroupMemberBanSpeakEventArgs : QMEventArgs
	{
		#region --属性--
		/// <summary>
		/// 指示当前事件的子类型
		/// </summary>
		public QMGroupMemberBanSpeakEventSubTypes SubType { get; }
		/// <summary>
		/// 指示当前事件的来源群号
		/// </summary>
		public Group FromGroup { get; }
		/// <summary>
		/// 指示当前事件的被禁言QQ
		/// </summary>
		public QQ FromQQ { get; }
		/// <summary>
		/// 指示当前事件的设置或解除禁言的管理者QQ
		/// </summary>
		public QQ OperateQQ { get; }
		/// <summary>
		/// 指示当前事件设置禁言的时长. (如果 <see cref="SubType"/> 是 <see cref="QMGroupMemberBanSpeakEventSubTypes.GroupMemberRemoveBanSpeak"/> 则为 <see langword="null"/>)
		/// </summary>
		public TimeSpan? BanSpeakTimeSpan { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QMGroupMemberBanSpeakEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="type">事件类型</param>
		/// <param name="subType">事件子类型</param>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="fromGroup">来源群组</param>
		/// <param name="fromQQ">来源QQ</param>
		/// <param name="operateQQ">操作QQ</param>
		/// <param name="banTime">禁言时长</param>
		public QMGroupMemberBanSpeakEventArgs (int type, int subType, long robotQQ, long fromGroup, long fromQQ, long operateQQ, int banTime)
			: base (type, robotQQ)
		{
			SubType = (QMGroupMemberBanSpeakEventSubTypes)subType;
			FromGroup = new Group (fromGroup);
			FromQQ = new QQ (fromQQ);
			OperateQQ = new QQ (operateQQ);
			if (this.SubType == QMGroupMemberBanSpeakEventSubTypes.GroupMemberSetBanSpeak)
			{
				BanSpeakTimeSpan = new TimeSpan? (new TimeSpan (banTime * 10000000L));
			}
		}
		#endregion
	}
}
