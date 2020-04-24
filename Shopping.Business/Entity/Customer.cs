using System;
namespace ShoppingCart.Business.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Customer()
        {

        }
        
        public Customer (int id, string firstName, string middleName, string lastName,
                         string gender, string contactNo, string email, string address)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
            ContactNo = contactNo;
            Email = email;
            Address = address;
        }
        
    }
}
