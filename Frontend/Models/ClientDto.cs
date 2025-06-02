using System;

namespace BlazorApp.Models;

public class ClientDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; // New, Lead, Seasonal, Permanent, Inactive
}
