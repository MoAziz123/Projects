using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public Program()
        {


        }
        public static int Goldbach_Conjecture(int n)
        {

            int a = 0;
                for (int i = 1; i < n + 1; i++)
                {
                    if (n % i == 0)
                    {
                        a++;

                    }
                }
        if (a == 2)
        {
        return n;
        }

            return 0;

            
        }

        static void Main()
        {
            List<int> goldbachlist = new List<int>();
            for (int i=1; i < 30; i++)
            {
                
                goldbachlist.Add(Goldbach_Conjecture(i));
                goldbachlist.Remove(0); //removes elements that are 0

            }
            foreach(int i in goldbachlist)
            {

                System.Console.WriteLine(i);
                

            }

            List<int> twice = new List<int>();
            for(int i = 0; i < goldbachlist.Count()-1; i++)
            {
                int k = i;
                int m = i + 1;
                twice.Add(goldbachlist[k] + goldbachlist[m]);

                
                


            }
            
            foreach (int i in twice)
            {
                if (i % 2 == 0){

                    System.Console.WriteLine(i);
                }


            }
            Console.ReadKey();

        }

    }
}
