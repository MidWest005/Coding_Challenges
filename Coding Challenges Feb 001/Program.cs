namespace Coding_Challenges_Feb_001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> player = new();

            player.Add("Jordan", 23);
            player.Add("Pippen", 33);

            Console.WriteLine($"{player["Jordan"]}"); //
        }



        /*Edabit Hard - Next Prime
             * Next Prime
            Given an integer, create a function that returns the next prime. If the number is prime, return the number itself.

            Examples:
            NextPrime(12) ➞ 13

            NextPrime(24) ➞ 29

            NextPrime(11) ➞ 11
            11 is a prime, so we return the number itself.
        */
        int NextPrime(int num)
        {
            bool isPrime = false;
            int tic = 0;
            do
            {
                tic = 0;
                for (int i = 2; i < num / 2 + 1; i++)
                {
                    if (num % i == 0)
                    {
                        tic++;
                        break;
                    }
                }
                num++;
            } while (tic > 0);

            return num - 1;
        }




        /*Edabit Hard - Sock Pairs
         * Joseph is in the middle of packing for a vacation. He's having a bit of trouble finding all of his socks, though.

            Write a function that returns the number of sock pairs he has. 
            A sock pair consists of two of the same letter, such as "AA". 
            The socks are represented as an unordered sequence.

            Examples
            SockPairs("AA") ➞ 1

            SockPairs("ABABC") ➞ 2

            SockPairs("CABBACCC") ➞ 4

            Notes:
            **If given an empty string (no socks in the drawer), return 0.
            **There can be multiple pairs of the same type of sock, such as two pairs of CC for the last example.
         */
        public static int SockPairs(string socks)
        {
            Dictionary<char, int> sockCount = new Dictionary<char, int>();
            foreach (var i in socks)
            {
                if (sockCount.ContainsKey(i))
                {
                    sockCount[i]++;
                }
                else
                {
                    sockCount.Add(i, 1);
                }
            }
            int foo = 0;
            foreach (var k in sockCount.Values)
            {
                foo += k / 2;
            }
            return foo;
        }

        /*Edabit Hard Consecutive Numbers
         * Create a function that determines whether elements in an array 
         * can be re-arranged to form a consecutive list of numbers where 
         * each number appears exactly once.

            Examples:

            Cons([5, 1, 4, 3, 2]) ➞ true
            // Can be re-arranged to form [1, 2, 3, 4, 5]

            Cons([5, 1, 4, 3, 2, 8]) ➞ false

            Cons([5, 6, 7, 8, 9, 9]) ➞ false
            // 9 appears twice
         * 
         * 
         */

        public static bool Cons(int[] arr)
        {
            bool ans = true;
            Array.Sort(arr);
            Dictionary<int, bool> foo = new Dictionary<int, bool>();
            foo.Add(arr[0], false);
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == (arr[i - 1] + 1) && foo.ContainsKey(arr[i]) == false)
                {
                    foo.Add(arr[i], false);
                }
                else
                {
                    ans = foo[arr[i - 1]];
                    break;
                }
            }

            return ans;
        }

    }
}