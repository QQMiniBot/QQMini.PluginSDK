using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
    /// <summary>
    /// 请求的方式
    /// </summary>
    public enum ResponseTypes
    {
        /// <summary>
        /// 同意
        /// </summary>
        Accept = 10,
        /// <summary>
        /// 解决
        /// </summary>
        Refuse = 20,
        /// <summary>
        /// 忽略
        /// </summary>
        Ignore = 30
    }
}
