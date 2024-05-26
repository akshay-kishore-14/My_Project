using System.Numerics;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class UserView
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }

        public string Password { get; set; }

        public IFormFile Image { get; set; }

        public string FilePath { get; set; }

        public string check_email { get; set; }

        public string check_pass { get; set; }

        public string email_valid { get; set; }

    }

    public class CountryDetails
    {
        public string CountryName { get; set; }
    }

    public class StateDetails
    {
        public string StateName { get; set; }
    }

    public class CityDetails
    {
        public string CityName { get; set; }
    }
}
