using System;
using Customer.Core.Domain.Enums;

namespace Customer.Core.Domain.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string AccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}