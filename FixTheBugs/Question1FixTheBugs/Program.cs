using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1FixTheBugs
{
    #region Question 1
    /*
     * Logic wise, there should be braces around a and b
     * Result wise, it will always return integer and not double
     *
     */
    public class MathUtils
    {
        public static double Average(int a, int b)
        {
            return ((double)a + b )/ 2;
        }
    }

    public class Program
    {
        public static void Main(String[] ar)
        {
            while (true)
            {
                Console.Write("Enter the value for a (only integer numbers) : ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the value for b (only integer numbers) : ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nThe Average : " + MathUtils.Average(a, b) + "\n");
            }
        }
    }
    #endregion

}
