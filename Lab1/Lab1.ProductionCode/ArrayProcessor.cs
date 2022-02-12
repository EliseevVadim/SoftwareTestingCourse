using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ProductionCode
{
    public class ArrayProcessor
    {
        public ArrayProcessor()
        {

        }

        public int[] SortAndFilter(int[] a)
        {
            List<int> result = new List<int>();
            Dictionary<int, int> elementsWithEnteries = new Dictionary<int, int>();
            foreach (int element in a)
            {
                if (elementsWithEnteries.ContainsKey(element))
                {
                    elementsWithEnteries[element]++;
                }
                else
                {
                    elementsWithEnteries.Add(element, 1);
                }
            }
            foreach (KeyValuePair<int, int> pair in elementsWithEnteries)
            {
                if (pair.Key < 0)
                {
                    result.Add(pair.Key);
                }
                else
                {
                    for (int i = 0; i < pair.Value; i++)
                    {
                        result.Add(pair.Key);
                    }
                }
            }
            result.Sort();
            return result.ToArray();
        }
    }
}
