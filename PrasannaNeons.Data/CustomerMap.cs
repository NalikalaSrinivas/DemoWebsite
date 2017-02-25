using FluentNHibernate.Mapping;
using PrasannaNeons.DataEntities;

namespace PrasannaNeons.Data
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            //Table
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
