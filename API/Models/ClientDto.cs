using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ClientDto
    {

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty; // New, Lead, Seasonal, Permanent, Inactive
    }

}

