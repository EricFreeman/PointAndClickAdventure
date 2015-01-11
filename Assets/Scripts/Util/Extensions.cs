namespace Assets.Scripts.Util
{
    public static class Extensions
    {
        public static string ToFormat(this string s, params object[] p)
        {
            return string.Format(s, p);
        }
    }
}
