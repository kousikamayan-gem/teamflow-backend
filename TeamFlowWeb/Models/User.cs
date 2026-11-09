using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlowWeb.Models
{
    public enum UserRole
    {
        Admin,
        Employee
    }
    public class User
    {
        // Id
        public int Id { get; set; }
        // Name
        public string Name { get; set; } = string.Empty;
        // Email
        public string Email { get; set; } = string.Empty;
        // PasswordHash
        public string PasswordHash { get; set; } = string.Empty;
        //User Role
        public UserRole Role { get; set; } = UserRole.Employee;
        // CreatedAt
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
