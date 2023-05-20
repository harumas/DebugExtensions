using System.Text;
using System.Text.RegularExpressions;

namespace Wanna.DebugEx
{
    public static class JsonHandler
    {
        const string NL = "^";
        const string TAB = "   ";

        static StringBuilder tabBuilder = new StringBuilder();

        public static string InsertTab(string str, int count)
        {
            CompensateTab(count);

            return Regex.Replace(str, NL, tabBuilder.ToString(0, count * TAB.Length), RegexOptions.Multiline);
        }

        static void CompensateTab(int count)
        {
            int tabCount = tabBuilder.Length / TAB.Length;

            if (tabCount >= count) return;

            for (int i = 0; i < count - tabCount; i++)
            {
                tabBuilder.Append(TAB);
            }
        }

        public static void Surround(StringBuilder sb, char lhs, char rhs)
        {
            if (sb.Length == 0)
            {
                sb.Append($"{lhs} {rhs}");
            }
            else
            {
                sb.Insert(0, $"\n{lhs}\n");
                sb.Append($"\n{rhs}");
            }
        }
    }
}