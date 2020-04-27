using System;
using System.Collections.Generic;

namespace AdvancePhonebook.Models
{
    public partial class Descriptions
    {
        public long Id { get; set; }
        public string Topic { get; set; }
        public long? ContactId { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual Contacts Contact { get; set; }
    }
}
