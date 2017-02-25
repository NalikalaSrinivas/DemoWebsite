using FluentNHibernate.Mapping;
using PrasannaNeons.DataEntities;

namespace PrasannaNeons.Data
{
    public class CustomerUserMap : ClassMap<CustomerUser>
    {
        public CustomerUserMap()
        {
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.Password);
        }
    }
}
