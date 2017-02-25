using System;

namespace PrasannaNeons.DataEntities
{
    public class CustomerUser : BaseEntity<Int32>
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}
