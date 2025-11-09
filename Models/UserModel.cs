using OpenQA.Selenium;

namespace Wrappers.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Adress1 { get; set; }
        public string City { get; set; }
        public string Postcod { get; set; }

        public UserModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public UserModel(string firstName, string lastName, string phone,
            string adress1, string city, string postcod)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Adress1 = adress1;
            City = city;
            Postcod = postcod;
        }
    }
}
