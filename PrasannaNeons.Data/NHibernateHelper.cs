using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace PrasannaNeons.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)

                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            try
            {
                _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString("Data Source=(local);Initial Catalog=PrasannaNeons;Integrated Security=True;")
                        .ShowSql()
                    )
                    .Mappings(m =>
                        m.FluentMappings
                            .AddFromAssemblyOf<CustomerMap>())
                    .ExposeConfiguration(cfg => new SchemaExport(cfg)
                        .Create(false, false))
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
