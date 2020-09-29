using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQMini 框架群组禁言事件子类型的枚举
	/// </summary>
	public enum QMGroupBanSpeakEventSubTypes
	{
		/// <summary>
		/// 群组禁言开启
		/// </summary>
		GroupBanSpeakOpen = 1,
		/// <summary>
		/// 群组禁言关闭
		/// </summary>
		GroupBanSpeakClose = 2
	}
}
