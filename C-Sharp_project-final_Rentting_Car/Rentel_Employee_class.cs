using Spectre.Console;
using System;
using System.IO;

namespace C_Sharp_project_final_Rentting_Car
{
    public class Rentel_Employee_class : IMain_Actions
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Address_name { get; set; }
        public int Renter_SSN { get; set; }
        public int ATM_card { get; set; }
        public int Phone_number { get; set; }
        public DateTime Rental_Date { get; set; }
        public DateTime Returned_date { get; set; }
        public int Car_ID { get; set; }
        public double First_Payment { get; set; }
        public double Scond_Payment { get; set; }
        public double All_Rental_Coast { get; set; }
        public int number_Of_days { get; set; }
        public double Balance { get; set; }
        public string AllData;
        static private string fileNAme = "Rent file.txt";

        public bool Truth { get; set; }


        public virtual void The_Main_Class_Menue()
        {

            //-------------------------------------------
            reserve_Class reserv = new reserve_Class();
            The_Car_Class car = new The_Car_Class();
            
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[Cyan]Enter Your Choice : [/]?")
            .HighlightStyle("Green")
            .AddChoices(new[]
            {
         "\n\n\t\t[Yellow](0)[/][Cyan] Display Cars List[/]" ,"\n\t\t[Yellow](1)[/][Cyan] Display Rented Cars [/]","\n\t\t[Yellow](2)[/][Cyan]- Seach Car Status[/]",
          "\n\t\t[Yellow](3)[/][Cyan]- Rent a Car[/]","\n\t\t[Yellow](4)[/][Cyan]- Reservation a Car[/]",
         "\n\t\t[Yellow](5)[/][Cyan]- Canceling Reservation[/]", "\n\t\t[Yellow](7)[/][Cyan]- Search for Specsifc Car Renter[/]"
          ,"\n\t\t[Yellow](7)[/][Cyan]- Regist Return data[/]"
          ,"\n\t\t[Yellow](9)[/][Red]- Back[/]"
            }));
            Console.Clear();
            //-------------------------------------------

