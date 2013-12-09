using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;
using EmployeeMVC.Entities;
using Mappings;

namespace SessionFactoryHelper
{
    public static class NHibernateHelper
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
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(ConfigurationManager.ConnectionStrings["database"].ConnectionString).ShowSql())
                //.Mappings(b => b.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .BuildSessionFactory();
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
