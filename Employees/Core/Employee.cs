﻿
using System;

namespace Core
{ 
    public interface IGreetingService
    {
        void SayGreeting(string greeting);
    }

    public class RedGreetingService : IGreetingService
    {
        public void SayGreeting(string greeting)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(greeting);
        }
    }

    public class GreetingService : IGreetingService
    {
        public void SayGreeting(string greeting)
        {
            Console.WriteLine(greeting);
        }
    }

    public class Human : Object
    {
        public Human(string name, 
                    IGreetingService greetingService)
            : base()
        {
            Name = name;
            this.greetingService = greetingService;
        }

        private string _name;
        private readonly IGreetingService greetingService;

        public string Name
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
            get
            {
                return _name.ToUpper();
            }
        }

        public void SayHello()
        {
            greetingService.SayGreeting(Name);
        }
        
    }

    public class Employee : Human
    {


        public Employee(int id, string name, 
                IGreetingService greetingService)
            : base(name, greetingService)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }        
    }

    public class Customer : Human
    {
        public Customer(string name, 
            IGreetingService greetingService) 
            : base(name, greetingService)
        {
        }
    }
}


