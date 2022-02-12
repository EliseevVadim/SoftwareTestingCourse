using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ProductionCode
{
    public class StringFormatter
    {
        public StringFormatter()
        {

        }

        public string WebString(string s)
        {
            if (s.EndsWith(".git"))
                return @"git://" + s;
            if (s.StartsWith(@"http://") || s.StartsWith(@"https://") || s == string.Empty)
                return s;
            if (s == null)
                throw new NullReferenceException();
            return @"http://" + s;
        }
    }
}
