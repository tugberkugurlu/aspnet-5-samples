using System;
using ClassLib;

namespace ClassLibRef 
{
    public static class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine(new Chatter().GetMessage());   
        }
    }
}