using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 提供一种符合 QQMini 扩展插件的能力
	/// </summary>
	public interface IPlugin
	{
		/// <summary>
		/// 当在派生类中重写时, 获取插件的基本信息
		/// </summary>
		/// <returns>返回插件信息字符串</returns>
		string GetInfomaction ();
		/// <summary>
		/// 当在派生类中重写时, 设置插件的授权信息
		/// </summary>
		/// <param name="authCode">插件授权码</param>
		void SetAuthorize (int authCode);
		/// <summary>
		/// 当在派生类中重写时, 对当前插件进行初始化
		/// </summary>
		void OnInitialize ();
		/// <summary>
		/// 当在派生类中重写时, 对当前插件进行反初始化
		/// </summary>
		void OnUninitialize ();
		/// <summary>
		/// 当在派生类中重写时, 打开当前插件的设置菜单
		/// </summary>
		void OnOpenSettingMenu ();
	}
}
