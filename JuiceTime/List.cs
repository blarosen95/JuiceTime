using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuiceTime
{
    internal static class List
    {
        public static List<T> Of<T>(params T[] args) => new List<T>(args);
    }
}
