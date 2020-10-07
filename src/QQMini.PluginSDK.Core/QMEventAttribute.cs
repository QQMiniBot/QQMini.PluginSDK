using QQMini.PluginSDK.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 表示将特定方法设置为指定类型事件的终点的特性
	/// </summary>
	[AttributeUsage (AttributeTargets.Method)]
	public class QMEventAttribute : Attribute
	{
		/// <summary>
		/// 获取或设置当前实例的事件类型
		/// </summary>
		public QMEventTypes Type { get; set; }
		/// <summary>
		/// 获取或设置当前实例的事件子类型
		/// </summary>
		public int SubType { get; set; } = 1;

		/// <summary>
		/// 初始化 <see cref="QMEventAttribute"/> 类的新实例
		/// </summary>
		/// <param name="type">表示路由匹配的事件类型</param>
		public QMEventAttribute (QMEventTypes type)
		{
			this.Type = type;
		}
	}
}
