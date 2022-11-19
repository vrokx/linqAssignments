using System;
using System.Linq;

namespace LinqAssignment
{

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public Employee(int EmployeeId, string FirstName, string LastName, string Title, DateTime DOB, DateTime DOJ, string City)
        {
            this.EmployeeID = EmployeeId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.DOB = DOB;
            this.DOJ = DOJ;
            this.City = City;
        }
        public override string ToString()
        {
            return EmployeeID + " ---- " + FirstName + " " + LastName + " ---- " + Title + " ---- " + DOB + " ---- " + DOJ + " ---- " + City;
        }


    }

    public class Program
    {


        public static void Main()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee(1001,"Malcolm","Daruwalla","Manager",new DateTime(1984/11/16),new DateTime(2011/06/08),"Mumbai"),

                new Employee(1002,"Asdin"  ,"Dahlla"   ,"AsstManager",new DateTime(1984/08/20),new DateTime(2012/07/07),"Mumbai"),

                new Employee(1003,"Madahvi",  "Oza"    ,"Consultant",new DateTime(1987/11/14),new DateTime(2015/04/2015),"Pune"),

                new Employee(1004,"Saba",   "Saikh" ,"SE",new DateTime(1990/11/14),new DateTime(2015/04/12),"Pune"),

                new Employee(1005,"Nazia"  ,   "Shaikh","SE",new DateTime(1991/03/08),new DateTime(2016/02/02),"Mumbai"),

                new Employee(1006,"Amit"   ,  "Pathak" ,"Consultant", new DateTime(1998/11/07),new DateTime(2014/08/08),"Chennai"),

                new Employee(1007,"Vijay"  , "Natrajan","Consultant",new DateTime(1998/12/02),new DateTime(2015/06/01),"Mumbai"),

                new Employee(1008,"Rahul" ,   "Dubey" ,"Associate",new DateTime(1993/11/11),new DateTime(2014/11/06),"Chennai"),

                new Employee(1009,"Suresh",  "Mistry" ,"Associate",new DateTime(1992/08/12),new DateTime(2014/13/03),"Chennai"),

                new Employee(1010,"Sumit" ,"Shah" ,"Manager",new DateTime(1991/04/12),new DateTime(2016/01/02),"Pune")

          };

            Console.WriteLine("a. Display Details of all the employee");
            IEnumerable<Employee> result = from i in list select i;
            foreach (Employee e in result)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("====================================================================");

            Console.WriteLine("b. Display details of all Employee whose location is not Mumbai.");
            var task2 = from i in list
                        where i.City != "Mumbai"
                        select i;
            foreach (Employee e in task2)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("====================================================================");

            Console.WriteLine("c. Display details of all Employee whose Tittle is AsstManager ");
            var task3 = from i in list
                        where i.Title == "AsstManager"
                        select i;
            foreach (Employee e in task3)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("====================================================================");

            Console.WriteLine("d.Display details of all Employee whose LastName Start ith S");
            var task4 = from i in list
                        where i.LastName.StartsWith("S")
                        select i;
            foreach (Employee e in task4)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("====================================================================");

            Console.WriteLine("e.Display details of all Employee whose have joined before 1/1/2015");
            var task5date = new DateTime(2015/01/01);
            var task5 = from i in list
                        where i.DOJ >= task5date
                        select i;
            Console.WriteLine("\n");
            Console.WriteLine("====================================================================");

            Console.WriteLine("g. Display list of all employee whose designation is Consultant & Associative");
            var task6 = from i in list
                        where i.Title.Contains("Consultant") || i.Title.Contains("Associative")
                        select i;
            foreach (Employee e in task6)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("====================================================================");

            Console.WriteLine("h. Display total number of Employee");
            int task7 = list.Count();
            Console.WriteLine(task7);
            Console.WriteLine("====================================================================");

            Console.WriteLine("i. Display total number belonging to Chennai ");
            var task8 = from i in list
                        where i.City == "Chennai"
                        select i;
            int task8Num = task8.Count();
            Console.WriteLine(task8Num);
            Console.WriteLine("====================================================================");

            Console.WriteLine("j. Display Highest Employee Id in List");
            int task9 = list.Max(m => m.EmployeeID);
            Console.WriteLine(task9);
            Console.WriteLine("====================================================================");

            Console.WriteLine("k. Display total numbere of Employee joined after 1/1/2015 ");
            Console.WriteLine("...");
            Console.WriteLine("====================================================================");

            Console.WriteLine("l. Display Total Number Of Employee whose designation not Associate");
            int task11 = (from i in list
                          where i.Title != "Associate"
                          select i).Count();
            Console.WriteLine(task11);
            Console.WriteLine("====================================================================");

            Console.WriteLine("m. Display total number of Employee Based on city.");
            var task12 = from i in list group i by i.City;
            foreach (var e in task12)
            {
                Console.WriteLine("{0}-{1}", e.Key, e.Count());
            }
            Console.WriteLine("====================================================================");

            Console.WriteLine("n. display total number of employee based on city and Tittle");
            var task13 = from i in list
                         group i by new { i.City, i.Title } into t
                         orderby t.Key.City
                         select new { City = t.Key.City, Title = t.Key.Title, TotalCount = t.Count() };
            foreach (var e in task13)
            {
                if (e.TotalCount > 1)
                {

                    Console.WriteLine("Total Number of Employee based On City & Title : {0}-{1}-{2}", e.City, e.Title, e.TotalCount);
                }
            }
            Console.WriteLine("====================================================================");
            Console.ReadLine();

        }
    }
}