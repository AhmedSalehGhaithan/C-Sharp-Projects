using System;
using System.IO;
using System.Threading;
using Spectre.Console;
namespace C_Sharp_project_final_Rentting_Car 
{
    public class The_Car_Class: IMain_Actions
    {
        public string All_Car_Data;
        public string USer_Choice;
        public int Cars_ID { get; set; }
        public string Car_Name { get; set; }
        public string Car_Type { get; set; }
        public string Car_Model { get; set; }
        public int Car_Number { get; set; }
        public double Car_Rental_Rate { get; private set; }
        public byte Car_Status { get; set; }// 1 rented,2 reserved, 3 available
        public int Temp_Input;
        public bool Truth { get; set; }
        static public string File_Name = "Cars File.txt";
        
        public The_Car_Class(int Cars_ID=0,string Car_Name="",string Car_Type = "" ,
            string Car_Model = "",int Car_Number = 0, double Car_Rental_Rate=0.0,byte Car_Status=0)
        {
            this.Cars_ID = Cars_ID;
            this.Car_Name = Car_Name;
            this.Car_Type = Car_Type;
            this.Car_Model = Car_Model;
            this.Car_Number = Car_Number;
            this.Car_Rental_Rate = Car_Rental_Rate;
            this.Car_Status = Car_Status;
        }

        public void The_Main_Class_Menue()
        {
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();
            //------------------------------------------------
            var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[Cyan]Enter Your Choice : [/]?")
        .HighlightStyle("Green")
        .AddChoices(new[]
        {
          "\n\n\t\t[Yellow](1)[/][Cyan]  Add a Car[/]" ,"\n\t\t[Yellow](2)[/][Cyan]- Display All Cars[/]",
          "\n\t\t[Yellow](3)[/][Cyan]- Search a Car[/]","\n\t\t[Yellow](4)[/][Cyan]- Edit a Car Data[/]", 
          "\n\t\t[Yellow](5)[/][Cyan]- Delete a Car[/]","\n\t\t[Yellow](6)[/][Red]- Back[/]"
        }));
            Console.Clear();
            //------------------------------------------------
            switch(choice)
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan]  Add a Car[/]": Registting_Data(1); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Display All Cars[/]":Reading_Data_From_File(); break;
                case "\n\t\t[Yellow](3)[/][Cyan]- Search a Car[/]":
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Car ID :  ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Cars_ID = int.Parse(Console.ReadLine());
                    while (Cars_ID.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Cars_ID = int.Parse(Console.ReadLine());
                    }
                    Searching_For_(Cars_ID); Displaying_data_(); break;
               case "\n\t\t[Yellow](4)[/][Cyan]- Edit a Car Data[/]":
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Car ID :  ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Temp_Input = int.Parse(Console.ReadLine());
                    while (Temp_Input.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Temp_Input = int.Parse(Console.ReadLine());
                    }
                  
                    Searching_For_(Cars_ID);
                    if (Truth == true) { 
                    Registting_Data(2);
                        //---------------------
                        AnsiConsole.Status()
            .Start("Loading...", ctx =>
            {
                Thread.Sleep(1000);
                // Update the status and spinner
                ctx.Status("\n\n\t\t\tUpdatting file Data...");
                ctx.SpinnerStyle(Style.Parse("green"));
                Thread.Sleep(2000);
            });
                        //-----------------------
                    }
                    else
                        Console.WriteLine("Car no found");
                    break;
                case "\n\t\t[Yellow](5)[/][Cyan]- Delete a Car[/]":
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Car ID :  ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Temp_Input = int.Parse(Console.ReadLine());
                    while (Temp_Input.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Temp_Input = int.Parse(Console.ReadLine());
                    }
                    Searching_For_(Temp_Input);
                    if (Car_Status == 3)
                    { 
                        // even if you send the all data it will not work while the process is deletting(1)
                        File_MAnagment.Update_And_delet_Data_In_File_(File_Name, All_Car_Data, Temp_Input, 1);
                    }
                    else if(Car_Status==1)
                        Console.WriteLine("\n\n\t\t\tSory Car is rented");
                    else if (Car_Status == 2)
                        Console.WriteLine("\n\n\t\t\tSory Car is reserved");
                    break;

