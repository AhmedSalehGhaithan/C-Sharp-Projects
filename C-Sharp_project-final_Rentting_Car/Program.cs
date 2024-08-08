using Spectre.Console;
using System;
using System.IO;
namespace C_Sharp_project_final_Rentting_Car
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            MAin_Menue();
        }
        public static void MAin_Menue()
        {
            IMain_Actions Polymorphism = new Rentel_Employee_class();
            //------------------------------------------------
            var fruit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[Cyan]Enter Your Choice : [/]?")
            .PageSize(5).HighlightStyle("Green").MoreChoicesText("[Red](Move up and down to reveal more fruits)[/]")
            .AddChoices(new[] { "\n\n\t\t[Yellow](1)[/][Cyan]  MANAGMENT[/]", "\n\t\t[Yellow](2)[/][Cyan]- RENTAL EMPLOYEE[/]" ,
             "\n\t\t[Yellow](3)[/][Cyan]- CLIENT[/]", "\n\t\t[Yellow](4)[/][Red]- Exit[/]" }));
            Console.Clear();
            //------------------------------------------------
            switch (fruit)
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan]  MANAGMENT[/]": Managment_Menu(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- RENTAL EMPLOYEE[/]": Polymorphism.The_Main_Class_Menue();  break;
                case "\n\t\t[Yellow](3)[/][Cyan]- CLIENT[/]": Polymorphism = new Client_class(); Polymorphism.The_Main_Class_Menue(); break;
                case "\n\t\t[Yellow](4)[/][Red]- Exit[/]": Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("Exit program..."); Console.ResetColor(); Environment.Exit(0); break;
            }
        }
        // -------------------- Managment Part _-----------------
        public static void Managment_Menu()
        {
            IMain_Actions objectType4 = new Traffic_Offence();
            IMain_Actions objectType5 = new Accident_Class();

            //------------------------------------------------
            var fruit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[Cyan]Enter Your Choice : [/]?")
            .PageSize(5).HighlightStyle("Green").MoreChoicesText("[Red](Move up and down to reveal more fruits)[/]")
            .AddChoices(new[] { "\n\n\t\t[Yellow](1)[/][Cyan]  Registing main System Data[/]", "\n\t\t[Yellow](2)[/][Cyan]- Registing The Tranffic Offence[/]" ,
             "\n\t\t[Yellow](3)[/][Cyan]- Registing An Accident Data[/]", "\n\t\t[Yellow](4)[/][Cyan]- Reset the System[/]", "\n\t\t[Yellow](5)[/][Red]- Back[/]" }));
            Console.Clear();
            //------------------------------------------------
            switch (fruit)
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan]  Registing main System Data[/]": Company_Menu(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Registing The Tranffic Offence[/]": objectType4.The_Main_Class_Menue(); break;
                case "\n\t\t[Yellow](3)[/][Cyan]- Registing An Accident Data[/]": objectType5.The_Main_Class_Menue(); break;
                case "\n\t\t[Yellow](4)[/][Cyan]- Reset the System[/]": Reset_System2(); break;
                case "\n\t\t[Yellow](5)[/][Red]- Back[/]": MAin_Menue(); break;

            }
        }
        static  void Reset_System2()
        {
            string[] files = { "Balance.txt", "Cars File.txt", "Client File.txt", "Employee File.txt", "Department File.txt",
                "Rent file.txt","reserve file.txt","Accident File.txt",
                "Tranffic file.txt"};
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\n\t\t\t!!!!!!!!!! Warning !!!!!!!!!!");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("\n\t\tThis process will delete all stored data about this system.");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("\n\t\tDo you agree.");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("\n\t\t(1). YES");
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("\t\t(2). NO");
            int age = int.Parse(Console.ReadLine());
            foreach (string file in files)
            {
                if (age == 1)
                {
                    //File.Replace("Old file.txt",);
                    using (FileStream fil = new FileStream(file, FileMode.Truncate, FileAccess.Write))
                    {
                        fil.SetLength(0);
                    }
                }
            }
        }
        static void Company_Menu()
        {
            IMain_Actions objectType = new The_Car_Class(); 
            IMain_Actions objectType2 = new Depatment_class();
            IMain_Actions objectType3 = new Employee_Class();
           
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n\n\n\t\t\t\t\t* Registing Main System Data PART\n");
            //------------------------------------------------
            var fruit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[Cyan]Enter Your Choice : [/]?")
            .PageSize(5).HighlightStyle("Green").MoreChoicesText("[Red](Move up and down to reveal more fruits)[/]")
            .AddChoices(new[] { "\n\n\t\t[Yellow](1)[/][Cyan]  About Cars[/]", "\n\t\t[Yellow](2)[/][Cyan]- About Employees[/]" ,
            "\n\t\t[Yellow](3)[/][Cyan]- About Departments[/]", "\n\t\t[Yellow](2)[/][Cyan]- Shoe Company Balance[/]",   "\n\t\t[Yellow](5)[/][Red]- Back[/]"}));
          
            Console.Clear();
            //------------------------------------------------
            switch (fruit)
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan]  About Cars[/]": objectType.The_Main_Class_Menue(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- About Employees[/]": objectType3.The_Main_Class_Menue(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Shoe Company Balance[/]": break;
                case "\n\t\t[Yellow](3)[/][Cyan]- About Departments[/]": objectType2.The_Main_Class_Menue(); break;
                case "\n\t\t[Yellow](5)[/][Red]- Back[/]": Managment_Menu(); break;
            }
        } 
       
    }
}
