using System;

namespace Customer.Core.Domain.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public BaseModel()
        {
            DateCreated = DateTime.Now;
        }
    }
}