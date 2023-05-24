using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Day6NUnitTesting
{
    internal class Binary
    {
        public static void SwapNibbles()
        {
            /*Console.WriteLine("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());*/
            string num = Util.NumberToBinary();
            String tempNum = "";

            //Assigning second nibble
            for (int i = 4;i <8;i++)
            {
                tempNum = tempNum + num[i];
            }

            //Assigning first nibble
            for (int i = 0; i < 4; i++)
            {
                tempNum = tempNum + num[i];
            }
            int nibbleSwappedNum = 0;
            for (int i = 0; i < tempNum.Length; i++)
            {
                if (tempNum[i] == '1')
                {
                    nibbleSwappedNum += (int)Math.Pow(2, tempNum.Length - i - 1);
                }
            }

            Console.WriteLine("Number after swapping nibbles is: {0}", nibbleSwappedNum);

            //return nibbleSwappedNum;
        }
    }
}
