using System;
using System.Collections.Generic;

namespace AdvancePhonebook.Models
{
    public partial class Contacts
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? EnterpriseId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long? Line { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Group { get; set; }
        public string UserId { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
