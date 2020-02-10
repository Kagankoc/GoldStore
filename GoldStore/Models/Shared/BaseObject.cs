using System;

namespace GoldStore.Models.Shared
{
    public class BaseObject
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
