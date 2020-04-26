using System;
using System.Collections.Generic;

namespace AdvancePhonebook.Models
{
    public partial class Enterprises
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
