using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
namespace C_Sharp_project_final_Rentting_Car
{
    public class Depatment_class :IMain_Actions
    {
        public int Department_number { get; set; }
        public string Department_name { get; set; }
        public int numberOF_Emoloyees { get; set; }
        public string All_data { get; set; }
        public string File_name = "Department File.txt";
        public bool Truth { get; set; }
        public List<string> My_list = new List<string>();
        public void The_Main_Class_Menue()
        {

            //------------------------------------------------
            var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[Cyan]Enter Your Choice : [/]?")
        .HighlightStyle("Green")
        .AddChoices(new[]
        {
          "\n\n\t\t[Yellow](1)[/][Cyan]   Add a Department[/]" ,"\n\t\t[Yellow](2)[/][Cyan]- Display Departmets[/]",
          "\n\t\t[Yellow](2)[/][Cyan]- Search a Departmets[/]",
          "\n\t\t[Yellow](3)[/][Cyan]- Display Employee in Specific Department[/]","\n\t\t[Yellow](6)[/][Red]- Back[/]"
        }));
            Console.Clear();
            //------------------------------------------------

            switch (choice)
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan]   Add a Department[/]": Registting_Data(1); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Display Departmets[/]": Reading_Data_From_File(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Search a Departmets[/]":
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the department number : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Department_number = int.Parse(Console.ReadLine());
                    while (Department_number.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Department_number = int.Parse(Console.ReadLine());
                    }
                    Searching_For_(Department_number);
                    if (Truth == true) { Displaying_data_(); }
                    else { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t Department Not Found "); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t\t\tDepartment Added Successfully.");
                        Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        The_Main_Class_Menue();
                    }
                    break;



                case "\n\t\t[Yellow](3)[/][Cyan]- Display Employee in Specific Department[/]": break;//
                case "\n\t\t[Yellow](6)[/][Red]- Back[/]": break;
            }

        } 
        public void Reading_Data_From_File()
        {
            //-----------------------------------------
            var table = new Table();
            table.AddColumns(
            "[seagreen1_1]Department Name[/]", "[seagreen1]Department Number[/]", "[seagreen2]Number OF Employee[/]");
            //-----------------------------------------
            using (StreamReader CarF = new StreamReader(File_name))
            {
                string line;
                while ((line = CarF.ReadLine()) != null)
                {
                    if (line.Length >=3)
                    {
                        string[] data = line.Split(',');
                        this.Department_name = data[1];
                        this.Department_number = int.Parse(data[0]);    
                        this.numberOF_Emoloyees = int.Parse(data[2]);
                        table.Alignment(Justify.Center);
                        table.AddRow($"[darkslategray2]{Department_name}[/]", $"[aquamarine1]{Department_number}[/]", $"[seagreen1_1]{numberOF_Emoloyees}[/]");
                    }

                }
                AnsiConsole.Write(table);
            }
        }
        //Add_Department
        public void Registting_Data(int n=1)
        {
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();  
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\n\n\n\t\t\t\t\t ADDING DEPARTMENT PART ");
            //--------------------------------------
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the Department Name : ");
            Console.ForegroundColor = ConsoleColor.Yellow; Department_name = Console.ReadLine();
            while (Department_name.IS_STRING_TYPEs() == false || Department_name.IsEmptyInput())
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Department_name = Console.ReadLine();
            }
            //--------------------------------------
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the department number : ");
            Console.ForegroundColor = ConsoleColor.Yellow; Department_number = int.Parse(Console.ReadLine());
            while (Department_number.IS_INTEGER_TYPE() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Department_number = int.Parse(Console.ReadLine());
            }
            Searching_For_(Department_number);
            if (Truth == false)
            {
                //--------------------------------------
                numberOF_Emoloyees = 0;// it's zero employe becouse the department is new
                All_data = $"{Department_number},{Department_name},{numberOF_Emoloyees}";

                File_MAnagment.Adding_Data_Into_File(File_name, All_data);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t\t\tThis Departmet number is alrady exist");
            }
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t\t\tDepartment Added Successfully.");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public void Searching_For_(int departNum)
        {
            if (!File.Exists(File_name))// create the file if it's not exist
            {
                try
                {
                    File.Create(File_name);
                    using (FileStream fs = File.Create(File_name)) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }

            Truth = false;
            using (StreamReader reader = new StreamReader(File_name))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >=3 && int.Parse(data[0]) == departNum)
                    {
                        this.Department_name = data[1];
                        this.Department_number = int.Parse(data[0]);
                        this.numberOF_Emoloyees = int.Parse(data[2]);
                        Truth = true;
                        break;
                    }
                    else
                        Truth = false;
                }
            }

        }
        public void Displaying_data_()
        {
            //------------------------------------------------
            
            var table = new Table();
            table.AddColumns("[seagreen1_1]Department Name[/]", "[seagreen1]Department Number[/]", "[seagreen2]Number OF Employee[/]");
            table.AddRow($"[darkslategray2]{Department_name}[/]", $"[aquamarine1]{Department_number}[/]", $"[seagreen1_1]{numberOF_Emoloyees}[/]");
            AnsiConsole.Write(table);
        }
        public void increaseNumberOfEmployee(int depNum,int type)
        {
            // this function only works when the admin add an employee to depcific department
            // the function check the department number then increase the number of employee 
            // each time the admin add an employee to that department
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();
            Searching_For_(depNum);
            int num = 0;
            if (type == 1)
            {
                 num = numberOF_Emoloyees + 1;
            }
            else if (type == 2)
            {
                 num = numberOF_Emoloyees - 1;
            }
            All_data = $"{Department_number },{Department_name},{num}";

            File_MAnagment.Update_And_delet_Data_In_File_(File_name, All_data,depNum,2);
        }

    }
}
