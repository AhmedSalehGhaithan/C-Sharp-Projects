using Spectre.Console;
using System;
using System.IO;
namespace C_Sharp_project_final_Rentting_Car
{
    public class Traffic_Offence :Accident_Class
    {
        public string Tranffic_offence_Type { get; set; }
        private string file_Name_Tranffic_offence = "Tranffic file.txt";
        public Traffic_Offence(string accident_Place = "", int car_Id = 0, string personName = "", int person_Snn = 0, int death_number = 0, int injury_number = 0, int tenter_Snn = 0, double accident_Coat = 0.0f, string accidentDay = "",string tranffic_offence_Type="")
            :base(accident_Place,car_Id,personName,person_Snn,death_number,injury_number,tenter_Snn,accident_Coat,accidentDay)
        {
            Tranffic_offence_Type = tranffic_offence_Type;
        }

        public byte paymenyCase { get; set; }
        public override void The_Main_Class_Menue()
        {

            //------------------------------------------------
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[Cyan]Enter Your Choice : [/]?")
            .HighlightStyle("Green")
            .AddChoices(new[]
            {
          "\n\n\t\t[Yellow](1)[/][Cyan]  Registting a Tranffic offence[/]" ,"\n\t\t[Yellow](2)[/][Cyan]-  Display all Tranffic offence[/]",
          "\n\t\t[Yellow](3)[/][Cyan]- Search for Tranffic offence[/]","\n\t\t[Yellow](6)[/][Red]- Back[/]"
            }));
            Console.Clear();
            //------------------------------------------------ 

