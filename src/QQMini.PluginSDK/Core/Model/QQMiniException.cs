using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
    /// <summary>
    /// 表示异常代码的枚举
    /// </summary>
    public class QQMiniException : Exception
    {
        private readonly int _code;
        /// <summary>
        /// 错误代码
        /// </summary>
        public int Code { get => _code; }
        /// <summary>
        /// 生成一个QQMiniPluginException异常
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息</param>
        public QQMiniException(int code,string message) : base(message)
        {
            _code = code;
        }
    }
}
