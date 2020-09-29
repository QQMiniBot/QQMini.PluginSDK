using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示请求的类
	/// </summary>
	public class Request : IEquatable<Request>
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的响应标识
		/// </summary>
		public string ReaponseFalg { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="Request"/> 类的新实例
		/// </summary>
		/// <param name="flag">响应标识</param>
		public Request (string flag)
		{
			if (flag is null)
			{
				throw new ArgumentNullException (nameof (flag));
			}

			this.ReaponseFalg = flag;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (Request obj)
		{
			if (obj is null)
			{
				return false;
			}

			return string.Compare (this.ReaponseFalg, obj.ReaponseFalg) == 0;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as Request);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.ReaponseFalg.GetHashCode ();
		}
		/// <summary>
		/// 将此实例的数值转换为其等效的字符串表示形式
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return JsonConvert.SerializeObject (this);
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 确定两个指定的 <see cref="Request"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果 a 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Request a, Request b)
		{
			if (a is null && b is null)
			{
				return true;
			}
			if (a is null)
			{
				return false;
			}
			return a.Equals (b);
		}
		/// <summary>
		/// 确定两个指定的 <see cref="Request"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果 a 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (Request a, Request b)
		{
			return !(a == b);
		}
		#endregion
	}
}
