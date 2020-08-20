using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponent.Client.InterApp.Utilities
{
    public static class ListUtilities
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int listIdx = list.Count;
            while (listIdx > 1)
            {
                listIdx--;
                int k = rng.Next(listIdx + 1);
                T value = list[k];
                list[k] = list[listIdx];
                list[listIdx] = value;
            }
        }
    }

}