            switch (choice)
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan]  Registting a Tranffic offence[/]": Registting_Data(2); break;
                case "\n\t\t[Yellow](2)[/][Cyan]-  Display all Tranffic offence[/]":Reading_Data_From_File(); break;
                case "\n\t\t[Yellow](3)[/][Cyan]- Search for Tranffic offence[/]":

                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the car ID : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Car_Id = int.Parse(Console.ReadLine());
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Car_Id = int.Parse(Console.ReadLine());
                    }
                    Searching_For_(Car_Id); Displaying_data_(); break;
                case "\n\t\t[Yellow](6)[/][Red]- Back[/]":Program.Managment_Menu(); break;

            }
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
            Console.ReadKey(); Console.Clear();
            The_Main_Class_Menue();
        }
        public override void Registting_Data(int key)
        {
            The_Car_Class Car = new The_Car_Class();
            File_MAnagment_Class file_MAnagment_Class =  new File_MAnagment_Class();    
            Rentel_Employee_class renter = new Rentel_Employee_class();
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the car ID : ");
            Console.ForegroundColor = ConsoleColor.Yellow; Car_Id = int.Parse(Console.ReadLine());
            while (Car_Id.IS_INTEGER_TYPE() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_Id = int.Parse(Console.ReadLine());
            }
            renter.Searching_For_(Car_Id);
            Car.Searching_For_(Car_Id);
            if (Car.Truth == true)// if the car is found
                {
                if (Car.Car_Status == 1)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\t\t -Person Name : {renter.First_name} {renter.Last_name}");
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\t\t -The Person SSN : {renter.Renter_SSN}");
                    
                    // get the Tranffic offence type and coast
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\tEnter The type of Tranffic offence : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Tranffic_offence_Type = Console.ReadLine();
                    while (Tranffic_offence_Type.IS_STRING_TYPEs() == false || Tranffic_offence_Type.IsEmptyInput())
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Tranffic_offence_Type = Console.ReadLine();
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Tranffic offence Coast : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Accident_Coast = double.Parse(Console.ReadLine());
                    while (!Accident_Coast.CHECKING_DOUBLE_INPUT())
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Accident_Coast = double.Parse(Console.ReadLine());
                    }
                    base.TheDateInput();
                    paymenyCase = 0;
                    AllData = $"{Car_Id},{renter.First_name} + {renter.Last_name},{renter.Renter_SSN},{Tranffic_offence_Type},{Accident_Coast},{paymenyCase},{Accident_date}";
                    file_MAnagment_Class.Adding_Data_Into_File(file_Name_Tranffic_offence, AllData);
                  }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\t\tCar is not rented !");
                   
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n\n\t\t\tPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\n\t\t\tThe Car is not found.");
            }
        }
        public override void Reading_Data_From_File()
        {
           
            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Car ID[/]", "[aquamarine1]Renter Name[/]",
           "[seagreen1_1]Renter SSN[/]", "[seagreen1]Traffic offence type[/]", "[seagreen2]Traffic offence Coast[/]",
           "[honeydew2]Traffic offence date[/]", "[honeydew2]Payment Case[/]");
            //-----------------------------------------
            using (StreamReader CarF = new StreamReader(file_Name_Tranffic_offence))
            {
              

                string line;
                while ((line = CarF.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        string[] data = line.Split(',');
                        this.Car_Id = int.Parse(data[0]);
                        this.PersonName = data[1];
                        this.Person_Snn = int.Parse(data[2]);
                        this.Tranffic_offence_Type = data[3];
                        this.Accident_Coast = double.Parse(data[4]);
                        this.paymenyCase = byte.Parse(data[5]);
                        this.Accident_date = DateTime.Parse(data[6]);
                        string stat = ((paymenyCase == 0) ? "Unpaid" : (paymenyCase == 1) ? "Paid" : "Unkown");
                        table.AddRow($"[darkslategray2]{Car_Id}[/]", $"[aquamarine1]{PersonName}[/]", $"[seagreen1_1]{Person_Snn}[/]",
                               $"[seagreen1]{Tranffic_offence_Type}[/]", $"[seagreen2]{Accident_Coast}[/]",
                               $"[honeydew2]{Accident_date}[/]", $"[honeydew2]{stat}[/]");
                    }
                }
                AnsiConsole.Write(table);
            }

        }
        public override void Searching_For_(int carId)
        {

            if (!File.Exists(file_Name_Tranffic_offence))// create the file if it's not exist
            {
                try
                {
                    File.Create(file_Name_Tranffic_offence);
                    using (FileStream fs = File.Create(file_Name_Tranffic_offence)) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }

            Truth = false;
            using (StreamReader reader = new StreamReader(file_Name_Tranffic_offence))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >= 7 && int.Parse(data[0]) == carId)
                    {
                        this.Car_Id = int.Parse(data[0]);
                        this.PersonName = data[1];
                        this.Person_Snn = int.Parse(data[2]);
                        this.Tranffic_offence_Type = data[3];
                        this.Accident_Coast = double.Parse(data[4]);
                        this.paymenyCase = byte.Parse(data[5]);
                        this.Accident_date = DateTime.Parse(data[6]);
                        Truth = true;
                        break;
                    }
                    else
                        Truth = false;
                }
            }
        }
        public override void Displaying_data_()
        {
            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Car ID[/]", "[aquamarine1]Renter Name[/]",
            "[seagreen1_1]Renter SSN[/]", "[seagreen1]Traffic offence type[/]", "[seagreen2]Traffic offence Coast[/]",
            "[honeydew2]Traffic offence date[/]", "[honeydew2]Payment Case[/]");
            //-----------------------------------------
            string stat = ((paymenyCase == 0) ? "Unpaid" : (paymenyCase == 1) ? "Paid" : "Unkown");

            table.AddRow($"[darkslategray2]{Car_Id}[/]", $"[aquamarine1]{PersonName}[/]", $"[seagreen1_1]{Person_Snn}[/]",
                              $"[seagreen1]{Tranffic_offence_Type}[/]", $"[seagreen2]{Accident_Coast}[/]",
                              $"[honeydew2]{Accident_date}[/]", $"[honeydew2]{stat}[/]");

            AnsiConsole.Write(table);


        }

        public void Change_traffic_State(int carID)
        {
            this.AllData = $"{Car_Id},{PersonName},{Person_Snn},{Tranffic_offence_Type},{Accident_Coast},{1},{Accident_date}";
            using (StreamReader reader = new StreamReader(file_Name_Tranffic_offence))
            using (StreamWriter writer = new StreamWriter("Temp file.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] objectData = line.Split(',');
                    // if the line of car id not found write the data to the temp file
                    if (objectData.Length > 0 && int.Parse(objectData[0]) != carID)
                    {
                        writer.WriteLine(line);
                    }
                    else if (objectData.Length > 0 && int.Parse(objectData[0]) == carID)
                    {// else if the car id found update the data
                        writer.WriteLine(this.AllData);
                    }
                }
            }
            // replace the original file with the update file
            File.Delete(file_Name_Tranffic_offence);
            File.Move("Temp file.txt", file_Name_Tranffic_offence);
            //.....................................
        }
      
    }

}
