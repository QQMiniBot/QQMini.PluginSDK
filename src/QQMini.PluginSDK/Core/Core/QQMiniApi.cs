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

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetFrameTimeStamp), CallingConvention = CallingConvention.StdCall)]
		public static extern long QMApi_GetFrameTimeStamp (int nAuthCode);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetPluginDataDirectory), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr QMApi_GetPluginDataDirectory (int nAuthCode);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetFriendList), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetFriendList (int nAuthCode, long lResponseQQ, bool bUseCache, out IntPtr szFriendList);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetFriendInfo), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetFriendInfo (int nAuthCode, long lResponseQQ, long lDestQQ, bool bUseCache, out IntPtr szFriendInfo);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetStrangerInfo), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetStrangerInfo (int nAuthCode, long lResponseQQ, long lDestQQ, bool bUseCache, out IntPtr szStrangerInfo);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetGroupList), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetGroupList (int nAuthCode, long lResponseQQ, bool bUseCache, out IntPtr szGroupList);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetGroupInfo), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetGroupInfo (int nAuthCode, long lResponseQQ, long lDestGroup, bool bUseCache, out IntPtr szGroupInfo);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetGroupMemberList), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetGroupMemberList (int nAuthCode, long lResponseQQ, long lDestGroup, bool bUseCache, out IntPtr szGroupManagerList);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetGroupMemberInfo), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetGroupMemberInfo (int nAuthCode, long lResponseQQ, long lDestGroup, long lDestQQ, bool bUseCache, out IntPtr szGroupMemberInfo);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetGroupManagerList), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetGroupManagerList (int nAuthCode, long lResponseQQ, long lDestGroup, bool bUseCache, out IntPtr szGroupManagerList);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetDiscussList), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetDiscussList (int nAuthCode, long lResponseQQ, bool bUseCache, out IntPtr szDiscussList);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetDiscussMemberList), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetDiscussMemberList (int nAuthCode, long lResponseQQ, long lDestDiscuss, bool bUseCache, out IntPtr szDiscussMemberList);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetCookies), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetCookies (int nAuthCode, long lResponseQQ, out IntPtr szCookies);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetBkn), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetBkn (int nAuthCode, long lResponseQQ, out IntPtr szBkn);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetOnlineStatus), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetOnlineStatus (int nAuthCode, long lResponseQQ, long lDestQQ, out int nOnlineStatus);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetGroupBanStatus), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetGroupBanStatus (int nAuthCode, long lResponseQQ, long lDestGroup, long lDestQQ, out bool bIsBan);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetFriendVerifyMode), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetFriendVerifyMode (int nAuthCode, long lResponseQQ, long IDestQQ, out int nFriendVerify);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetIsOnline), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetIsOnline (int nAuthCode, long lResponseQQ, long IDestQQ, out bool bIsOnline);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetIsReceiveOnlineTempMessage), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetIsReceiveOnlineTempMessage (int nAuthCode, long lResponseQQ, long IDestQQ, out bool bIsOnline);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetDiscussName), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetDiscussName (int nAuthCode, long lResponseQQ, long lDestDiscuss, out IntPtr szDiscussName);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetDiscussAddLink), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetDiscussAddLink (int nAuthCode, long lResponseQQ, long lDestDiscuss, out IntPtr szDiscussAddLink);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetGroupGiftList), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetGroupGiftList (int nAuthCode, long lResponseQQ, out IntPtr szGiftList);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_GetRandomGroupGift), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_GetRandomGroupGift (int nAuthCode, long lResponseQQ, long lDestGroup, out IntPtr szGift);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetLogger), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetLogger (int nAuthCode, int nLevel, IntPtr szMessage);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetFatal), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetFatal (int nAuthCode, int nErrorCode, IntPtr szErrorMessage);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetOnlineStatus), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetOnlineStatus (int nAuthCode, long lResponseQQ, int nOnlineStatus, IntPtr szStatusMessage);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetAddQQToBlacklist), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetAddQQToBlacklist (int nAuthCode, long lResponseQQ, long lDestQQ);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetGroupBanStatus), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetGroupBanStatus (int nAuthCode, long lResponseQQ, long lDestGroup, long lDestQQ, int nTimeSpan);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetGroupAnonymousStatus), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetGroupAnonymousStatus (int nAuthCode, long lResponseQQ, long lDestGroup, bool bIsEnabled);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetGroupShieldedStatus), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetGroupShieldedStatus (int nAuthCode, long lResponseQQ, long lDestGroup, bool bIsShielded);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetGroupManager), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetGroupManager (int nAuthCode, long lResponseQQ, long lDestGroup, long IDestQQ, bool bIsManager);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetGroupMemberCard), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetGroupMemberCard (int nAuthCode, long lResponseQQ, long lDestGroup, long lDestQQ, IntPtr szNewCard);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetGroupQuit), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetGroupQuit ();

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetDiscussQuit), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetDiscussQuit (int nAuthCode, long lResponseQQ, long lDestDiscuss);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetDiscussName), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetDiscussName (int nAuthCode, long lResponseQQ, long lDestDiscuss, IntPtr szNewName);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetFriendNotes), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetFriendNotes (int nAuthCode, long lResponseQQ, long lDestQQ, IntPtr szNewNotes);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetSignature), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetSignature (int nAuthCode, long lResponseQQ, IntPtr szNewSignature);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetGender), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetGender (int nAuthCode, long lResponseQQ, int nGender);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetNick), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetNick (int nAuthCode, long lResponseQQ, IntPtr szNewNick);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetFriendAddRequest), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetFriendAddRequest (int nAuthCode, long lResponseQQ, long lDestQQ, int nResponseType, IntPtr szAppendMsg);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SetGroupAddRequest), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SetGroupAddRequest (int nAuthCode, long lResponseQQ, long lDestGroup, long lDestQQ, IntPtr szSeq, int nResponseType, IntPtr szAppendMsg);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendMessage), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendMessage (int nAuthCode, long lResponseQQ, int nSendType, long lDestTarget, long IDestQQ, IntPtr szMessage, int nXMLSubType);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendLike), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendLike (int nAuthCode, long lResponseQQ, long IDestQQ, int nCount);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendShake), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendShake (int nAuthCode, long lResponseQQ, long lDestQQ);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendSignIn), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendSignIn (int nAuthCode, long lResponseQQ, long lDestGroup, IntPtr szPlaceName, IntPtr szMessage);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendInputing), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendInputing (int nAuthCode, long lResponseQQ, long lDestQQ);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendGroupNotification), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendGroupNotification (int nAuthCode, long lResponseQQ, long lDestGroup, IntPtr szNotificationTitle, IntPtr szNotificationContent);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendGroupWork), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendGroupWork (int nAuthCode, long lResponseQQ, long lDestGroup, IntPtr szWorkName, IntPtr szWorkTitle, IntPtr szWorkContent);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendGroupGift), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendGroupGift (int nAuthCode, long lResponseQQ, long lDestGroup, long lDestQQ, IntPtr szGiftPid);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendGroupAddRequest), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendGroupAddRequest (int nAuthCode, long lResponseQQ, long lDestGroup, IntPtr szAppendMsg);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendFriendAddRequest), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendFriendAddRequest (int nAuthCode, long lResponseQQ, long lDestQQ, IntPtr szAppendMsg);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendGroupInviteRequest), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendGroupInviteRequest (int nAuthCode, long lResponseQQ, long lDestGroup, long lDestQQ);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_SendDiscussInviteRequest), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_SendDiscussInviteRequest (int nAuthCode, long lResponseQQ, long lDestDiscuss, long lDestQQ);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_DownloadPicture), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_DownloadPicture (int nAuthCode, long lResponseQQ, IntPtr szPictureGUID, IntPtr szPicturePath);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_DownloadVoice), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_DownloadVoice (int nAuthCode, long lResponseQQ, IntPtr szVoiceGUID, int szVoiceOutFormat, IntPtr szVoicePath);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_UploadPicture), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_UploadPicture (int nAuthCode, long lResponseQQ, IntPtr szPicturePath, IntPtr szPictureGUID);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_UploadVoice), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_UploadVoice (int nAuthCode, long lResponseQQ, IntPtr szVoicePath, IntPtr szVoiceGUID);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_UploadHeadPortraits), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_UploadHeadPortraits (int nAuthCode, long lResponseQQ, IntPtr szPicturePath);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_UploadCover), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_UploadCover (int nAuthCode, long lResponseQQ, IntPtr szPicturePath);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_RemoveFromBlacklist), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_RemoveFromBlacklist (int nAuthCode, long lResponseQQ, long lDestQQ);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_RemoveFriend), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_RemoveFriend (int nAuthCode, long lResponseQQ, long lDestQQ);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_RemoveMessage), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_RemoveMessage (int nAuthCode, long lResponseQQ, int nMessageId);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_RemoveGroupMember), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_RemoveGroupMember (int nAuthCode, long lResponseQQ, long lDestGroup, long lDestQQ, bool bIsoutuseAccept);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_RemoveDiscussMember), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_RemoveDiscussMember (int nAuthCode, long lResponseQQ, long lDestDiscuss, long lDestQQ);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_CreateDiscuss), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_CreateDiscuss (int nAuthCode, long lResponseQQ, long lDestQQ, out long lDiscussId);

		[DllImport (LibraryName, EntryPoint = nameof (QMApi_AddDiscussFromLink), CallingConvention = CallingConvention.StdCall)]
		public static extern int QMApi_AddDiscussFromLink (int nAuthCode, long lResponseQQ, IntPtr szDiscussLink);
	}
}
