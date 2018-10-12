using System;
using System.Text;

namespace SolidCode
{
    class Program
    {
        static void Main(string[] args)
        {
    
            // Although string is a reference type, the equality operators(== and !=) are defined to compare the values of string objects, not references
            
            // -> with string interning, we can store strings in the intern pool, a set of unique strings we can reference at runtime
            StringAllocation.SameObject();
            
            // -> the content of the strings are equivalent, but a and b do not refer to the same string instance
            StringAllocation.DifferentObject();

            //Strings are immutable--the contents of a string object cannot be changed after the object is created
            StringAllocation.Gc();

            StringAllocation.StringConcatenation();
            StringAllocation.StringBuilderConcatenation();
        }

      


    }

    public static class StringAllocation
    {
        public static void SameObject()
        {
            string a = "hello";
            string b = "hello";
            Console.WriteLine(a == b);
            Console.WriteLine(a == (object)b);
        }

        public static void DifferentObject()
        {
            string a = "hello";
            string b = "h";
            // Append to contents of 'b'  
            b += "ello";
            Console.WriteLine(a == b);
            Console.WriteLine(a == (object)b);
        }

        /// <summary>
        /// For example, when you write this code, the compiler actually creates a new string object to hold the new sequence of characters, and that new object is assigned to b.
        /// The string "h" is then eligible for garbage collection.
        /// </summary>
        public static void Gc()
        {
            //GC.TryStartNoGCRegion(4096, true);
            string b = "h";
            b += "ello";
            //GC.EndNoGCRegion();
        }

       public static void StringConcatenation(int stringLength = 500000)
        {
            var n = stringLength / 10;

            var s1 = "";
            for (int i = 0; i < n; i++)
            {
             s1 += "1234567890";
            }
            Console.WriteLine(s1);
        }


        public static void StringBuilderConcatenation(int stringLength = 500000)
        {
            var n = stringLength / 10;

            var sb1 = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb1.Append("1234567890");
            }
            Console.WriteLine(sb1.ToString());
        }

        private static string GenerateString(int stringLength = 500000)
        {
            var n = stringLength / 10;
            var arr = new string[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = "123456789";
            }
            return string.Join(",", arr);
        }

    }
}
