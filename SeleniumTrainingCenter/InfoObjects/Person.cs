using System;
using SeleniumTrainingCenter.InfoObjects.Enums;

namespace SeleniumTrainingCenter.InfoObjects
{
    public class Person
    {
        public Titles Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
