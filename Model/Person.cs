using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace PersonManagmentAPI.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
