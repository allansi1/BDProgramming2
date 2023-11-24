using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            string word = "radar";
            bool isPalindrome = word.IsPalindrome();
            Console.WriteLine(isPalindrome);
            Console.ReadKey();

        }
    }
}
