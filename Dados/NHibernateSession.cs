using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using System.Reflection;
using NHibernate;
using NHibernate.Mapping.Attributes;
using System.IO;
using System.ComponentModel;

namespace Dados
{
    public class NHibernateSession
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration().
                                            Configure().
                                            AddInputStream(HbmSerializer.Default.Serialize(Assembly.LoadFrom(System.Environment.CurrentDirectory + @"\Entidades.dll")));// typeof(Entidades.TramInformacoes)));

                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
