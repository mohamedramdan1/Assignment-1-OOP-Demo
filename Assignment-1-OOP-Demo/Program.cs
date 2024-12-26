using System.ComponentModel;
using System.Security.AccessControl;
using System.Security.Claims;

namespace Assignment_1_OOP_Demo
{
    internal class Program
    {
        class Employee
        {
            public string Name;
            public int Age;
            public decimal Salary;
            public Gender gender;// male , female / 0 - 1
            public Roles roles;
            public Pirmisions primisions;
        }
        enum Gender
        {
            male  , female=3
        }
        enum Grades
        {
            A,B,C,F
        }
        enum Roles
        {
            Admin = 10 , Viwer = 20 , Editor = 30
        }
        [Flags]
        enum Pirmisions
        {
            Delete = 1 , Excute = 2 , Read= 4 , Write = 8
        }
        enum WeekDays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        public static void DosomecodeWithoutprotectcode()
        {
            try
            {
                int x, y, z;
                x = int.Parse(Console.ReadLine());// may have Format Exception

                y = int.Parse(Console.ReadLine());// may have Format Exception

                z = x / y;// may have Divided By Zero Exception

                int[] numbers = { 1, 2, 3 };

                numbers[10] = 100;//have  Index Out Of Range Exception
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DosomecodeWithprotectcode()
        {

            int x, y, z;
            bool Flag;
            do
            {
                Console.WriteLine("Enter the first num : ");
                Flag = int.TryParse(Console.ReadLine(), out x);
            }
            while (!Flag);

            do
            {
                Console.WriteLine("Enter the second num : ");
                Flag = int.TryParse(Console.ReadLine(), out y);
            }
            while (!Flag || y == 0);

            z = x / y;// may have Divided By Zero Exception

            int[] numbers = { 1, 2, 3 };
            if (numbers?.Length > 10)
            {
                numbers[10] = 100;

            }
        }
        static void Main(string[] args)
        {
            #region Demo
            #region Exception Handling Hirarcy
            // Exceptions
            // 1. System Exceptions
            //// 1.1 Format Exception
            //// 1.2 Index Out Of Range Exception
            //// 1.3 Null Reference Exception
            //// 1.4 Invalid Operation Exception
            //// 1.5 Arithmetic Exception
            ////  1.5.1 Divided By Zero Exception
            ////  1.5.2 Overflow Exception
            // 2. Application Exception

            //DosomecodeWithoutprotectcode();

            //try
            //{
            //    DosomecodeWithprotectcode();
            //    throw new Exception();// it make exception if there no error
            //}
            //catch(Exception eX)
            //{
            //    Console.WriteLine(eX.Message);     // try , catch not stop the code if there are exception or not 
            //}
            //finally
            //{
            //    // close , free , delete , deallocate 
            //    // open file
            //    //open connnection with DB
            //    Console.WriteLine("Finally");// work if have exception or not 
            //}
            //Console.WriteLine("after exception");
            #endregion

            #region Access Modifiers
            //From Less Accessible To Wider
            //1.Private
            //2.Private Protected
            //3.Protected
            //4.Internal
            //5.Protected Internal
            //6.Public

            //What You Can Write Inside Namespace ?
            //1.Class
            //2.Struct
            //3.Interface
            //4.Enum

            //Access Modifier Allowed Inside Namespace with (Class,Enum,Struct,Interface) ?
            //ex  internal class Program{} or  public class Program{}
            //1.Internal[Default] : if (Class,Enum,Struct,Interface) have Internal access modifer we can see in the same project only .
            //2.Public : if (Class,Enum,Struct,Interface) have Public access modifer we can see in the same project , and 
            // in other project but we must here make import to it ,
            //نستخد ال namespace بتاع الحاجه الى عاوز استخدمها وواخده  public

            //Access Modifier Allowed Inside Struct ?
            //1.Private[Default] 
            //2.Internal 
            //3.Public 

            //Access Modifier Allowed Inside Class?
            //Private[Default]
            //Private Protected
            //Protected
            //Internal
            //Protected Internal
            //Public

            //1.Private[Default] : use in class scope only
            //2.Internal : use in class scope and on any place on it is project
            //3.Public : use in class scope and it is project and in another project but using inport

            #endregion

            #region Enum
            //Enum it is special data type
            #region Ex01
            //Gender gender = Gender.male;
            //Console.WriteLine(gender);
            //Grades grads = Grades.A;
            //if (grads == Grades.B)
            //{
            //    Console.WriteLine(":)");
            //}
            //else
            //{
            //    Console.WriteLine(":(");
            //}
            #endregion

            #region Ex02
            //Grades grade = (Grades) 2;//Explicit casting 
            //Console.WriteLine(grade);//c
            //Grades grade = (Grades) 10;//Explicit casting unsave becouse if num 10 in enum grade dont fing the o/p is 10
            //Console.WriteLine(grade);//10
            #endregion

            #region Ex03
            // to take from value from user 
            //Grades garde = (Grades) Enum.Parse(typeof(Grades), Console.ReadLine());// but this way may have formate excption
            //Enum.TryParse(typeof(Grades), Console.ReadLine(),out object Result);  
            //Grades grade = (Grades)Result;// but this way not good becouse we do boxing and un boxing use the tryParese<>
            //Console.WriteLine(Result);
            //  Enum.Parse ret return object so we should make cast to enum to use it (Grades) Enum.Parse(typeof(Grades), Console.ReadLine());
            #endregion

            #region Ex04
            //string gender = "MALE";
            //Enum.TryParse(typeof(Gender), gender, out object Result);// old but not good becouse Boxing and un Boxing
            //Enum.TryParse<Gender>(gender, true, out Gender result);// true is mean ignore case [case senstive of enum]
            //Console.WriteLine(result);
            #endregion

            //Gender g = new Gender();
            //Console.WriteLine(g);// o/p is  defult value is 0 , beacouse Enum store like int in DB and d
            //                        // defult value of int is 0 so output is male 
            #endregion

            #region Permisions with enum
            //Employee emp = new Employee();
            //emp.Name = "Ali";
            //emp.Age = 10;
            //emp.primisions = (Pirmisions)3;
            //Console.WriteLine(emp.primisions);//delete , Eceute 
            // if we want to add or delete use ^ XOR
            //emp.primisions = emp.primisions ^ (Pirmisions)4;
            //Console.WriteLine(emp.primisions);//Delete, Excute, Read
            //emp.primisions = emp.primisions ^ (Pirmisions)4;
            //Console.WriteLine(emp.primisions);//Delete, Excute

            // &  and
            //Console.WriteLine(emp.primisions);//Delete, Excute
            //if ((emp.primisions & Pirmisions.Read )== Pirmisions.Read)
            //{
            //    Console.WriteLine("Read is exist");
            //}
            //else
            //{
            //   emp.primisions = emp.primisions ^ Pirmisions.Read;
            //}
            //Console.WriteLine(emp.primisions);

            // | or
            //emp.primisions = emp.primisions | Pirmisions.Delete;
            //Console.WriteLine(emp.primisions);
            #endregion

            #region Struct
            //point p01; // create varable in stck not refrences bocouse struct is value type
            //p01.x = 10;
            //p01.y = 20;
            //Console.WriteLine(p01.x);
            //Console.WriteLine(p01.y); // but we dont intalize the var like this we use constructor that
            // in struct
            //p01 = new point();  // the new take instance of constructor in struct and will take the defuilt here 
            //                    // becouse no paramter in this poubt() it is  paramter less constructor
            //                    // it is take all attribute and give it defult value
            //Console.WriteLine(p01.x);//0
            //Console.WriteLine(p01.y);//0

            //p01 = new point(2,7); // use the second constructor in the struct point()
            //Console.WriteLine(p01.x);//2
            //Console.WriteLine(p01.y);//7                     

            //Console.WriteLine(p01);
            #endregion
            #endregion

            #region Assignment
            #region Q1
            //Console.Write("Weekdays is : "); 
            //WeekDays[] days = (WeekDays[])Enum.GetValues(typeof(WeekDays));
            //for (int i = 0; i <days.Length ; i++)
            //{
            //    Console.Write($"{days[i]} ");   
            //}
            //Console.WriteLine(" ");
            #endregion

            #region Q2
            //Console.Write("Enter a season : ");
            //string season = Console.ReadLine();
            //Season result;
            //while (!Enum.TryParse<Season>(season, true, out  result) || int.TryParse(season, out _))// out_ mean if any number
            //{
            //    Console.Write("Invalid input. Please enter a valid season name : ");
            //    season = Console.ReadLine();
            //}
            //if (result == Season.Spring)
            //{
            //    Console.WriteLine("Spring : March to May");
            //}
            //else if (result == Season.Summer)
            //{
            //    Console.WriteLine("Summer : June to August");
            //}
            //else if (result == Season.Autumn)
            //{
            //    Console.WriteLine("Autumn : September to November");
            //}
            //else if (result == Season.Winter)
            //{
            //    Console.WriteLine("Winter : December to February");
            //}
           

            #endregion
            #endregion
        }
    }
}
