using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	public class Sort
	{
        public static int existsInSortedLoopCounter;
        public static bool ExistsInSorted(int[] array, int target)
        {
            // Använd algoritmen för binärsökning:
            // Räkna ut mittersta elementet
            // Om vi hittade målet - returnera
            // Finns target i vänstra eller högra halvan? 
            // Välj ut den halva som målet finns i, släng bort resten
            // Upprepa!
            existsInSortedLoopCounter = 0;

            int low = 0, high = array.Length;
            while( high > low )
			{
                existsInSortedLoopCounter++;
                int mid = (low + high) / 2;
                if (array[mid] == target)
				{
                    return true;
				}
                else if (array[mid] < target)
				{
                    low = mid + 1;
				}
                else
				{
                    high = mid - 1;
				}
			}
            return false;
        }
    }
}
