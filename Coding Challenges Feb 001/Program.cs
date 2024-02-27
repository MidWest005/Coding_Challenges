namespace Coding_Challenges_Feb_001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
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


        /*
         Sum of two Udemy Challenge

        This time you have to write a method that will take two arguments: 
        a list of integers nums and an integer SumToFind. 
        And it returns the number of possible UNIQUE pares made from this list 
        where the sum equals to SumToFind



        Example:

        SumOfTwo([1, 1, 1, 2, 3, 4, 5, 2], 2)

        It should return: 1
        Explanation: there is only one pair sum of witch is equal to 2 (1,1)

        ATTENTION: The main trick of this exercise is that its time complexity should be linear. 
        That means you should NOT have any double/triple loops inside or deep recursion.
         */
        public static int SumOfTwo(int[] nums, int SumToFind)
        {
            int pairs = 0;
            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            dic.Add(nums[0], false);

            for (int i = 1; i < nums.Length; i++)
            {
                int target = SumToFind - nums[i];
                if (dic.ContainsKey(target))    //1,1,2,3,4,5  
                {
                    if (dic[target] == false)
                    {
                        dic[target] = true;
                        pairs++;
                    }
                }
                else
                {
                    if (!dic.ContainsKey(nums[i]))
                    {
                        dic.Add(nums[i], false);
                    }
                }
            }

            return pairs;

        }

        /*
         Mountains or Valleys Edabit Very Hard. There is a WAY better solution lol
        A mountain is an array with exactly one peak.

        All numbers to the left of the peak are increasing.
        All numbers to the right of the peak are decreasing.
        The peak CANNOT be on the boundary.
        A valley is an array with exactly one trough.

        All numbers to the left of the trough are decreasing.
        All numbers to the right of the trough are increasing.
        The trough CANNOT be on the boundary.
        Some examples of mountains and valleys:

        Mountain A:  [1, 3, 5, 4, 3, 2]   // 5 is the peak
        Mountain B:  [-1, 0, -1]   // 0 is the peak
        Mountain B:  [-1, -1, 0, -1, -1]   // 0 is the peak (plateau on both sides is okay)

        Valley A: [10, 9, 8, 7, 2, 3, 4, 5]   // 2 is the trough
        Valley B: [350, 100, 200, 400, 700]  // 100 is the trough
        Neither mountains nor valleys:

        Landscape A: [1, 2, 3, 2, 4, 1]  // 2 peaks (3, 4), not 1
        Landscape B: [5, 4, 3, 2, 1]  // Peak cannot be a boundary element
        Landscape B: [0, -1, -1, 0, -1, -1]  // 2 peaks (0)
        Based on the rules above, write a function that takes in an array and returns either "mountain", "valley", or "neither".

        Examples
        LandscapeType([3, 4, 5, 4, 3]) ➞ "mountain"

        LandscapeType([9, 7, 3, 1, 2, 4]) ➞ "valley"

        LandscapeType([9, 8, 9]) ➞ "valley"

        LandscapeType([9, 8, 9, 8]) ➞ "neither"

        Notes:
        A peak is not exactly the same as the max of an array. The max is a unique number, but an array may have multiple peaks. 
        However, if there exists only one peak in an array, then it is true that the peak = max.
        See comments for a hint.
         */



        public static string LandscapeType(int[] arr)
        {
            int rP = arr.Length - 1;
            int lP = 0;
            bool Done = false;

            while (Done == false)
            {
                bool moved = true;
                if (arr[rP] <= arr[rP - 1])
                {
                    rP--;
                    moved = false;
                }
                if (rP == 0 || moved == true)
                {
                    Done = true;
                }
            }

            Done = false;
            while (Done == false)
            {
                bool moved = true;
                if (arr[lP] <= arr[lP + 1])
                {
                    lP++;
                    moved = false;
                }
                if (lP == arr.Length - 1 || moved == true || lP >= rP)
                {
                    Done = true;
                }
            }
            if (rP == lP && rP != 0 && rP != arr.Length - 1)
            {
                return "mountain";
            }
            rP = arr.Length - 1;
            lP = 0;
            Done = false;
            while (Done == false)
            {
                bool moved = true;
                if (arr[rP] >= arr[rP - 1])
                {
                    rP--;
                    moved = false;
                }
                if (rP == 0 || moved == true)
                {
                    Done = true;
                }
            }

            Done = false;
            while (Done == false)
            {
                bool moved = true;
                if (arr[lP] >= arr[lP + 1])
                {
                    lP++;
                    moved = false;
                }
                if (lP == arr.Length - 1 || moved == true || lP >= rP)
                {
                    Done = true;
                }
            }
            if (rP == lP && rP != 0 && rP != arr.Length - 1)
            {
                return "valley";
            }

            return "neither";
        }

        /*  Longest Abecedarian Word
                An abecedarian word is a word where all of its letters are arranged in 
                alphabetical order. Examples of these words include:

                *Empty
                *Forty
                *Almost
            Given an array of words, create a function which returns the longest abecedarian word. 
            If no word in an array matches the criterea, return an empty string.

                Notes:
            All words will be given in lowercase.
            If two abecedarian words have the same length, return the word which appeared first in the array.
         */


        public static string LongestAbecedarian(string[] arr)
        {
            string longest = "";
            foreach (var i in arr)
            {
                char[] temp = i.ToCharArray();
                Array.Sort(temp);
                string tempString = String.Join("", temp);

                if (tempString.Equals(i) && (i.Length > longest.Length || longest.Length == 0))
                {
                    longest = tempString;
                }
            }

            return longest;
        }
        /* Cats and Food Udemy
         
            So imagine you are in a kitchen that is full of cats. 
            Every typical hungry cat will follow you if you hold some food, right?

            Our goal is to count not hungry cats in the kitchen.

            You with food in the kitchen will be marked as F

            Every cat will be represented as ~O or O~ depending on the direction.


            Examples:

            Input: "~O~O~O~O F"
            Return: 0 (all cats follow you)


            Input: "O~~O~O~O F O~O~"
            Return: 1 (one is not following)

         */

        public static int NotHungryCats(string kitchen)
        {
            int count = 0;
            int goingLeft = 0;
            int goingRight = 0;
            Dictionary<char, bool> check = new Dictionary<char, bool>();
            check.Add('~', false);
            check.Add('O', false);


            for (int i = 0; i < kitchen.Length; i++)
            {
                if (kitchen[i] == '~')
                {
                    check['~'] = true;
                }
                if (kitchen[i] == 'O')
                {
                    check['O'] = true;
                }

                if (check['~'] && check['O'])
                {
                    if (kitchen[i] == '~')
                    {
                        goingRight++;
                    }
                    else
                    {
                        goingLeft++;
                    }
                    check['O'] = false;
                    check['~'] = false;
                }

                if (kitchen[i] == 'F')
                {
                    count = goingRight;
                    goingRight = 0;
                    goingLeft = 0;
                }
            }

            return count + goingLeft;
        }

        /* Same Letter Patterns V.Hard Edabit
            Create a function that returns true if two strings share the same letter pattern, and false otherwise.

            Examples:
            SameLetterPattern("ABAB", "CDCD") ➞ true

            SameLetterPattern("ABCBA", "BCDCB") ➞ true

            SameLetterPattern("FFGG", "CDCD") ➞ false

            SameLetterPattern("FFFF", "ABCD") ➞ false
         
         */

        public static bool SameLetterPattern(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            int unq = 1;
            int tic = 0;
            bool run = true;
            Dictionary<char, int> order = new Dictionary<char, int>();
            string[] foo = { str1, str2 };
            int[] pattern = new int[str1.Length];
            string pat1 = "";
            string pat2 = "";

            for (int i = 0; i < str1.Length; i++)
            {
                if (order.ContainsKey(foo[tic][i]))
                {
                    pattern[i] = order[foo[tic][i]];
                }
                else
                {
                    order.Add(foo[tic][i], unq);
                    unq++;
                    pattern[i] = order[foo[tic][i]];
                }
                if (run && i == str1.Length - 1)
                {
                    order.Clear();
                    i = -1;
                    unq = 1;
                    run = false;
                    tic++;
                    pat1 = string.Join("", pattern);
                }
            }
            pat2 = string.Join("", pattern);
            return pat1.Equals(pat2);
        }

    }
}