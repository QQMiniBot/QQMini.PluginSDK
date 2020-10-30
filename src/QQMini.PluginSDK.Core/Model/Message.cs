using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMini.PluginSDK.Core.Model
{
	/// <summary>
	/// 表示消息的类
	/// </summary>
	public class Message : IEquatable<Message>
	{
		#region --属性--
		/// <summary>
		/// 获取当前消息的唯一标识 (ID)
		/// </summary>
		public long Id { get; }
		/// <summary>
		/// 获取当前消息的序号
		/// </summary>
		public long Number { get; }
		/// <summary>
		/// 获取当前消息的文本
		/// </summary>
		public string Text { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="Message"/> 类的新实例
		/// </summary>
		/// <param name="id">消息标识</param>
		/// <param name="number">消息序号</param>
		/// <param name="text">消息文本</param>
		/// <exception cref="ArgumentOutOfRangeException">参数 id 或 number 小于 0</exception>
		/// <exception cref="ArgumentNullException">参数 text 为 <see langword="null"/></exception>
		public Message (long id, long number, string text)
		{
			if (id < 0)
			{
				throw new ArgumentOutOfRangeException (nameof (id));
			}

			if (number < 0)
			{
				throw new ArgumentOutOfRangeException (nameof (number));
			}
			Id = id;
			Number = number;
			Text = text ?? throw new ArgumentNullException (nameof (text));
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (Message obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this.Id == obj.Id && this.Number == obj.Number && string.Compare (this.Text, obj.Text) == 0;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as Message);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.Id.GetHashCode () & this.Number.GetHashCode () & this.Text.GetHashCode ();
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
		/// 定义将 <see cref="Message"/> 对象转换为 <see cref="string"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="Message"/> 对象</param>
		public static implicit operator string (Message value)
		{
			return value.Text;
		}
		/// <summary>
		/// 确定两个指定的 <see cref="Message"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果 a 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Message a, Message b)
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
		/// 确定两个指定的 <see cref="Message"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果 a 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (Message a, Message b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="Message"/> 和 <see cref="string"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="Message"/> 对象</param>
		/// <param name="b">要比较的 <see cref="string"/> 对象</param>
		/// <returns>如果 a.Id 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Message a, string b)
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
		/// 确定指定的 <see cref="Message"/> 和 <see cref="string"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="Message"/> 对象</param>
		/// <param name="b">要比较的 <see cref="string"/> 对象</param>
		/// <returns>如果 a.Id 是与 b 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (Message a, string b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="Message"/> 和 <see cref="string"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="string"/> 对象</param>
		/// <param name="b">要比较的 <see cref="Message"/> 对象</param>
		/// <returns>如果 a 是与 b.Id 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (string a, Message b)
		{
			return b == a;
		}
		/// <summary>
		/// 确定指定的 <see cref="Message"/> 和 <see cref="string"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="string"/> 对象</param>
		/// <param name="b">要比较的 <see cref="Message"/> 对象</param>
		/// <returns>如果 a 是与 b.Id 相同的值，或两者均为 <see langword="null"/>，则为 <see langword="false"/>；否则为 <see langword="true"/></returns>
		public static bool operator != (string a, Message b)
		{
			return b != a;
		}
		#endregion
	}
}
