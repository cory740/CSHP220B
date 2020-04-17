using CEby_Homework2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

//Cory Eby
//Week 2 Homework

namespace CEby_Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });


            Console.WriteLine("Starting Users:\n=============================");
            foreach (User uxUser in users)
            {
                Console.WriteLine("Name: {0}\nPassword: {1}\n-----------------------------", uxUser.Name, uxUser.Password);
            }


            var pwHelloQuery =
                 from uxUser in users
                 where uxUser.Password == "hello"
                 select uxUser.ToString();

            Console.WriteLine("\n\nUsers with a Password of hello:\n=============================");
            Console.WriteLine(string.Join(",", pwHelloQuery));

          // foreach (User user in pwHelloQuery)
          // {
          //     Console.WriteLine("Name: {0}\nPassword: {1}\n-----------------------------", user.Name, user.Password);
          // }

            users.RemoveAll(uxUser => uxUser.Password == uxUser.Name.ToLower());

            var firstHello = users.FirstOrDefault(uxUser => uxUser.Password == "hello");

            if (firstHello != null)
            {
                users.Remove(firstHello);
            }

            Console.WriteLine("\n\nRemaining Users:\n=============================");
            foreach(User uxUser in users)
            {
                Console.WriteLine("Name: {0}\nPassword: {1}\n-----------------------------", uxUser.Name, uxUser.Password);
            }
        }
    }
}
