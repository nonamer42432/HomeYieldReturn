using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    public class NumberGenerator
    {
        public IEnumerable<int> GenerateNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return i; // Медленно выдает число
                System.Threading.Thread.Sleep(100); // Моделирует работу
            }
        }
    }
}
