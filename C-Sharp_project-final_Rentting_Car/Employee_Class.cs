using Spectre.Console;
using System;
using System.IO;
using System.Threading;

namespace C_Sharp_project_final_Rentting_Car
{
    public class Employee_Class : Rentel_Employee_class,IMain_Actions
    {
        public int department_Numer { get; set; }
        public double Salary { get; set; }
        private static string File_Name = "Employee File.txt";
        public  override void The_Main_Class_Menue()
        {

            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\n\n\n\t\t\t\t* About Employees PART");
            //------------------------------------------------
            var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[Cyan]Enter Your Choice : [/]?")
        .HighlightStyle("Green")
        .AddChoices(new[]
        {
          "\n\n\t\t[Yellow](1)[/][Cyan]  Add an Employee[/]" ,"\n\t\t[Yellow](2)[/][Cyan]- Display all Employees[/]",
          "\n\t\t[Yellow](2)[/][Cyan]- Search an Employee[/]",
            "\n\n\t\t[Yellow](1)[/][Cyan]  Delete an Employee[/]" ,
            "\n\t\t[Yellow](3)[/][Cyan]- Edit an Employee Data[/]","\n\t\t[Yellow](6)[/][Red]- Back[/]"
        }));
            Console.Clear();
            //------------------------------------------------
            switch (choice)
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan]  Add an Employee[/]":Registting_Data(1); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Display all Employees[/]":Reading_Data_From_File(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Search an Employee[/]":
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter The Employee SSN  ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Renter_SSN = int.Parse(Console.ReadLine());
                    while (Renter_SSN.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Renter_SSN = int.Parse(Console.ReadLine());
                    }
                    Searching_For_(Renter_SSN);
                    if (Truth == true) { Displaying_data_(); }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t Employee Not Found "); 
                        Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        The_Main_Class_Menue();
                    }
                    break;
                case "\n\n\t\t[Yellow](1)[/][Cyan]  Delete an Employee[/]":Edit_OR_Delate_Employee(1); break;
                case "\n\t\t[Yellow](3)[/][Cyan]- Edit an Employee Data[/]": Edit_OR_Delate_Employee(2); break;
            }
            The_Main_Class_Menue();
        }
        public void Edit_OR_Delate_Employee(int type_of_process)
        {
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();
            Depatment_class department = new Depatment_class();
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter The Employee SSN  ");
            Console.ForegroundColor = ConsoleColor.Yellow; Renter_SSN = int.Parse(Console.ReadLine());
            while (Renter_SSN.IS_INTEGER_TYPE() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Renter_SSN = int.Parse(Console.ReadLine());
            }
            if (Truth == true)
            {
                if (type_of_process == 1)
                {
                    department.increaseNumberOfEmployee(department_Numer, 2);
                    File_MAnagment.Update_And_delet_Data_In_File_(File_Name, AllData, Renter_SSN, 1);
                }
                if (type_of_process == 2)
                {

                    Registting_Data(2);
                    File_MAnagment.Update_And_delet_Data_In_File_(File_Name, AllData, Renter_SSN, 2);
                }
            }
            //.....................................

            AnsiConsole.Status()
            .Start("Loading...", ctx =>
            {
                Thread.Sleep(1000);
                // Update the status and spinner
                ctx.Status("\n\n\t\t\tUpdatting file Data...");
                ctx.SpinnerStyle(Style.Parse("green"));
                Thread.Sleep(2000);
            });
            The_Main_Class_Menue();
        }
        public override void Registting_Data(int primary)
        {
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();
            Depatment_class department = new Depatment_class    (); 
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter The Employee Full name : ");
            Console.ForegroundColor = ConsoleColor.Yellow; First_name = Console.ReadLine();
            while (First_name.IS_STRING_TYPEs() == false || First_name.IsEmptyInput())
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; First_name = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter The Employee Phone number : ");
            Console.ForegroundColor = ConsoleColor.Yellow; Phone_number = int.Parse(Console.ReadLine());
            while (Phone_number.IS_INTEGER_TYPE() == false )
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Phone_number = int.Parse(Console.ReadLine());
            }
            //--------------------------------------
        Y:    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter The Employee SSN  ");
            Console.ForegroundColor = ConsoleColor.Yellow; Renter_SSN = int.Parse(Console.ReadLine());
            while (Renter_SSN.IS_INTEGER_TYPE() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Renter_SSN = int.Parse(Console.ReadLine());
            }
            Searching_For_(Renter_SSN);
            if (Truth != true)
            {
               
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter The Employee Deparyment number  ");
                Again: Console.ForegroundColor = ConsoleColor.Yellow; department_Numer = int.Parse(Console.ReadLine());
                while (department_Numer.IS_INTEGER_TYPE() == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; department_Numer = int.Parse(Console.ReadLine());
                }
                department.Searching_For_(department_Numer);
                if (department.Truth == true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter The Employee  Salary  ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Salary = int.Parse(Console.ReadLine());
                    while (Salary.CHECKING_DOUBLE_INPUT() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Salary = int.Parse(Console.ReadLine());
                    }
                    AllData = $"{Renter_SSN},{First_name},{Phone_number},{department_Numer},{Salary}";
                    if (primary != 2)
                    {// if the process is not edit the employee data
                        department.increaseNumberOfEmployee(department_Numer,1);// increase the number of employee in each department(1)
                        File_MAnagment.Adding_Data_Into_File(File_Name, AllData);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n\n\t\t\tError,There is no department in number {department_Numer}");
                    goto Again;
                }
               
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\n\t\t\tError,This employee ssn is alarady used!");
                goto Y;
            }
            
        }
        public override void Displaying_data_()
        {
            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Employee name[/]", "[aquamarine1]Employee SSN[/]",
            "[seagreen1_1]Employee Phone number[/]", "[seagreen1]Employee  Salary[/]", "[seagreen2]Employee department[/]");
            //-----------------------------------------
            table.Alignment(Justify.Center);
            table.AddRow($"[darkslategray2]{First_name}[/]", $"[aquamarine1]{Renter_SSN}[/]", $"[seagreen1_1]{Phone_number}[/]",
                   $"[seagreen1]{department_Numer}[/]", $"[seagreen2]{Salary}[/]");

            AnsiConsole.Write(table);
        }

        public override void Reading_Data_From_File()
        {

            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Employee name[/]", "[aquamarine1]Employee SSN[/]",
            "[seagreen1_1]Employee Phone number[/]", "[seagreen1]Employee  Salary[/]", "[seagreen2]Employee department[/]");
            //-----------------------------------------
            using (StreamReader CarF = new StreamReader(File_Name))
            {
                string line;
                while ((line = CarF.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (line.Length >= 5)
                    {
                        this.Renter_SSN = int.Parse(data[0]);
                        this.First_name = data[1];
                        this.Phone_number = int.Parse(data[2]);
                        this.department_Numer = int.Parse(data[3]);
                        this.Salary = double.Parse(data[4]);
                        table.Alignment(Justify.Center);
                        table.AddRow($"[darkslategray2]{First_name}[/]", $"[aquamarine1]{Renter_SSN}[/]", $"[seagreen1_1]{Phone_number}[/]",
                               $"[seagreen1]{department_Numer}[/]", $"[seagreen2]{Salary}[/]");
                    }
                }
                AnsiConsole.Write(table);
            }
        }
        public override void Searching_For_(int PrimaryKey)
        {
            if (!File.Exists(File_Name))// create the file if it's not exist
            {
                try
                {
                    File.Create(File_Name);
                    using (FileStream fs = File.Create(File_Name)) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }
            Truth = false;
            using (StreamReader reader = new StreamReader(File_Name))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >= 5 && int.Parse(data[0]) == PrimaryKey)
                    {
                        this.Renter_SSN = int.Parse(data[0]);
                        this.First_name = data[1];
                        this.Phone_number = int.Parse(data[2]);
                        this.department_Numer = int.Parse(data[3]);
                        this.Salary = double.Parse(data[4]);
                        this.Truth = true;
                        break;
                    }
                    else
                        Truth = false;
                }
            }

        }

    }
}
