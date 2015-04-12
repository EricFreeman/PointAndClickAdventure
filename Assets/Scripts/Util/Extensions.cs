using System.Collections.Generic;

namespace Assets.Scripts.Util
{
    public static class Extensions
    {
        public static string ToFormat(this string s, params object[] p)
        {
            return string.Format(s, p);
        }

        public static bool ContainsType<T>(this List<T> list, T item)
        {
            var contains = false;

            list.ForEach(listItem =>
            {
                if (listItem.GetType().Name == item.GetType().Name)
                {
                    contains = true;
                }
            });

            return contains;
        }
    }
}
