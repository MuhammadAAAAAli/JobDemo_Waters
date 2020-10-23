using System.Collections.Generic;
using System.Text;

namespace WatersUi
{
    public class Permutaions
    {
        private static List<string> _per = new List<string>();

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static List<string> GetPer(char[] list)
        {
            _per = new List<string>();
            var x = list.Length - 1;
            GetPer(list, 0, x);
            return _per;
        }

        private static void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                var perm = new StringBuilder();
                foreach (var l in list)
                {
                    perm.Append(l);
                }
                _per.Add(perm.ToString());
            }
            else
                for (var i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }
    }
}