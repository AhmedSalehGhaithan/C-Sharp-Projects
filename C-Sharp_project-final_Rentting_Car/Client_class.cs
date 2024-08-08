using Spectre.Console;
using System;
using System.IO;
namespace C_Sharp_project_final_Rentting_Car
{
    public class Client_class: Rentel_Employee_class
    {
        static private string Files_name = "Client File.txt";
        public double MY_BAlance { get; set; }
        public override void The_Main_Class_Menue()
        {
            //-------------------------------------------
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[Cyan]Enter Your Choice : [/]?")
            .PageSize(5).HighlightStyle("Green")
            .AddChoices(new[] { "\n\n\t\t[Yellow](1)[/][Cyan] Login My Account[/]",
                "\n\t\t[Yellow](2)[/][Cyan]-  Create New Account[/]" ,
                     "\n\t\t[Yellow](3)[/][Red]- Back[/]" }));
            Console.Clear();

            if (choice == "\n\n\t\t[Yellow](1)[/][Cyan] Login My Account[/]")
            {
                Registting_Data(1);
            }
            if (choice == "\n\t\t[Yellow](2)[/][Cyan]-  Create New Account[/]")
            {
                Registting_Data(2);
            }
            if(choice == "\n\t\t[Yellow](3)[/][Red]- Back[/]")
            {
                Program.MAin_Menue();
            }

