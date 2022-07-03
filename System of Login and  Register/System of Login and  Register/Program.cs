using System;
using System.Collections.Generic;

namespace System_of_Login_and__Register
{
    class Program
    {
        public static List<Person> Persons { get; set; } = new List<Person>()
        {
            new Person("super", "admin", " admin@gmail.com ",123321)
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Commands : ");
            Console.WriteLine("/register");
            Console.WriteLine("/login");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter Command : ");
                string command = Console.ReadLine();
                if (command == "/register")
                {

                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();
                    Validation.IsNameLengthTrue(name);


                    Console.Write("Please add person's surname :");
                    string lastname = Console.ReadLine();
                    Validation.IsLastnameLengthTrue(lastname);

                    Console.Write("Please add person's Email :");
                    string email = Console.ReadLine();
                    Validation.IsEmailCorrect(email);

                    Console.Write("Please add person's Password :");
                    string password = Console.ReadLine();
                    Console.Write("Please add person's Password again :");
                    string password2 = Console.ReadLine();
                    Validation.IsPasswordCorrect(password, password2);


                    Person person = RegisterPerson(name, lastname, email, password, password2);

                    Console.WriteLine(person.GetRegisterInfo() + " - Added to system.");
                    Console.WriteLine("You successfully registered, now you can login with your new account!");

                }
                else if (command == "/login")
                {
                    Console.Write("Please add person's Email :");
                    string email = Console.ReadLine();
                    Validation.IsEmailCorrect(email);

                    Console.Write("Please add person's Password :");
                    string password = Console.ReadLine();
                    string password2 = Console.ReadLine();
                    Validation.IsPasswordCorrect(password, password2);

                    Person person = LoginPerson(email, password, password2);

                    Console.WriteLine(person.GetLoginInfo() + " " + "Welcome to your account !");
                }
            }
        }
        public static Person RegisterPerson(string name, string lastname, string email, string password, string password2)
        {
            Person person = new Person(name, lastname, email, password, password2);
            Persons.Add(person);
            return person;
        }
        public static Person LoginPerson(string email, string password, string password2)
        {
            Person person = new Person(email, password, password2);
            Persons.Add(person);
            return person;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }

        public Person(string name, string lastname, string email, string password, string password2)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
            Password2 = password2;
        }

        public Person(string email, string password, string password2)
        {
            Email = email;
            Password = password;
            Password2 = password2;
        }

        public Person(string email, string password, string password2, int v) : this(email, password, password2)
        {
        }

        public string GetRegisterInfo()
        {
            return Name + " " + Lastname + " " + Email;
        }
        public string GetLoginInfo()
        {
            return Name + " " + Lastname;
        }
    }
    class Validation : Person
    {
        public Validation(string name, string lastname, string email, string password, string password2) : base(name, lastname, email, password, password2)
        {
        }

        public static bool IsNameLengthTrue(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name.Length >= 3 && name.Length <= 30)
                {

                    return true;
                }
                else
                {
                    Console.WriteLine("Name only should be between 3-30");
                    return false;
                }
            }
            return false;
        }
        public static bool IsLastnameLengthTrue(string lastname)
        {
            for (int i = 0; i < lastname.Length; i++)
            {
                if (lastname.Length >= 5 && lastname.Length <= 20)
                {

                    return true;
                }
                else
                {
                    Console.WriteLine("Name only should be between 5-20");
                    return false;
                } 
            }
            return false;
        }
        public static bool IsEmailCorrect(string email)
        {
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    return true;
                }
            }
            Console.WriteLine("Please write email correctly");
            return false;
        }
        public static bool IsPasswordCorrect(string password, string password2)
        {
            if (password == password2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Passwords is not same");
            }
            return false;
        }
    }
}
