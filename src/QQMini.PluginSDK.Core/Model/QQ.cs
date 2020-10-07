using Newtonsoft.Json;

using System;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示 QQ 号的类
	/// </summary>
	public class QQ : IEquatable<QQ>
	{
		#region --常量--
		private const long _minQQId = 10000;
		#endregion

		#region --字段--
		/// <summary>
		/// 获取 <see cref="QQ"/> 的最小值. (此值作为 "系统消息")
		/// </summary>
		public static readonly QQ MinValue = new QQ (_minQQId);
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前实例的唯一标识 (QQ号)
		/// </summary>
		public long Id { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="QQ"/> 类的新实例
		/// </summary>
		/// <param name="id">绑定于当前实例的标识 (QQ号)</param>
		/// <exception cref="ArgumentOutOfRangeException">参数 id 小于 <see cref="MinValue"/></exception>
		public QQ (long id)
		{
			if (id < _minQQId)
			{
				throw new ArgumentOutOfRangeException (nameof (id));
			}
			this.Id = id;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (QQ obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this.Id == obj.Id;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as QQ);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.Id.GetHashCode ();
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
		/// 定义将 <see cref="QQ"/> 对象转换为 <see cref="long"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="QQ"/> 对象</param>
		public static implicit operator long (QQ value)
		{
			return value.Id;
		}
		/// <summary>
		/// 定义将 <see cref="QQ"/> 对象转换为 <see cref="string"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="QQ"/> 对象</param>
		public static implicit operator string (QQ value)
		{
			return value.Id.ToString ();
		}
		/// <summary>
		/// 确定两个指定的 <see cref="QQ"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果 a 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (QQ a, QQ b)
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
		/// 确定两个指定的 <see cref="QQ"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果 a 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (QQ a, QQ b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="QQ"/> 和 <see cref="string"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="QQ"/> 对象</param>
		/// <param name="b">要比较的 <see cref="long"/> 对象</param>
		/// <returns>如果 a.Id 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (QQ a, long b)
		{
			if (a is null)
			{
				return false;
			}
			return a.Id.Equals (b);
		}
		/// <summary>
		/// 确定指定的 <see cref="QQ"/> 和 <see cref="string"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="QQ"/> 对象</param>
		/// <param name="b">要比较的 <see cref="long"/> 对象</param>
		/// <returns>如果 a.Id 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (QQ a, long b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="QQ"/> 和 <see cref="string"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="long"/> 对象</param>
		/// <param name="b">要比较的 <see cref="QQ"/> 对象</param>
		/// <returns>如果 a.Id 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (long a, QQ b)
		{
			return b == a;
		}
		/// <summary>
		/// 确定指定的 <see cref="QQ"/> 和 <see cref="string"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="long"/> 对象</param>
		/// <param name="b">要比较的 <see cref="QQ"/> 对象</param>
		/// <returns>如果 a.Id 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (long a, QQ b)
		{
			return b != a;
		}
		/// <summary>
		/// 确定指定的 <see cref="QQ"/> 和 <see cref="string"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="QQ"/> 对象</param>
		/// <param name="b">要比较的 <see cref="string"/> 对象</param>
		/// <returns>如果 a.Id 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (QQ a, string b)
		{
			if (a is null && b is null)
			{
				return true;
			}
			if (a is null)
			{
				return false;
			}
			return ((string)a).Equals (b);
		}
		/// <summary>
		/// 确定指定的 <see cref="QQ"/> 和 <see cref="string"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="QQ"/> 对象</param>
		/// <param name="b">要比较的 <see cref="string"/> 对象</param>
		/// <returns>如果 a.Id 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (QQ a, string b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="QQ"/> 和 <see cref="string"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="string"/> 对象</param>
		/// <param name="b">要比较的 <see cref="QQ"/> 对象</param>
		/// <returns>如果 a 是与 b.Id 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (string a, QQ b)
		{
			return b == a;
		}
		/// <summary>
		/// 确定指定的 <see cref="QQ"/> 和 <see cref="string"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="string"/> 对象</param>
		/// <param name="b">要比较的 <see cref="QQ"/> 对象</param>
		/// <returns>如果 a 是与 b.Id 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (string a, QQ b)
		{
			return b != a;
		}
		#endregion
	}
}
