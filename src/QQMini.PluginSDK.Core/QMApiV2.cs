using Newtonsoft.Json.Linq;

using QQMini.PluginFramework.Utility.Core;
using QQMini.PluginInterface.Core;
using QQMini.PluginSDK.Core.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
					IntPtr.Zero,
					qqHandle.AddrOfPinnedObject (),
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
		/// <param name="qq">要发送消息到的目标QQ</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendGroupTempXML (string robotQQ, string group, string qq, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					4,
					groupHandle.AddrOfPinnedObject (),
					qqHandle.AddrOfPinnedObject (),
					xmlHandle.AddrOfPinnedObject (),
					0
				);
			}
			finally
			{
				robotQQHandle.Free ();
				groupHandle.Free ();
				qqHandle.Free ();
				xmlHandle.Free ();
			}
		}
		/// <summary>
		/// 发送讨论组临时XML结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="discuss">要发送消息到的目标群组</param>
		/// <param name="qq">要发送到的目标QQ</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendDiscussTempXML (string robotQQ, string discuss, string qq, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle discussHandle = discuss.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					5,
					discussHandle.AddrOfPinnedObject (),
					qqHandle.AddrOfPinnedObject (),
					xmlHandle.AddrOfPinnedObject (),
					0
				);
			}
			finally
			{
				robotQQHandle.Free ();
				discussHandle.Free ();
				qqHandle.Free ();
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
					IntPtr.Zero,
					qqHandle.AddrOfPinnedObject (),
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
		/// 发送好友验证回复XML结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">要发送消息到的目标QQ</param>
		/// <param name="xmlContent">XML内容</param>
		public static void SendFriendVeriReplyXML (string robotQQ, string qq, string xmlContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle xmlHandle = xmlContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendXml (
					robotQQHandle.AddrOfPinnedObject (),
					7,
					IntPtr.Zero,
					qqHandle.AddrOfPinnedObject (),
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
		/// <summary>
		/// 发送群组JSON结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="group">要发送消息到的目标群组</param>
		/// <param name="jsonContent">JSON内容</param>
		public static void SendGroupJSON (string robotQQ, string group, string jsonContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle jsonHandle = jsonContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendJson (
					robotQQHandle.AddrOfPinnedObject (),
					2,
					groupHandle.AddrOfPinnedObject (),
					IntPtr.Zero,
					jsonHandle.AddrOfPinnedObject ()
				);
			}
			finally
			{
				robotQQHandle.Free ();
				groupHandle.Free ();
				jsonHandle.Free ();
			}
		}
		/// <summary>
		/// 发送好友JSON结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">要发送消息到的目标QQ</param>
		/// <param name="jsonContent">JSON内容</param>
		public static void SendFirnedJSON (string robotQQ, string qq, string jsonContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle jsonHandle = jsonContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendJson (
					robotQQHandle.AddrOfPinnedObject (),
					1,
					IntPtr.Zero,
					qqHandle.AddrOfPinnedObject (),
					jsonHandle.AddrOfPinnedObject ()
				);
			}
			finally
			{
				robotQQHandle.Free ();
				qqHandle.Free ();
				jsonHandle.Free ();
			}
		}
		/// <summary>
		/// 发送讨论组JSON结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="discuss">要发送消息到的目标讨论组</param>
		/// <param name="jsonContent">JSON内容</param>
		public static void SendDiscussJSON (string robotQQ, string discuss, string jsonContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle discussHandle = discuss.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle jsonHandle = jsonContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendJson (
					robotQQHandle.AddrOfPinnedObject (),
					3,
					discussHandle.AddrOfPinnedObject (),
					IntPtr.Zero,
					jsonHandle.AddrOfPinnedObject ()
				);
			}
			finally
			{
				robotQQHandle.Free ();
				discussHandle.Free ();
				jsonHandle.Free ();
			}
		}
		/// <summary>
		/// 发送群组临时JSON结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="group">要发送消息到的目标群组</param>
		/// <param name="qq">要发送消息到的目标QQ</param>
		/// <param name="jsonContent">JSON内容</param>
		public static void SendGroupTempJSON (string robotQQ, string group, string qq, string jsonContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle jsonHandle = jsonContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendJson (
					robotQQHandle.AddrOfPinnedObject (),
					4,
					groupHandle.AddrOfPinnedObject (),
					qqHandle.AddrOfPinnedObject (),
					jsonHandle.AddrOfPinnedObject ()
				);
			}
			finally
			{
				robotQQHandle.Free ();
				groupHandle.Free ();
				qqHandle.Free ();
				jsonHandle.Free ();
			}
		}
		/// <summary>
		/// 发送讨论组临时JSON结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="discuss">要发送消息到的目标群组</param>
		/// <param name="qq">要发送到的目标QQ</param>
		/// <param name="jsonContent">JSON内容</param>
		public static void SendDiscussTempJSON (string robotQQ, string discuss, string qq, string jsonContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle discussHandle = discuss.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle jsonHandle = jsonContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendJson (
					robotQQHandle.AddrOfPinnedObject (),
					5,
					discussHandle.AddrOfPinnedObject (),
					qqHandle.AddrOfPinnedObject (),
					jsonHandle.AddrOfPinnedObject ()
				);
			}
			finally
			{
				robotQQHandle.Free ();
				discussHandle.Free ();
				qqHandle.Free ();
				jsonHandle.Free ();
			}
		}
		/// <summary>
		/// 发送网页临时JSON结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">要发送消息到的目标QQ</param>
		/// <param name="jsonContent">JSON内容</param>
		public static void SendWebTempJSON (string robotQQ, string qq, string jsonContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle jsonHandle = jsonContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendJson (
					robotQQHandle.AddrOfPinnedObject (),
					6,
					IntPtr.Zero,
					qqHandle.AddrOfPinnedObject (),
					jsonHandle.AddrOfPinnedObject ()
				);
			}
			finally
			{
				robotQQHandle.Free ();
				qqHandle.Free ();
				jsonHandle.Free ();
			}
		}
		/// <summary>
		/// 发送好友验证回复JSON结构化消息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">要发送消息到的目标QQ</param>
		/// <param name="jsonContent">JSON内容</param>
		public static void SendFriendVeriReplyJSON (string robotQQ, string qq, string jsonContent)
		{
			GCHandle robotQQHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle json = jsonContent.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				MingQQAPI.Api_SendJson (
					robotQQHandle.AddrOfPinnedObject (),
					7,
					IntPtr.Zero,
					qqHandle.AddrOfPinnedObject (),
					json.AddrOfPinnedObject ()
				);
			}
			finally
			{
				robotQQHandle.Free ();
				qqHandle.Free ();
				json.Free ();
			}
		}
		/// <summary>
		/// 获取好友信息
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="qq">要获取信息的目标好友QQ</param>
		/// <returns>成功获取返回好友信息JSON</returns>
		public static JObject GetFriendInfo (string robotQQ, string qq)
		{
			GCHandle robotHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				IntPtr resultPtr = MingQQAPI.Api_GetObjInfo (
					robotHandle.AddrOfPinnedObject (),
					qqHandle.AddrOfPinnedObject ()
				);

				return JObject.Parse (resultPtr.ToString (Global.DefaultEncoding));
			}
			finally
			{
				robotHandle.Free ();
				qqHandle.Free ();
			}
		}
		/// <summary>
		/// 获取好友列表
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <returns>成功返回指定QQ的好友列表JSON</returns>
		public static JObject GetFirnedList (string robotQQ)
		{
			GCHandle robotHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			try
			{
				IntPtr resultPtr = MingQQAPI.Api_GetFriendList (robotHandle.AddrOfPinnedObject ());
				return JObject.Parse (resultPtr.ToString (Global.DefaultEncoding));
			}
			finally
			{
				robotHandle.Free ();
			}
		}
		/// <summary>
		/// 设置或取消群组管理员
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="group">要操作成员权限的目标群</param>
		/// <param name="qq">要控制其权限的QQ</param>
		/// <param name="isSet">是否设置为管理员</param>
		/// <returns>如果设置成功返回 <see langword="true"/>, 否则返回 <see langword="false"/></returns>
		public static bool SetGroupAdmin (string robotQQ, string group, string qq, bool isSet)
		{
			GCHandle robotHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);

			try
			{
				return MingQQAPI.Api_SetAdmin (
							robotHandle.AddrOfPinnedObject (),
							groupHandle.AddrOfPinnedObject (),
							qqHandle.AddrOfPinnedObject (),
							isSet);
			}
			finally
			{
				robotHandle.Free ();
				groupHandle.Free ();
				qqHandle.Free ();
			}
		}
		/// <summary>
		/// 移除群组成员
		/// </summary>
		/// <param name="robotQQ">机器人QQ</param>
		/// <param name="group">要从中移除成员的目标群组</param>
		/// <param name="qq">要从群组中移除的目标QQ</param>
		/// <param name="isNotRec">设置一个值, 指示是否不再接收该成员的入群申请. 默认值: <see langword="false"/></param>
		public static void RemoveGroupMember (string robotQQ, string group, string qq, bool isNotRec = false)
		{
			GCHandle robotHandle = robotQQ.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle groupHandle = group.GetStringGCHandle (Global.DefaultEncoding);
			GCHandle qqHandle = qq.GetStringGCHandle (Global.DefaultEncoding);

			try
			{
				MingQQAPI.Api_KickGroupMBR (
							robotHandle.AddrOfPinnedObject (),
							groupHandle.AddrOfPinnedObject (),
							qqHandle.AddrOfPinnedObject (),
							isNotRec);
			}
			finally
			{
				robotHandle.Free ();
				groupHandle.Free ();
				qqHandle.Free ();
			}
		}
		/// <summary>
		/// 获取框架所有QQ
		/// </summary>
		/// <returns>返回框架的所有QQ</returns>
		public static ReadOnlyCollection<QQ> GetFrameAllQQ ()
		{
			IntPtr resultPtr = MingQQAPI.Api_GetQQList ();
			string data = resultPtr.ToString (Global.DefaultEncoding);
			string[] list = data.Split (new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			List<QQ> qqlist = new List<QQ> ();

			foreach (string item in list)
			{
				qqlist.Add (item);
			}

			return qqlist.AsReadOnly ();
		}
		/// <summary>
		/// 获取框架所有在线QQ
		/// </summary>
		/// <returns>返回框架的所有在线的QQ</returns>
		public static ReadOnlyCollection<QQ> GetFrameAllOnlineQQ ()
		{
			IntPtr resultPtr = MingQQAPI.Api_GetOnlineQQlist ();
			string data = resultPtr.ToString (Global.DefaultEncoding);
			string[] list = data.Split (new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			List<QQ> qqlist = new List<QQ> ();

			foreach (string item in list)
			{
				qqlist.Add (item);
			}

			return qqlist.AsReadOnly ();
		}
		/// <summary>
		/// 获取框架所有离线QQ
		/// </summary>
		/// <returns>返回框架的所有在线的QQ</returns>
		public static ReadOnlyCollection<QQ> GetFrameAllOfflineQQ ()
		{
			IntPtr resultPtr = MingQQAPI.Api_GetOffLineList ();
			string data = resultPtr.ToString (Global.DefaultEncoding);
			string[] list = data.Split (new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			List<QQ> qqlist = new List<QQ> ();

			foreach (string item in list)
			{
				qqlist.Add (item);
			}

			return qqlist.AsReadOnly ();
		}
	}
}