                //-------------------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("\n\n\t\tPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            The_Main_Class_Menue();
        }
        public override void Registting_Data(int type_Of_Process)
        {
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();
            if (type_Of_Process == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter Your ATM Card : ");
                string temp = Console.ReadLine();
                Searching_For_(int.Parse(temp));
                if (Truth == true)
                {
                    Menue_Of_Account();
                }
                else if (Truth == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\tNo account found with this ATM number try again later");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
                    Console.ReadKey(); Console.Clear(); The_Main_Class_Menue();
                }

            }

            if (type_Of_Process == 2)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter Your full name : ");
                Console.ForegroundColor = ConsoleColor.Yellow; First_name = Console.ReadLine();
                while (First_name.IS_STRING_TYPEs() == false || First_name.IsEmptyInput())
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; First_name = Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter Your ATM Card Number : ");
                Console.ForegroundColor = ConsoleColor.Yellow; ATM_card = int.Parse(Console.ReadLine());
                while (ATM_card.IS_INTEGER_TYPE() == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; ATM_card = int.Parse(Console.ReadLine());
                }
                Searching_For_(ATM_card);
                if (Truth == false)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter Your SSN : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Renter_SSN = int.Parse(Console.ReadLine());
                    while (Renter_SSN.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Renter_SSN = int.Parse(Console.ReadLine());
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter Your Phonre Number : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Phone_number = int.Parse(Console.ReadLine());
                    while (Phone_number.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Phone_number = int.Parse(Console.ReadLine());
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter Your Bank account balance : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; MY_BAlance = double.Parse(Console.ReadLine());
                    while (MY_BAlance.CHECKING_DOUBLE_INPUT() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; MY_BAlance = double.Parse(Console.ReadLine());
                    }

                    AllData = $"{ATM_card},{First_name},{Renter_SSN},{Phone_number},{MY_BAlance}";
                    File_MAnagment.Adding_Data_Into_File(Files_name, AllData);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tThos Account is curently used");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tPress any key to continue...");
                    Console.ReadKey(); Console.Clear(); The_Main_Class_Menue();
                }
            }
        }
        public void Menue_Of_Account()
        {
            The_Car_Class the_Car_Class = new The_Car_Class();
            
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n\n\t\tWelcone {First_name} {Last_name}");
            //-------------------------------------------
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[Cyan]Enter Your Choice : [/]?")
            .PageSize(5).HighlightStyle("Green")
            .AddChoices(new[] { "\n\n\t\t[Yellow](1)[/][Cyan] Show Cars List[/]",
                "\n\t\t[Yellow](2)[/][Cyan]-  Asking for Car[/]" ,"\n\t\t[Yellow](2)[/][Cyan]-  Adding Balance to my Bank Account[/]" ,
               "\n\t\t[Yellow](2)[/][Cyan]-  Show My Account Information[/]" , "\n\t\t[Yellow](3)[/][Red]- Back[/]" }));
            Console.Clear();
            //-------------------------------------------

            switch(choice) 
            {
                case "\n\n\t\t[Yellow](1)[/][Cyan] Show Cars List[/]": the_Car_Class.Reading_Data_From_File(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]-  Asking for Car[/]": 
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Car ID :  ");
                    Console.ForegroundColor = ConsoleColor.Yellow; int Cars_ID = int.Parse(Console.ReadLine());
                    while (Cars_ID.IS_INTEGER_TYPE() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Cars_ID = int.Parse(Console.ReadLine());
                    }
                    the_Car_Class.Searching_For_(Cars_ID); the_Car_Class.Displaying_data_(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]-  Adding Balance to my Bank Account[/]":
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter Your Bank account balance : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; double balance = double.Parse(Console.ReadLine());
                    while (balance.CHECKING_DOUBLE_INPUT() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                        Console.ForegroundColor = ConsoleColor.Yellow; balance = double.Parse(Console.ReadLine());
                    }
                    AddingBalamce(ATM_card, balance); break;

                case "\n\t\t[Yellow](2)[/][Cyan]-  Show My Account Information[/]":
                    Displaying_data_(); break;
                case "\n\t\t[Yellow](3)[/][Red]- Back[/]": Program.MAin_Menue(); break;

            }
            Searching_For_(ATM_card);
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("\n\n\t\tPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Menue_Of_Account();
        }

        public override void Displaying_data_()
        {
            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]MY Name [/]", "[aquamarine1]MY SSN Number[/]",
            "[seagreen1_1]MY Phone Number[/]", "[seagreen1]MY ATM Number [/]", "[Red]MY Balance[/]");
            //-----------------------------------------
            table.AddRow($"[darkslategray2]{First_name}[/]", $"[aquamarine1]{Renter_SSN}[/]", $"[seagreen1_1]{Phone_number}[/]",
                              $"[seagreen1]{ATM_card}[/]", $"[Red]{MY_BAlance}[/]");
            AnsiConsole.Write(table);
        }
        public void TakingBalance(int atm,double firPay)
        {
            double las = 0.0f;
            using (StreamReader reader = new StreamReader(Files_name))
            using (StreamWriter writer = new StreamWriter("Temp file.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] objectData = line.Split(',');
                    if (objectData.Length >= 5 && int.Parse(objectData[0]) != atm)
                    {
                        writer.WriteLine(line);
                    }
                    if (objectData.Length >= 5 && int.Parse(objectData[0]) == atm)
                    {

                         las = MY_BAlance - firPay;
                        this.AllData = $"{atm},{First_name},{Renter_SSN},{Phone_number},{las}";
                        string All = $"{objectData[0]},{objectData[1]},{objectData[2]},{this.MY_BAlance},{objectData[4]}";
                        writer.WriteLine(All);
                        
                        break;
                    }
                }
            }
            File.Delete(Files_name);
            File.Move("Temp file.txt", Files_name);
        }
        public void AddingBalamce(int atm, double tempBalance)
        {
            using (StreamReader reader = new StreamReader(Files_name))
            using (StreamWriter writer = new StreamWriter("Temp file.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] objectData = line.Split(',');
                    if (objectData.Length >0 && int.Parse(objectData[0]) != atm)
                    {
                        writer.WriteLine(line);
                    }
                     if (objectData.Length >0 && int.Parse(objectData[0]) == atm)
                    {
                        double MY_BAlanceRemp = (double.Parse(objectData[4]) + tempBalance);
                        string All = $"{objectData[0]},{objectData[1]},{objectData[2]},{objectData[3]},{MY_BAlanceRemp}";
                        writer.WriteLine(All);
                        
                        break;
                    }
                }
            }
            File.Delete(Files_name);
            File.Move("Temp file.txt", Files_name);
        }
        public override void Searching_For_(int ATMCard)
        {
            if (!File.Exists(Files_name))// create the file if it's not exist
            {
                try
                {
                    File.Create(Files_name);
                    using (FileStream fs = File.Create(Files_name)) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }

            Truth = false;
            using (StreamReader reader = new StreamReader(Files_name))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if (data.Length >= 5 && int.Parse(data[0]) == ATMCard)
                    {
                        ATM_card = int.Parse(data[0]);
                        First_name = data[1];
                        Renter_SSN = int.Parse(data[2]);
                        Phone_number = int.Parse(data[3]);
                        MY_BAlance = double.Parse(data[4]);
                        Truth = true;
                        break;
                    }
                    else
                        Truth = false;
                }
            }
        }

    }
}
