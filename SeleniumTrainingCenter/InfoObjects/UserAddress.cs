namespace SeleniumTrainingCenter.InfoObjects
{
    public class UserAddress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public UserAddress(string fname, string lname, string address, string city, string state, string zip, string country, string phone)
        {
            FirstName = fname;
            LastName = lname;
            Address = address;
            City = city;
            State = state;
            PostalCode = zip;
            Country = country;
            Phone = phone;
        }
    }
}
