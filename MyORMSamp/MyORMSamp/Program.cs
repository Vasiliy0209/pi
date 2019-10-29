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
            var Ivan = new Employee
            {
                Name = "Vasya",
                Age = 20,
                Email = "vasya@mail.ru"
            };

            var cfg = new Configuration();            
            cfg.Configure();           
            cfg.AddAssembly("MyORMSamp");

            ISessionFactory _sessionFactory;
            _sessionFactory = cfg.BuildSessionFactory();

            ISession session = _sessionFactory.OpenSession();

            //Создание нового объекта (C)
           // session.Save(Ivan);
            //session.Flush();

            //Чтение списка объектов (всех записей из таблицы БД) (R)
            IList<Employee> employees = session.CreateCriteria(typeof(Employee)).List<Employee>();
            foreach (Employee employee in employees)
                Console.WriteLine(employee.ID+" "+employee.Name);

            //Обновление информации о существующем объекте (U)
            employees[0].Name = "Updated person";
            session.Update(employees[0]);
            session.Flush();

            //Удаление
            session.Delete(employees[0]);
            session.Flush();


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
