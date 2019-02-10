using System.Collections.Generic;

namespace JuiceTime
{
    internal static class List
    {
        public static List<T> Of<T>(params T[] args) => new List<T>(args);
    }
}
