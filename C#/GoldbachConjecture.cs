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

                    }//get all the primes
                }
        if (a == 2)//if a = 2, then it has only 2 divisors, then i want you to return a
        {
        return n;
        }

            return 0;

            
        }

        static void Main()
        {
            List<int> goldbachlist = new List<int>();
            for (int i=1; i < 30; i++) //get the primes for each number, except 2
            {
                
                goldbachlist.Add(Goldbach_Conjecture(i));
                goldbachlist.Remove(0); //removes elements that are 0

            }
            foreach(int i in goldbachlist)
            {

                System.Console.WriteLine(i); //write this to console, so that i can see output
                

            }

            List<int> twice = new List<int>();
            for(int i = 0; i < goldbachlist.Count()-1; i++) //ad it to the twice list, because it is where we will add the primes up, to see if they are even
            {
                int k = i;
                int m = i + 1;
                twice.Add(goldbachlist[k] + goldbachlist[m]);

                
                


            }
            
            foreach (int i in twice)
            {
                if (i % 2 == 0){ //this gets the even numbers in twice, thus completeing goldbach

                    System.Console.WriteLine(i);
                }


            }
            Console.ReadKey();

        }

    }
}
