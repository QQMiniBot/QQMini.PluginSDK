using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Core
{
	internal static class QQMiniApi
	{
		public const string LibraryName = "QQMiniApi.dll";

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetFrameType), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetFrameType (int nAuthCode);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetFrameVersion), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr QMApi_GetFrameVersion (int nAuthCode);
	}
}
