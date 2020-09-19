using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
    /// <summary>
    /// 存放查询到目标QQ的好友验证方式
    /// </summary>
    public enum VerifyTypes
    {
        /// <summary>
        /// 无验证
        /// </summary>
        No_validation = 0,
        /// <summary>
        /// 需身份验证
        /// </summary>
        Authentication_required = 1,
        /// <summary>
        /// 需正确答案
        /// </summary>
        Need_correct_answer = 3,
        /// <summary>
        /// 需回答问题
        /// </summary>
        Questions_to_answer = 4,
        /// <summary>
        /// 已成为好友
        /// </summary>
        Already_friend = 99
    }
}
