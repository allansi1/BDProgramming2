using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    static public class MyExtensions
    {
        static public string MyReverse(this string s)
        {

            return new string (s.Reverse ().ToArray());
        }


        static public Boolean IsPalindrome(this string s)
        {

            if (s == s.MyReverse())
            {
                return true;
            }
            else
            {
                return false;
            }
           

        }

    }
}
