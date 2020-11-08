using Newtonsoft.Json.Linq;

using QQMini.PluginFramework.Utility.Core;
using QQMini.PluginInterface.Core;
using QQMini.PluginSDK.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core
{
	/// <summary>
	/// 提供 QQMini 应用程序公开接口的调用实现
	/// </summary>
	[Serializable]
	[Obsolete ("此类的接口为 V2 版本的接口, 请尽量使用 V3 接口代替此类中的实现. 此类将在 V2 接口完全弃用后删除")]
	public static class QMApiV2
	{
		/// <summary>
		/// 发送群组XML结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="group">要发送消息到的目标群组</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendGroupXML (string robotQQ, string group, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					2,
					groupHandle.AddrOfPinnedObject (),
					IntPtr.Zero,
					xmlHandle.AddrOfPinnedObject (),
					0
				);
			}
			finally
			{
				robotQQHandle.Free ();
				groupHandle.Free ();
				xmlHandle.Free ();
			}
		}
		/// <summary>
		/// 发送好友XML结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">要发送消息到的目标QQ</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendFriendXML (string robotQQ, string qq, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					1,
					qqHandle.AddrOfPinnedObject (),
					IntPtr.Zero,
					xmlHandle.AddrOfPinnedObject (),
					0
				);
			}
			finally
			{
				robotQQHandle.Free ();
				qqHandle.Free ();
				xmlHandle.Free ();
			}
		}
		/// <summary>
		/// 发送讨论组XML结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="discuss">要发送消息到的目标讨论组</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendDiscussXML (string robotQQ, string discuss, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle discussHandle = discuss.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					3,
					discussHandle.AddrOfPinnedObject (),
					IntPtr.Zero,
					xmlHandle.AddrOfPinnedObject (),
					0
				);
			}
			finally
			{
				robotQQHandle.Free ();
				discussHandle.Free ();
				xmlHandle.Free ();
			}
		}
		/// <summary>
		/// 发送群组临时XML结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="group">要发送消息到的目标群组</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendGroupTempXML (string robotQQ, string group, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					4,
					groupHandle.AddrOfPinnedObject (),
					IntPtr.Zero,
					xmlHandle.AddrOfPinnedObject (),
					0
				);
			}
			finally
			{
				robotQQHandle.Free ();
				groupHandle.Free ();
				xmlHandle.Free ();
			}
		}
		/// <summary>
		/// 发送讨论组临时XML结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="discuss">要发送消息到的目标群组</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendDiscussTempXML (string robotQQ, string discuss, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle discussHandle = discuss.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					5,
					discussHandle.AddrOfPinnedObject (),
					IntPtr.Zero,
					xmlHandle.AddrOfPinnedObject (),
					0
				);
			}
			finally
			{
				robotQQHandle.Free ();
				discussHandle.Free ();
				xmlHandle.Free ();
			}
		}
		/// <summary>
		/// 发送网页临时XML结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">要发送消息到的目标QQ</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendWebTempXML (string robotQQ, string qq, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					6,
					qqHandle.AddrOfPinnedObject (),
					IntPtr.Zero,
					xmlHandle.AddrOfPinnedObject (),
					0
				);
			}
			finally
			{
				robotQQHandle.Free ();
				qqHandle.Free ();
				xmlHandle.Free ();
			}
		}
		/// <summary>
		/// 撤回指定的消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="group">要从指定的群组撤回消息</param>
		/// <param name="message">要撤回的消息</param>
		/// <returns>成功返回空，失败返回腾讯给出的理由</returns>
		public static string WithdrawMessage (string robotQQ, string group, Message message)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle msgNumHandle = message.Number.ToString ().GetStringGCHandle (Global.DefaultEncoding);
			GCHandle msgIdHandle = message.Id.ToString ().GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				return MingQQAPI.Api_WithdrawMsg (
					robotQQHandle.AddrOfPinnedObject (),
					groupHandle.AddrOfPinnedObject (),
					msgNumHandle.AddrOfPinnedObject (),
					msgIdHandle.AddrOfPinnedObject ()
				).ToString (Global.DefaultEncoding);
			}
			finally
			{
				robotQQHandle.Free ();
				groupHandle.Free ();
				msgNumHandle.Free ();
				msgIdHandle.Free ();
			}
		}
		/// <summary>
		/// 获取群组列表
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <returns>成功返回群组组的 Json</returns>
		public static JObject GetGroupList (string robotQQ)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				IntPtr resultPtr = MingQQAPI.Api_GetGroupList_B (robotQQHandle.AddrOfPinnedObject ());
				return JObject.Parse (resultPtr.ToString (Global.DefaultEncoding));
			}
			finally
			{
				robotQQHandle.Free ();
			}
		}
		/// <summary>
		/// 获取群成员列表
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="group">要获取成员列表的群</param>
		/// <returns>成功返回群组成员的 Json</returns>
		public static JObject GetGroupMemberList (string robotQQ, string group)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				IntPtr resultPtr = MingQQAPI.Api_GetGroupMemberList_C (robotQQHandle.AddrOfPinnedObject (), groupHandle.AddrOfPinnedObject ());
				return JObject.Parse (resultPtr.ToString (Global.DefaultEncoding));
			}
			finally
			{
				robotQQHandle.Free ();
				groupHandle.Free ();
			}
		}
		/// <summary>
		/// 获取指定群组的图片链接
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="target">要获取图片的群组或讨论组</param>
		/// <param name="picCode">图片代码, 例如: [pic={xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}.jpg]</param>
		/// <returns>根据图片获取下载地址</returns>
		public static string GetPicUrl (string robotQQ, string target, string picCode)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle targetHandle = target.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle picCodeHandle = picCode.GetStringGCHandle (Global.DefaultEncoding);

			try
			{
				IntPtr resultPtr = MingQQAPI.Api_GetPicLink (
					robotQQHandle.AddrOfPinnedObject (),
					1,
					targetHandle.AddrOfPinnedObject (),
					picCodeHandle.AddrOfPinnedObject ()
				);
				return resultPtr.ToString (Global.DefaultEncoding);
			}
			finally
			{
				robotQQHandle.Free ();
				targetHandle.Free ();
				picCodeHandle.Free ();
			}
		}
		/// <summary>
		/// 获取非群组的图片链接
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="picCode">图片代码, 例如: [pic={xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}.jpg]</param>
		/// <returns>根据图片获取下载地址</returns>
		public static string GetPicUrl (string robotQQ, string picCode)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle picCodeHandle = picCode.GetStringGCHandle (Global.DefaultEncoding);

			try
			{
				IntPtr resultPtr = MingQQAPI.Api_GetPicLink (
					robotQQHandle.AddrOfPinnedObject (),
					1,
					IntPtr.Zero,
					picCodeHandle.AddrOfPinnedObject ()
				);
				return resultPtr.ToString (Global.DefaultEncoding);
			}
			finally
			{
				robotQQHandle.Free ();
				picCodeHandle.Free ();
			}
		}
		/// <summary>
		/// 上传群组图片, 上传成功返回图片 GUID
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="target">要上传的图片的图标群组或讨论组</param>
		/// <param name="imgData">要上传图片的数据</param>
		/// <returns>如果上传成功返回图片的 GUID</returns>
		public static string UploadGroupPic (string robotQQ, string target, byte[] imgData)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle targetHandle = target.GetStringGCHandle (Global.DefaultEncoding);

			try
			{
				IntPtr resultPtr = MingQQAPI.Api_UpLoadPic (
					robotQQHandle.AddrOfPinnedObject (),
					2,
					targetHandle.AddrOfPinnedObject (),
					imgData
				);

				return resultPtr.ToString (Global.DefaultEncoding);
			}
			finally
			{
				robotQQHandle.Free ();
				targetHandle.Free ();
			}
		}
		/// <summary>
		/// 上传非群组图片, 上传成功返回图片 GUID
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">图标将要发送到的目标QQ</param>
		/// <param name="imgData">要上传图片的数据</param>
		/// <returns>如果上传成功返回图片的 GUID</returns>
		public static string UploadNoGroupPic (string robotQQ, string qq, byte[] imgData)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);

			try
			{
				IntPtr resultPtr = MingQQAPI.Api_UpLoadPic (
					robotQQHandle.AddrOfPinnedObject (),
					1,
					qqHandle.AddrOfPinnedObject (),
					imgData
				);

				return resultPtr.ToString (Global.DefaultEncoding);
			}
			finally
			{
				robotQQHandle.Free ();
				qqHandle.Free ();
			}
		}
		/// <summary>
		/// 上传群组语音, 上传成功返回语音 GUID
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="target">要发送的目标群组或讨论组</param>
		/// <param name="vocData">语音数据 (AMR Silk编码)</param>
		/// <returns>如果上传成功返回语音的 GUID</returns>
		public static string UploadGroupVoice (string robotQQ, string target, byte[] vocData)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle targetHandle = target.GetStringGCHandle (Global.DefaultEncoding);

			try
			{
				IntPtr resultPtr = MingQQAPI.Api_UpLoadVoice (
					robotQQHandle.AddrOfPinnedObject (),
					targetHandle.AddrOfPinnedObject (),
					vocData
				);

				return resultPtr.ToString (Global.DefaultEncoding);
			}
			finally
			{
				robotQQHandle.Free ();
				targetHandle.Free ();
			}
		}
		/// <summary>
		/// 上传非群组语音, 上传成功返回语音 GUID
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">要发送的目标QQ</param>
		/// <param name="vocData">语音数据 (AMR Silk编码)</param>
		/// <returns>如果上传成功返回语音的 GUID</returns>
		public static string UploadNoGroupVoice (string robotQQ, string qq, byte[] vocData)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);

			try
			{
				IntPtr resultPtr = MingQQAPI.Api_UpLoadVoice (
					robotQQHandle.AddrOfPinnedObject (),
					qqHandle.AddrOfPinnedObject (),
					vocData
				);

				return resultPtr.ToString (Global.DefaultEncoding);
			}
			finally
			{
				robotQQHandle.Free ();
				qqHandle.Free ();
			}
		}
	}
}