            switch (choice)
            {
                case "\n\n\t\t[Yellow](0)[/][Cyan] Display Cars List[/]": car.Reading_Data_From_File(); break;
                case "\n\t\t[Yellow](1)[/][Cyan] Display Rented Cars [/]": Reading_Data_From_File(); break;
                case "\n\t\t[Yellow](2)[/][Cyan]- Seach Car Status[/]": Search_For_Car_Status(); break;
                case "\n\t\t[Yellow](3)[/][Cyan]- Rent a Car[/]": Registting_Data(1); break;
                case "\n\t\t[Yellow](4)[/][Cyan]- Reservation a Car[/]": Registting_Data(2); break;
                case "\n\t\t[Yellow](5)[/][Cyan]- Canceling Reservation[/]": reserv.Cancel_Reservation(); break;
                case "\n\t\t[Yellow](7)[/][Cyan]- Search for Specsifc Car Renter[/]": Search_For_Renter(); break;
                case "\n\t\t[Yellow](7)[/][Cyan]- Regist Return data[/]": Returning_Car(); break;
                case "\n\t\t[Yellow](9)[/][Red]- Back[/]": break;//
            }
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("\n\n\t\tPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Program.MAin_Menue();
        }
        public void Search_For_Renter() // by the Tenter SSn or the car id
        {
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\n\n\n\t\t\t\t\t SEARCHING FOR A CAR PART ");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\tEnter the car ID : ");
            Console.ForegroundColor = ConsoleColor.Yellow; int id = int.Parse(Console.ReadLine());
            while (id.IS_INTEGER_TYPE() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; id = int.Parse(Console.ReadLine());
            }
            Searching_For_(id);
            if (Renter_SSN != 0)
            {
                Displaying_data_();// display the data
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\tThere is no Car rented with this id");
            }
        }
        public virtual void Registting_Data(int primary)
        {
            File_MAnagment_Class File_MAnagment = new File_MAnagment_Class();
            The_Car_Class Car_Class = new The_Car_Class();
            Client_class client = new Client_class();
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Car ID :  ");
            Console.ForegroundColor = ConsoleColor.Yellow; int Car_ID = int.Parse(Console.ReadLine());
            while (Car_ID.IS_INTEGER_TYPE() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_ID = int.Parse(Console.ReadLine());
            }
            Car_Class.Searching_For_(Car_ID);
            // if the car is exist and it's available
            if (Car_ID == Car_Class.Cars_ID && Car_Class.Car_Status == 3 && Car_Class.Truth == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the client's ATM card : ");
                Console.ForegroundColor = ConsoleColor.Yellow; ATM_card = int.Parse(Console.ReadLine());
                while (ATM_card.IS_INTEGER_TYPE() == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; ATM_card = int.Parse(Console.ReadLine());
                }
                //----------------------------------------------

                client.Searching_For_(ATM_card);
                if (client.Truth == true)
                {
                    Rental_Date = DateTime.Now;
                    TheDateInput();
                    // claculate the number of day betwenn the current day and the returned day
                    TimeSpan Day_Number = Returned_date.Subtract(Rental_Date);
                    number_Of_days = Day_Number.Days;
                    number_Of_days++;
                    All_Rental_Coast = (Car_Class.Car_Rental_Rate * number_Of_days);
                    if (client.MY_BAlance >= All_Rental_Coast)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n\t\t\t** Total Rental Price = $ {All_Rental_Coast} **");
                    again: Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the First payment :");
                        Console.ForegroundColor = ConsoleColor.Yellow; First_Payment = double.Parse(Console.ReadLine());
                        while (First_Payment.CHECKING_DOUBLE_INPUT() == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                            Console.ForegroundColor = ConsoleColor.Yellow; First_Payment = double.Parse(Console.ReadLine());
                        }

                        if (First_Payment > All_Rental_Coast)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tSorry You entered much than required, try agin");
                            goto again;
                        }


                        //calculate the second payment that it is (All_Rental_Coast - first_paymen)
                        Scond_Payment = (All_Rental_Coast - First_Payment);

                        // now take the amount of money from the clint file 
                        client.TakingBalance(ATM_card, First_Payment);
                        // first write data to the file then change the car statue in the car file
                        AllData = $"{Car_ID},{client.First_name},{client.Renter_SSN},{client.Phone_number},{this.Rental_Date}," +
                               $"{this.First_Payment},{this.Scond_Payment},{this.All_Rental_Coast},{this.number_Of_days}" +
                               $"";
                        // set the first payment to the company account
                        Icrese_Balance(First_Payment);
                        if (primary == 1)
                        {// this will save the rentting data
                            Car_Class.Change_Car_Statuu(Car_ID, 1);
                        }
                        if (primary == 2)
                        {// this will save the rentting data
                            Car_Class.Change_Car_Statuu(Car_ID, 2);
             
                        }
                        File_MAnagment.Adding_Data_Into_File(fileNAme, AllData);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tSorry Your Balance is not enough, try again latter.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n\t\tSory , Client  Data does not match , or You may have no account Try again later.");
                }

            }
            else if (Car_Class.Car_Status == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\t\tSory the car is ");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("Rented.\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\t\tSory the car is ");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("Reserved.\n");
            }

        }
        public void Search_For_Car_Status()
        {
            The_Car_Class Car_Class = new The_Car_Class();
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\t\tEnter the Car ID:");
            Console.ForegroundColor = ConsoleColor.Yellow; int temp = int.Parse(Console.ReadLine());
            Car_Class.Searching_For_(temp);
            string messag = (Car_Class.Car_Status == 1) ? "Rented" : (Car_Class.Car_Status == 2) ? "Reserved" : (Car_Class.Car_Status == 3) ? "Available" : "Unkown";

            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\t\tCar status is ");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"{messag}");
        }
        private void TheDateInput()// Input the date in the correct format
        {
            bool pass = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Contract end date in the format DD/MM/YYYY : ");
                Console.ForegroundColor = ConsoleColor.Yellow; string input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                    Console.ForegroundColor = ConsoleColor.Yellow; input = Console.ReadLine();
                }
                DateTime date;
                if (DateTime.TryParse(input, out date))
                {
                    pass = true;
                    Returned_date = date;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tinvalid input,try agin :");
                }
            } while (pass == false);
        }
        public virtual void Reading_Data_From_File()
        {
            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Car ID[/]", "[aquamarine1]Renter Name[/]",
            "[seagreen1_1]Renter SSN[/]", "[seagreen1]Renter Phone Number[/]", "[seagreen2]Rental Duration[/]",
             "[seagreen2]All Rental Coast[/]",
            "[honeydew2]First Payment[/]", "[seagreen1_1]Remainning Money [/]");
            //-----------------------------------------
            using (StreamReader CarF = new StreamReader(fileNAme))
            {

                string line;
                while ((line = CarF.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        string[] data = line.Split(',');
                        this.Car_ID = int.Parse(data[0]);
                        this.First_name = data[1];
                        this.Renter_SSN = int.Parse(data[2]);
                        this.Phone_number = int.Parse(data[3]);
                        this.Rental_Date = DateTime.Parse(data[4]);
                        this.First_Payment = double.Parse(data[5]);
                        this.Scond_Payment = double.Parse(data[6]);
                        this.All_Rental_Coast = double.Parse(data[7]);
                        table.AddRow($"[darkslategray2]{Car_ID}[/]", $"[aquamarine1]{First_name}[/]", $"[seagreen1_1]{Renter_SSN}[/]",
                               $"[seagreen1]{Phone_number}[/]", $"[seagreen2]{number_Of_days + 1} Day(s)[/]",
                               $"[darkolivegreen1_1]{All_Rental_Coast}[/]", $"[honeydew2]{First_Payment}[/]", $"[seagreen1_1]{Scond_Payment}[/]");
                    }

                }

                AnsiConsole.Write(table);
            }
        }
        public virtual void Displaying_data_()
        {
            //-----------------------------------------
            var table = new Table();
            table.AddColumns("[darkslategray2]Car ID[/]", "[aquamarine1]Renter Name[/]",
            "[seagreen1_1]Renter SSN[/]", "[seagreen1]Renter Phone Number[/]", "[seagreen2]Rental Duration[/]",
             "[seagreen2]All Rental Coast[/]",
            "[honeydew2]First Payment[/]", "[seagreen1_1]Remainning Money [/]");
            //-----------------------------------------
            table.AddRow($"[darkslategray2]{Car_ID}[/]", $"[aquamarine1]{First_name}[/]", $"[seagreen1_1]{Renter_SSN}[/]",
                              $"[seagreen1]{Phone_number}[/]", $"[seagreen2]{number_Of_days}[/]",
                              $"[darkolivegreen1_1]{All_Rental_Coast}[/]", $"[honeydew2]{First_Payment}[/]", $"[seagreen1_1]{Scond_Payment}[/]");
            AnsiConsole.Write(table);
        }
        public virtual void Searching_For_(int carID)
        {
            if (!File.Exists(fileNAme))// create the file if it's not exist
            {
                try
                {
                    File.Create(fileNAme);
                    using (FileStream fs = File.Create(fileNAme)) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }
            Truth = false;
            using (StreamReader reader = new StreamReader(fileNAme))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if (data.Length >= 9 && int.Parse(data[0]) == carID)
                    {
                        Car_ID = int.Parse(data[0]);
                        First_name = data[1]; 
                        Renter_SSN = int.Parse(data[2]);
                        Phone_number = int.Parse(data[3]);
                        Rental_Date = DateTime.Parse(data[4]);
                        First_Payment = double.Parse(data[5]);
                        Scond_Payment = double.Parse(data[6]);
                        All_Rental_Coast = double.Parse(data[7]);
                        number_Of_days = int.Parse(data[8]);
                        Truth = true;
                        break;
                    }
                    else
                        Truth = false;
                }
            }
        }
        public void Returning_Car()
        {
            Client_class client = new Client_class();
            The_Car_Class Car_Class = new The_Car_Class();
            File_MAnagment_Class File_MAnagment_ = new File_MAnagment_Class();
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\n\n\n\t\t\t\t\t* RETURNING A CAR PART ");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the car ID : ");
            Console.ForegroundColor = ConsoleColor.Yellow; Car_ID = int.Parse(Console.ReadLine());
            while (Car_ID.IS_INTEGER_TYPE() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
                Console.ForegroundColor = ConsoleColor.Yellow; Car_ID = int.Parse(Console.ReadLine());
            }

            this.Searching_For_(Car_ID);
            Car_Class.Searching_For_(Car_ID);
            // First check if the car is rented or not
            if (Car_Class.Car_Status == 1)
            {

                // calculate the remaining money that should the renter pay it
                double Rem = All_Rental_Coast - First_Payment;
                var root = new Tree("");

                // Add some nodes
                var foo = root.AddNode("[yellow]Rented Data[/]");
                var table = foo.AddNode(new Table()
                    .RoundedBorder()
                    .AddColumn("Type")
                    .AddColumn("Value")
                    .AddRow("[darkslategray2]Client name [/]", $"{First_name} {Last_name}")
                    .AddRow("Client SSN", $"{Renter_SSN}")
                    .AddRow("Car ID", $"{Car_ID}"));
                var bar = root.AddNode("[yellow]The Payment[/]");
                bar.AddNode(new Table()
                    .AddColumn("Catogory")
                    .AddColumn("Data")
                    .AddRow("All Rental Coast ", $"{All_Rental_Coast}")
                    .AddRow("First Payement ", $"{First_Payment}")
                    .AddRow("[Red]Remaining money[/]", $"{Rem}"));


                AnsiConsole.Write(root);
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\t\tNote:");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\nThe Remaining amount of money will be withdrawn from " +
                    $"Your account, includeing the losses of Accident and traffic offence if any\n");

                //-----------------------------------
                Icrese_Balance(Rem);
                client.TakingBalance(ATM_card, Rem);

                // now change the car status to available  
                Car_Class.Change_Car_Statuu(Car_ID, 3);

                Traffic_Offence traffic = new Traffic_Offence();
                traffic.Searching_For_(Car_ID);// searching for traffics
                double temp = traffic.Accident_Coast;// get the traffic offence coast
                
               
               if(temp > 0)
                {
                    client.TakingBalance(ATM_card, temp);
                }
               
                traffic.Change_traffic_State(Car_ID);
                File_MAnagment_.Update_And_delet_Data_In_File_(fileNAme, "", Car_ID, 1);// delet the data from the renter file


            }

            // show message if the car is not rented 
            else if (Car_Class.Car_Status == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\t\t- This Car is not rented , it's Reserved\n");
            }
            else if (Car_Class.Car_Status == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\t\t- This Car is not rented , it's Available\n");
            }

        }
        public void Icrese_Balance(double bal)
        {
            int num = 12345;
            double num2 = 0;
            if (!File.Exists("BAlance file.txt"))// create the file if it's not exist
            {
                try
                {
                    File.Create("BAlance file.txt");
                    using (FileStream fs = File.Create("BAlance file.txt")) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }

            Truth = false;
            using (StreamReader reader = new StreamReader("BAlance file.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if (data.Length >= 2 && int.Parse(data[0]) == num)
                    {
                        this.Balance = double.Parse(data[1]);
                        break;
                    }
                    else
                        Truth = false;
                }
            }
            this.Balance += bal;
            string dat = $"{num},{this.Balance}";
            using (FileStream fil = new FileStream("BAlance file.txt", FileMode.Truncate, FileAccess.Write))
            {
                fil.SetLength(0);
            }

           

            File_MAnagment_Class mangae = new File_MAnagment_Class();
            mangae.Adding_Data_Into_File("BAlance file.txt", dat);
        }
        public void dISPLAY_bALANCE()
        {
            if (!File.Exists("BAlance file.txt"))// create the file if it's not exist
            {
                try
                {
                    File.Create("BAlance file.txt");
                    using (FileStream fs = File.Create("BAlance file.txt")) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }
            Truth = false;
            using (StreamReader reader = new StreamReader("BAlance file.txt"))
            {
                string line;
            
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if (data.Length >= 2 && int.Parse(data[0]) == 12345)
                    {
                        this.Balance = double.Parse(data[1]);
                        break;
                    }
                    else
                        Truth = false;
                }
            }

            Console.WriteLine($"Company Balance = {this.Balance}");

        }
    }
}
