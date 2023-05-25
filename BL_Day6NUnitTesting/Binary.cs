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
            Console.WriteLine("Enter a number between from 0 to 255 : ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num<0 || num > 255)
            {
                Console.WriteLine("Input is not in range");
                return;
            }

            string binaryNum  = Util.NumberToBinary(num); // storing binary represention of given number
            
            //padding
            int len = binaryNum.Length;
            if (len < 8)
            {
                for (int i = 0; i < (8-len); i++)
                {
                    binaryNum = "0" + binaryNum;
                }
            }
            //swapping nibbles in binary num
            string nibbleSwappedBinaryNum = "";
            //Assigning second nibble
            for (int i = 4;i <8;i++)
            {
                nibbleSwappedBinaryNum = nibbleSwappedBinaryNum + binaryNum[i];
            }

            //Assigning first nibble
            for (int i = 0; i < 4; i++)
            {
                nibbleSwappedBinaryNum = nibbleSwappedBinaryNum + binaryNum[i];
            }

            int nibbleSwappedNum = 0;
            for (int i = 0; i < nibbleSwappedBinaryNum.Length/*8*/; i++)
            {
                if (nibbleSwappedBinaryNum[i] == '1')
                {
                    nibbleSwappedNum += (int)Math.Pow(2, nibbleSwappedBinaryNum.Length - i - 1);
                }
            }

            Console.WriteLine("Number after swapping nibbles is: {0}", nibbleSwappedNum);
        }
    }
}
