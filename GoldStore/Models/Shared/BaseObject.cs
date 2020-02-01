using System;

namespace GoldStore.Models.Shared
{
    public class BaseObject
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
