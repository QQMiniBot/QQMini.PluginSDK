using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
    /// <summary>
    /// 表示在线状态的枚举
    /// </summary>
    public enum OnlineStatusTypes
    {
        /// <summary>
        /// 在线
        /// </summary>
        Online = 1,
        /// <summary>
        /// Q我吧
        /// </summary>
        QMe = 2,
        /// <summary>
        /// 离开
        /// </summary>
        Leave = 3,
        /// <summary>
        /// 忙碌
        /// </summary>
        Busy = 4,
        /// <summary>
        /// 请勿打扰
        /// </summary>
        NoDisturb = 5,
        /// <summary>
        /// 隐身
        /// </summary>
        Invisible = 6
    }
}
