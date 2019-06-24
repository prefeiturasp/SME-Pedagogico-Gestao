using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SME.Pedagogico.Gestao.Data.Enums
{
    public class BaseEnum<T, Y> where T : BaseEnum<T, Y>
    {
        public int Code { get; protected set; }
        public Y Text { get; protected set; }

        protected BaseEnum(int code, Y text)
        {
            Code = code;
            Text = text;
        }

        public static IList<T> ToList()
        {
            var result = new List<T>();
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
            fields.ForEach(f => result.Add((T)f.GetValue(null)));

            return result;
        }

        public static implicit operator int(BaseEnum<T, Y> @enum) => @enum?.Code ?? 0;

        public static implicit operator Y(BaseEnum<T, Y> @enum) => @enum == null ? default(Y) : @enum.Text;

        public static explicit operator BaseEnum<T, Y>(int code)
        {
            return ToList().FirstOrDefault(e => e.Code == code);
        }

        public static explicit operator BaseEnum<T, Y>(Y text)
        {
            return ToList().FirstOrDefault(e => e.Text.Equals(text));
        }
    }
}
