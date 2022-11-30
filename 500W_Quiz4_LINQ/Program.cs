using System;
using System.Collections.Generic;
using System.Linq;


namespace _500W_Quiz4_LINQ
{
    internal class Program
    {


        static void Main(string[] args)
        {

            //1.   Დაწერეთ პროგრამა რომელიც მასივში დაითვლის თითოეული  ელემენტი რამდენჯერ გვხვდება.

            int[] records = { 1, 3, 3, 4, 5, 5, 5, 5, 9, 10, 11, 11 };
         
            var countElms = from elm in records
                    group elm by elm into groupedElm
                    select groupedElm;
            foreach (var rec in countElms)
            {
                Console.WriteLine("Number " + rec.Key + " appears " + rec.Count() + " times");
            }
            Console.WriteLine("\n");


            //2.   Დაწერეთ პროგრამა რომელიც დაითვლის სტრინგში თითოეული სიმბოლო რამდენჯერ გვხვდება.

            //ნიკა იმედია სიმბოლოებში ყველა ჩარს გულისხმობ (მათ შორის ასოებს და რიცხვებს) და არა მხოლოდ პუნქტუაციურ ნიშნებს.

            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            text.ToCharArray();
         
            var matchQuery = from symbol in text
                             group symbol by symbol into goupedSymbol
                             select goupedSymbol;

            foreach (var symb in matchQuery)
            {
                if (symb.Key.Equals(' '))
                {
                    Console.WriteLine("Space "+ " appears " + symb.Count() + " times");
                }
                else
                {
                    Console.WriteLine("Symbol " + symb.Key + " appears " + symb.Count() + " times");
                }
            }
            Console.WriteLine("\n");


            //3.  Დაწერეთ პროგრამა რომელიც სტრინგში (წინადადებაში იპოვნის uppercase-იან სიტყვბს და დაბეჭდავს მათ)

            //ვერსია 1- როცა მხოლოდ მაღალი რეგისტრის ასოებს შეიცავს სიტყვები

            string str = "Lorem ipsum DOLAR sit amet, ConsecTetur adipiscing elit";

            var upWord = str.Split(' ')
                      .Where(u => String.Equals(u, u.ToUpper(),
                      StringComparison.Ordinal));

            Console.Write("\nThe UPPER CASE words are :\n ");
            foreach (string strRet in upWord)
            {
                Console.WriteLine(strRet);
            }
            Console.WriteLine("\n");


            //ვერსია 2 როცა ერთს მაინც მაღალი რეგისტრის ასოს შეიცავს სიტყვა

            string str2 = "Lorem ipsum dolaR Sit amet, consecTetur adipiscing elit";
            string[] upWord2 = str2.Split(' ');
            foreach (string strWord in upWord2)
            {
                IEnumerable<char> stringQuery =
                     from ch in strWord
                     where Char.IsUpper(ch)
                     select ch;

                foreach (char ch in stringQuery)
                if (strWord.Contains(ch.ToString()))
                {
                    Console.Write("\nThe words with the Upper Case Letter are :\n ");
                    Console.WriteLine(strWord);
                }
            }
            Console.WriteLine("\n");

            //4.  Დაწერეთ პროგრამა რომელიც დააბრუნებს მასივში x-დან y შუალედში ელემენტებს.

            int[] arr = { 1, 3, 3, 4, 5, 5, 5, 5, 9, 10, 11, 11 };
            int x = 4;
            int y = 9;

            int x1 = Array.IndexOf (arr, x);
            int y1 = Array.IndexOf(arr, y)-x+1;

            var range = from i in Enumerable.Range(x1, y1)
                        select arr[i];

            Console.WriteLine("the sequence from " + x + " to " + y + " is ");

            foreach (int i in range)
            {
                Console.Write(i +",");
            }

            Console.WriteLine("\n");



            //Დაწერეთ პროგრამა რომელიც დაბეჭდავს სტრინგში ყველაზე განმეორებად სიმბოლოს.

            string input = "Lorem ipsum dddddddddddddddolaR Sit amet, consecTetur adipiscing elit";
            var charGroups = (from c in input
                              group c by c into g
                              select new
                              {
                                  c = g.Key,
                                  count = g.Count(),
                              }).OrderByDescending(c => c.count).First();
            if (charGroups.c.Equals(' '))
            {
                Console.WriteLine("Space appears " + charGroups.count + " times");
            }
            else
            {
                Console.WriteLine("Symbol \"" + charGroups.c + "\" appears " + charGroups.count + " times");
            }
            Console.WriteLine("\n");
        }

    }

}
