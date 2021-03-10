using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "  Bob    Loves  Alice   ";
            Console.WriteLine("input is = {0}", input);
            var output = ReverseWord(input);
            Console.WriteLine("Output is = {0}", output);
        }

        public static string ReverseWord(string s)
        {
            var arr = s.ToCharArray();
            var length = arr.Length;
            // 1. reverse the string.
            Reverse(arr, 0, length - 1);
            // 2. reverse the word.
            ReverseWord(arr, length);
            // 3. remove extra spaces.
            return RemoveSpace(arr, length);
        }

        static void Reverse(char[] arr,int l, int r)
        {
            while(l < r)
            {
                char t = arr[l];
                arr[l] = arr[r];
                arr[r] = t;
                l++;
                r--;
            }
        }

        static void ReverseWord(char[] arr, int n)
        {
            int i = 0, j = 0;
            while(j < n)
            {
                while (i < j || i < n && arr[i] == ' ') i++;
                while (j < i || j < n && arr[j] != ' ') j++;
                Reverse(arr, i, j - 1);
            }
        }

        static string RemoveSpace(char[] arr, int n)
        {
            int i = 0, j = 0;
            while (j < n)
            {
                while (j < n && arr[j] == ' ') j++;
                while (j < n && arr[j] != ' ')
                {
                    arr[i++] = arr[j++];
                }
                while (j < n && arr[j] == ' ') j++;
                if (j < n) arr[i++] = ' ';
            }

            return string.Join("", arr).Substring(0, i);
        }
    }
}
