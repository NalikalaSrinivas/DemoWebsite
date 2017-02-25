using System;

namespace PrasannaNeons.DataEntities
{
    public class Customer : BaseEntity<Int64>
    {
        public virtual string Name { set; get; }
    }
}
