using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqExercise
{
    public class Person
    {
        public Person()
        {

        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> PhoneNumbers { get; set; }

        public static List<Person> GetPersons()
        {
            List<Person> people = new List<Person>() {
                new Person {FirstName="Sean", LastName="Peterson"},
                new Person {FirstName="John", LastName="Henderson"},
                new Person {FirstName="Green", LastName="Brown"}
            };
            return people;
        }
    }
}