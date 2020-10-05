using QQMini.PluginSDK.Core;
using QQMini.PluginSDK.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Test
{
	public class Plugin : PluginBase
	{
		public override PluginInfo PluginInfo => new PluginInfo ()
		{
			PackageId = "com.jiegg.demo",
			Author = "JieGG",
			Name = "QQMini插件V3",
			Description = "QQMini插件",
			Version = new Version (1, 0, 0, 0)
		};
	}
}
