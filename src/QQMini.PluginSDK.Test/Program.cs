using QQMini.PluginSDK.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Test
{
	class Program
	{
		static void Main ()
		{
			IPlugin plugin = new Plugin ();
			Console.WriteLine (plugin.GetInfomaction ());
			Console.ReadKey ();
		}
	}
}
