using System;
using Microsoft.EntityFrameworkCore;

namespace CRUDApp1.Models
{
    [Index("Email", IsUnique = true)]
    public class Client
    {
        public required string Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}
