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


        /* Edabit Hard Reverse Coding Challenge #2
         
            This is a reverse coding challenge.

            Your task is to create a function that, when fed the inputs below,
            produce the sample outputs shown.

            Examples:
            3 ➞ 21

            9 ➞ 2221

            17 ➞ 22221

            24 ➞ 22228
         
         */
        public static int MysteryFunc(int num)
        {
            int ans = 0;
            int first = 1;
            int last = 0;
            bool isOver = false;

            do
            {
                if ((int)Math.Pow(2, first) > num)
                {
                    first--;
                    last = num % (int)Math.Pow(2, first);
                    isOver = true;
                }
                else
                {
                    first++;
                }
            } while (isOver == false);

            int temp = (int)Math.Pow(10, first);

            while (temp >= 10)
            {
                ans += temp * 2;
                temp /= 10;
            }
            return ans + last;
        }

        /* Edabit Hard Track the Robot (Part 1)
            A robot has been given a list of movement instructions. Each instruction is either left, right, up or down, 
             followed by a distance to move. The robot starts at [0, 0]. You want to calculate where the robot will end up 
            and return its final position as an array.

            To illustrate, if the robot is given the following instructions:

            new string[] { "right 10", "up 50", "left 30", "down 10" }
            It will end up 20 left and 40 up from where it started, so we return int[] { -20, 40 }.

            Examples:
            TrackRobot(new string[] { "right 10", "up 50", "left 30", "down 10" }) ➞ int[] { -20, 40 }

            TrackRobot(new string[] { }) ➞ int[] { 0, 0 }
            // If there are no instructions, the robot doesn't move.

            TrackRobot(new string[] { "right 100", "right 100", "up 500", "up 10000" }) ➞ new int[] { 200, 10500 }
            
            Notes:
            The only instructions given will be left, right, up or down.
            The distance after the instruction is always a positive whole number.
         */

        public static int[] TrackRobot(string[] instructions)
        {
            int[] dir = { 0, 0 };
            if (instructions.Length == 0)
            {
                return dir;
            }
            int move2 = 0;

            foreach (string i in instructions)
            {
                string arrow = i.Substring(0, i.LastIndexOf(' '));
                string move = i.Substring(i.LastIndexOf(' ') + 1, i.Length - i.LastIndexOf(' ') - 1);
                move2 = Convert.ToInt32(move);

                switch (arrow) //
                {
                    case "left":
                        dir[0] -= move2;
                        break;
                    case "right":
                        dir[0] += move2;
                        break;
                    case "up":
                        dir[1] += move2;
                        break;
                    default:
                        dir[1] -= move2;
                        break;
                }
            }
            return dir;
        }


    }
}