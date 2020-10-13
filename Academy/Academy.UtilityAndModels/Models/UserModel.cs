using SQLite;
using System;

namespace Academy.UtilityAndModels.Models
{
    public class UserModel
    {
        [PrimaryKey]
        public int UserId { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
        public int Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long ContactNo { get; set; }
        public int Class { get; set; }
        public bool Audited { get; set; }
        public string AuditedString { get; set; }
        public string AuditedColor { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        [Ignore]
        public bool IsSync { get; set; }
    }
}
