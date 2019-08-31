using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLeague
{
    public static class EnumerableExtension
    {

        public static void Shuffle<T>(this IEnumerable<T> source)
        {
            source.OrderBy(x => Guid.NewGuid());
        }

       

       
    }
}
