using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MyORMSamp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Инициализация NHibernate
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly("MyORMSamp");

            ISessionFactory _sessionFactory;
            _sessionFactory = cfg.BuildSessionFactory();
            ISession session = _sessionFactory.OpenSession();

           

            Console.ReadLine();
        }

        static void InitHibernate()
        {
            //Создание таблицы БД на основе
            //файлов ORM-отображения (маппинга)
            var cfg = new Configuration();
            //Считывание и обработка файла hibernate.cfg.xml
            cfg.Configure();
            //Привязка к сборке, содержащей объекты ORM
            cfg.AddAssembly("MyORMSamp");
            //Собственно создание таблиц
            new SchemaExport(cfg).Execute(true, true, false);
        }
    }
}
