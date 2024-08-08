using Spectre.Console;
using System;
using System.IO;
using System.Threading;

namespace C_Sharp_project_final_Rentting_Car
{
    public class Accident_Class : IMain_Actions
    {
        public string Accident_Place { get; set; }
        public int Car_Id { get; set; }
        public string PersonName { get; set; }
        public int Person_Snn { get; set; }
        public int Death_number { get; set; }
        public int Injury_number { get; set; }
        public int Tenter_Snn { get; set; }
        public double Accident_Coast { get; set; }
        public DateTime Accident_date { get; set; }
        public DateTime Accident_Time { get; set; }
        public string AccidentDay { get; set; }
        public string AllData { get; set; }
        public bool Truth { get; set; }
        public string file_Name_Accident = "Accident File.txt";
       

        public File_MAnagment_Class File_MAnagment;
        public Accident_Class(string accident_Place="", int car_Id=0, string personName = "", int person_Snn = 0, 
            int death_number = 0, int injury_number = 0, int tenter_Snn = 0, double accident_Coat=0.0f,string accidentDay = "")
        {
            Accident_Place = accident_Place;
            Car_Id = car_Id;
            PersonName = personName;
            Person_Snn = person_Snn;
            Death_number = death_number;
            Injury_number = injury_number;
            Tenter_Snn = tenter_Snn;
            Accident_Coast = accident_Coat;
            AccidentDay = accidentDay;
        }
        public Accident_Class(Accident_Class accident_Class) 
            : this(accident_Class.Accident_Place, accident_Class.Car_Id, accident_Class.PersonName, accident_Class.Person_Snn, accident_Class.Death_number,
                  accident_Class.Injury_number, accident_Class.Tenter_Snn, accident_Class.Accident_Coast,accident_Class.AccidentDay)
        {}
        public virtual void The_Main_Class_Menue()
        {

            //------------------------------------------------
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[Cyan]Enter Your Choice : [/]?")
            .HighlightStyle("Green")
            .AddChoices(new[]
            {
          "\n\n\t\t[Yellow](1)[/][Cyan]  Registting a Accident[/]" ,"\n\t\t[Yellow](2)[/][Cyan]- Display all Accidents[/]",
          "\n\t\t[Yellow](3)[/][Cyan]- Search for Accident[/]","\n\t\t[Yellow](6)[/][Red]- Back[/]"
            }));
            Console.Clear();
            //------------------------------------------------ 
            switch (choice)
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan]  Registting a Accident[/]": Registting_Data(2); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Display all Accidents[/]": Reading_Data_From_File(); break;
                case "\n\t\t[Yellow](3)[/][Cyan]- Search for Accident[/]":

                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the car ID : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Car_Id = int.Parse(Console.ReadLine());
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Car_Id = int.Parse(Console.ReadLine());
                    }
                    Searching_For_(Car_Id); Displaying_data_(); break;
                case "\n\t\t[Yellow](6)[/][Red]- Back[/]":Program.Managment_Menu();  break;

            }

            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
            Console.ReadKey(); Console.Clear();
            The_Main_Class_Menue();
        }
        public virtual void Registting_Data(int key)
        {
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();
            The_Car_Class Car = new The_Car_Class();
        Rentel_Employee_class renter = new Rentel_Employee_class();
        Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the Car ID : ");
            Console.ForegroundColor = ConsoleColor.Yellow; Car_Id = int.Parse(Console.ReadLine());
            while (Car_Id.IS_INTEGER_TYPE() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_Id = int.Parse(Console.ReadLine());
            }

            Car.Searching_For_(Car_Id);

            if (Car.Truth==true)
            {
                if (Car.Car_Status == 1)
                {
                    // Get the data of the person that rent the car 
                    renter.Searching_For_(Car_Id);
                    // display the personn data
                    //.....................................
                    AnsiConsole.Status()
                    .Start("Loading...", ctx =>
                    {
                        Thread.Sleep(1000);
                        // Update the status and spinner
                        ctx.Status("Checking Renter Data...");
                        ctx.Spinner(Spinner.Known.Star);
                        ctx.SpinnerStyle(Style.Parse("green"));
                        Thread.Sleep(2000);
                    });
                    //...............................
                    var root = new Tree("");
                    var foo = root.AddNode("[yellow]Rented Data[/]");
                    var table = foo.AddNode(new Table()
                        .RoundedBorder()
                        .AddColumn("Catogory")
                        .AddColumn("Data")
                        .AddRow("[chartreuse2_1]Renter name [/]", $"[chartreuse2_1]{renter.First_name} {renter.Last_name}[/]")
                        .AddRow("[darkolivegreen3_1]Renter SSN [/]", $"[darkolivegreen3_1]{renter.Renter_SSN}[/]")
                        .AddRow("[palegreen3_1]Car ID[/]", $"[palegreen3_1]{Car_Id}[/]"));
                    AnsiConsole.Write(root);
                    //---------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Accident place : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Accident_Place = Console.ReadLine();

                    while (Accident_Place.IS_STRING_TYPEs() == false || Accident_Place.IsEmptyInput())
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Accident_Place = Console.ReadLine();
                    }
                    //---------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the injury cases number : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Injury_number = int.Parse(Console.ReadLine());
                    while (Injury_number.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Injury_number = int.Parse(Console.ReadLine());
                    }

                    //---------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Death cases number : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Death_number = int.Parse(Console.ReadLine());
                    while (Death_number.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Death_number = int.Parse(Console.ReadLine());
                    }
                    //---------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Accident Coast : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Accident_Coast = double.Parse(Console.ReadLine());
                    while (!Accident_Coast.CHECKING_DOUBLE_INPUT())
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Accident_Coast = double.Parse(Console.ReadLine());
                    }
                    TheDateInput();

                    DayOfWeek DayOF = Accident_date.DayOfWeek;// get the day name
                    AccidentDay = DayOF.ToString();

                    this.AllData = $"{Car_Id},{renter.First_name + " " + renter.Last_name},{renter.Renter_SSN},{Accident_Place},{Accident_date},{AccidentDay},{Injury_number},{Death_number},{Accident_Coast}";
                    File_MAnagment.Adding_Data_Into_File(file_Name_Accident, this.AllData);
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tThis car is not rented");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tThe Car is not found.");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n\t\tPress any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public virtual void TheDateInput()// Input the date in the correct format
        {
            bool pass = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Accident date in the format DD/MM/YYYY : ");
                Console.ForegroundColor = ConsoleColor.Yellow; string input = Console.ReadLine();

                DateTime date;
                if (DateTime.TryParse(input, out date))
                {
                    pass = true;
                    Accident_date = date;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\n\t\tinvalid input,try agin");
                }
            } while (pass == false);
        }
        public virtual void Reading_Data_From_File() {
            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Car ID[/]", "[aquamarine1]Renter Name[/]",
            "[seagreen1_1]Renter SSN[/]", "[seagreen1]Accedent Place[/]", "[seagreen2]Accident date[/]",
            "[honeydew2]Accident Day[/]", "[honeydew2]Injury number[/]",
            "[seagreen1_1]Death number[/]", "[seagreen1]Accident Coast[/]");
            //-----------------------------------------
            using (StreamReader CarF = new StreamReader(file_Name_Accident))
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
                        this.Accident_Place = data[3];
                        this.Accident_date = DateTime.Parse(data[4]);
                        this.AccidentDay = data[5];
                        this.Injury_number = int.Parse(data[6]);
                        this.Death_number = int.Parse(data[7]);
                        this.Accident_Coast = double.Parse(data[8]);
                        //string stat = ((Car_Status == 1) ? "Rented" : (Car_Status == 2) ? "Reserved" : "Available");
                        table.AddRow($"[darkslategray2]{Car_Id}[/]", $"[aquamarine1]{PersonName}[/]", $"[seagreen1_1]{Person_Snn}[/]",
                               $"[seagreen1]{Accident_Place}[/]", $"[seagreen2]{Accident_date}[/]",
                               $"[darkolivegreen1_1]{AccidentDay}[/]", $"[honeydew2]{Injury_number}[/]",
                               $"[darkslategray2]{Death_number}[/]", $"[aquamarine1]{Accident_Coast}[/]");
                    }
                }
                AnsiConsole.Write(table);
            }

        }
        public virtual void Searching_For_(int carId)
        {
            
            if (!File.Exists(file_Name_Accident))// create the file if it's not exist
            {
                try
                {
                    File.Create(file_Name_Accident);
                    using (FileStream fs = File.Create(file_Name_Accident)) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }

            Truth = false;
            using (StreamReader reader = new StreamReader(file_Name_Accident))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >= 9 && int.Parse(data[0]) == carId)
                    {
                        this.Car_Id = int.Parse(data[0]);
                        this.PersonName = data[1];
                        this.Person_Snn = int.Parse(data[2]);
                        this.Accident_Place = data[3];
                        this.Accident_date = DateTime.Parse(data[4]);
                        this.AccidentDay = data[5];
                        this.Injury_number = int.Parse(data[6]);
                        this.Death_number = int.Parse(data[7]);
                        this.Accident_Coast = double.Parse(data[8]);
                        Truth = true;
                        break;
                    }
                    else
                        Truth = false;
                }
            }
        }
        public virtual void Displaying_data_()
        {
            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Car ID[/]", "[aquamarine1]Renter Name[/]",
            "[seagreen1_1]Renter SSN[/]", "[seagreen1]Accedent Place[/]", "[seagreen2]Accident date[/]",
            "[honeydew2]Accident Day[/]", "[honeydew2]Injury number[/]",
            "[seagreen1_1]Death number[/]", "[seagreen1]Accident Coast[/]");
            //-----------------------------------------

            table.AddRow($"[darkslategray2]{Car_Id}[/]", $"[aquamarine1]{PersonName}[/]", $"[seagreen1_1]{Person_Snn}[/]",
                               $"[seagreen1]{Accident_Place}[/]", $"[seagreen2]{Accident_date}[/]",
                               $"[darkolivegreen1_1]{AccidentDay}[/]", $"[honeydew2]{Injury_number}[/]",
                               $"[darkslategray2]{Death_number}[/]", $"[aquamarine1]{Accident_Coast}[/]");

            AnsiConsole.Write(table);
        }
    }
}