                case "\n\t\t[Yellow](6)[/][Red]- Back[/]": break;
            }
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("\n\n\t\tPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            The_Main_Class_Menue();
        }
        
        public void Registting_Data(int type_Of_Process)
        {
             File_MAnagment_Class File_MAnagment = new File_MAnagment_Class ();
        //-----------------------------------------
        Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the car name :  ");
            Console.ForegroundColor = ConsoleColor.Yellow; Car_Name = Console.ReadLine();
            while (Car_Name.IS_STRING_TYPEs()== false || Car_Name.IsEmptyInput())
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_Name = Console.ReadLine();
            }
            //-----------------------------------------
            
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Car ID :  ");
                Console.ForegroundColor = ConsoleColor.Yellow; Cars_ID = int.Parse(Console.ReadLine());
                while (Cars_ID.IS_INTEGER_TYPE() == false )
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Cars_ID = int.Parse(Console.ReadLine());
                }
            
            //-----------------------------------------
            Searching_For_(Cars_ID ); // check the car id
            if (Truth == false)
            {// reget new data if the car id not entered before
                //-----------------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the car model : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_Model = Console.ReadLine();
                // no validation for car_model ,it can be string or integer
                //-----------------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the car Type :");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_Type = Console.ReadLine();
                while (!Car_Type.IS_STRING_TYPEs() || Car_Name.IsEmptyInput())
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Car_Type = Console.ReadLine();
                }
                //-----------------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the car Rental Rate Per Day : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_Rental_Rate = double.Parse(Console.ReadLine());
                while (!Car_Rental_Rate.CHECKING_DOUBLE_INPUT() || Car_Name.IsEmptyInput())
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Car_Rental_Rate = double.Parse(Console.ReadLine());
                }
                //-----------------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the car number : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_Number = int.Parse(Console.ReadLine());
                while (Car_Number.IS_INTEGER_TYPE() == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Car_Number = int.Parse(Console.ReadLine());
                }
                Car_Status = 3;// three represent available car
             //-----------------------------------------
            // set All data and save it into file of lenght 7
            All_Car_Data = $"{Cars_ID},{Car_Model},{Car_Name},{Car_Number},{Car_Rental_Rate},{Car_Status},{Car_Type}";

                //-----------------------------------------
                
                if(type_Of_Process==1)// if the user is rgist a car safe the data
                    File_MAnagment.Adding_Data_Into_File(File_Name, All_Car_Data);
                if(type_Of_Process==2)// if the user is edit the car update the data
                    File_MAnagment.Update_And_delet_Data_In_File_(File_Name, All_Car_Data, Temp_Input,2);
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\t\tSory,You can't Use this id,it's already exist!");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("\n\n\t\tPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                The_Main_Class_Menue();
            }
        }
        public virtual void Searching_For_(int id)
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
                    
                    if (data.Length >= 7 && int.Parse(data[0]) == id)
                    {
                        this.Cars_ID = int.Parse(data[0]);
                        this.Car_Model = data[1];
                        this.Car_Name = data[2];
                        this.Car_Number = int.Parse(data[3]);
                        this.Car_Rental_Rate = double.Parse(data[4]);
                        this.Car_Status = byte.Parse(data[5]);
                        this.Car_Type = data[6];
                        this.Truth = true;
                        break;
                    }
                    else
                        Truth = false;
                }
            }
        }
        public void Change_Car_Statuu(int car_id,int status)
        {
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();
            Searching_For_(car_id);
            All_Car_Data = $"{Cars_ID},{Car_Model},{Car_Name},{Car_Number},{Car_Rental_Rate},{status},{Car_Type}";
            File_MAnagment.Update_And_delet_Data_In_File_(File_Name, All_Car_Data, car_id, 2);
        }
        public void Reading_Data_From_File()
        {

            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Car name[/]", "[aquamarine1]Car Type[/]",
            "[seagreen1_1]Car ID[/]", "[seagreen1]Car Number[/]", "[seagreen2]Car Model[/]",
            "[honeydew2]Car Rental Rate[/]", "[honeydew2]Car Status[/]");
            //-----------------------------------------
            using (StreamReader CarF = new StreamReader(File_Name))
            {
                string line;
                while ((line = CarF.ReadLine()) != null)
                {
                    if (line.Length >0)
                    {
                        string[] data = line.Split(',');
                        this.Cars_ID = int.Parse(data[0]);
                        this.Car_Model = data[1];
                        this.Car_Name = data[2];
                        this.Car_Number = int.Parse(data[3]);
                        this.Car_Rental_Rate = double.Parse(data[4]);
                        this.Car_Status = byte.Parse(data[5]);
                        this.Car_Type = data[6];
                        string stat = ((Car_Status == 1) ? "Rented" : (Car_Status == 2) ? "Reserved" : "Available");
                        table.AddRow($"[darkslategray2]{Car_Name}[/]", $"[aquamarine1]{Car_Type}[/]", $"[seagreen1_1]{Cars_ID}[/]",
                               $"[seagreen1]{Car_Number}[/]", $"[seagreen2]{Car_Model}[/]",
                               $"[darkolivegreen1_1]{Car_Rental_Rate}[/]", $"[honeydew2]{stat}[/]");
                    }
                   
                }
                AnsiConsole.Write(table);
            }
        }
        public void Displaying_data_() 
        {
            //-----------------------------------------
            var table = new Table();
            string stat = ((Car_Status == 1) ? "Rented" : (Car_Status == 2) ? "Reserved" : "Available");
            table.AddColumns("[darkslategray2]Car name[/]", "[aquamarine1]Car Type[/]",
            "[seagreen1_1]Car ID[/]", "[seagreen1]Car Number[/]", "[seagreen2]Car Model[/]",
            "[honeydew2]Car Rental Rate[/]", "[honeydew2]Car Status[/]");
            //-----------------------------------------
            table.AddRow($"[darkslategray2]{Car_Name}[/]", $"[aquamarine1]{Car_Type}[/]", $"[seagreen1_1]{Cars_ID}[/]",
                               $"[seagreen1]{Car_Number}[/]", $"[seagreen2]{Car_Model}[/]",
                               $"[darkolivegreen1_1]{Car_Rental_Rate}[/]", $"[honeydew2]{stat}[/]");
            AnsiConsole.Write(table);
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
            Console.ReadKey(); Console.Clear();
            
        }

        
    }
}
