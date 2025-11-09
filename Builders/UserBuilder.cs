using Wrappers.Models;

namespace Wrappers.Builders
{
    public class UserBuilder
    {
        private string userName = "";
        private string userPassword = "";
        private string firstName = "";
        private string lastName = "";
        private string phone = "";
        private string adress1 = "";
        private string city = "";
        private string postcod = "";

        public UserBuilder WithName(string name = "")
        {
            userName = name;
            return this;
        }

        public UserBuilder WithPassword(string password = "")
        {
            userPassword = password;
            return this;
        }

        public UserModel Build()
        {
            return new UserModel(userName, userPassword);
        }
        public UserBuilder WithFirstName(string name1 = "")
        {
            firstName = name1;
            return this;
        }

        public UserBuilder WithLasttName(string name2 = "")
        {
            lastName = name2;
            return this;
        }

        public UserBuilder WithPhone(string phone1 = "")
        {
            phone = phone1;
            return this;
        }

        public UserBuilder WithAdress1(string adress = "")
        {
            adress1 = adress;
            return this;
        }

        public UserBuilder WithCity(string city1 = "")
        {
            city = city1;
            return this;
        }

        public UserBuilder WithPostcod(string postcod1 = "")
        {
            postcod = postcod1;
            return this;
        }

        public UserModel BuildForOrder()
        {
            return new UserModel(firstName, lastName, phone, adress1, city, postcod);
        }
    }
}
