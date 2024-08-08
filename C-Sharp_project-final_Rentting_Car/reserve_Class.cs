using Spectre.Console;
using System;
using System.IO;
using System.Threading;

namespace C_Sharp_project_final_Rentting_Car
{
    public class reserve_Class:Rentel_Employee_class,IMain_Actions
    {
        static private string File_Name2 = "reserve file.txt";
        public double remaining_Money { get; set; }
        public double cancel_coast { get; set; }
        public void Cancel_Reservation()
        {
            The_Car_Class Car_Class = new The_Car_Class();
            Client_class client = new Client_class();
            Rentel_Employee_class rentel_Employee_Class = new Rentel_Employee_class();
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\n\n\n\t\t\t\t\t* CANCELLING BOOKed CAR PART ");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the car ID : ");
            Console.ForegroundColor = ConsoleColor.Yellow; Car_ID = int.Parse(Console.ReadLine());
            Car_Class.Searching_For_(Car_ID);// get all data
            rentel_Employee_Class.Searching_For_(Car_ID);
            if (Car_Class.Car_Status == 2 && Car_Class.Truth == true)// if the car is reserved
            {
                AnsiConsole.Status()
        .Start("Loading...", ctx =>
        {
            Thread.Sleep(1000);
            // Update the status and spinner
            ctx.Status("\n\n\t\t\tGetting data...");
            ctx.SpinnerStyle(Style.Parse("green"));
            Thread.Sleep(2000);
        });

                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n\t\tReserver name : {this.First_name} {this.Last_name} ");
                
                
                // if the Reservation is exist display the Reservater name 
                // and calculate the calncel coast

                if (rentel_Employee_Class.number_Of_days < 1)
                {
                    cancel_coast = First_Payment * 0; // deducated 10%}
                }
                if (rentel_Employee_Class.number_Of_days == 1)
                {
                    cancel_coast = First_Payment * 0.1; // deducated 10%}
                }
                if (rentel_Employee_Class.number_Of_days > 1 && rentel_Employee_Class.number_Of_days <= 2)
                {
                    cancel_coast = First_Payment * 0.4;// deducated 40%
                }
                if (rentel_Employee_Class.number_Of_days > 2 && rentel_Employee_Class.number_Of_days <= 3)
                {
                    cancel_coast = First_Payment * 0.6;// deducated 60%
                }
                if (rentel_Employee_Class.number_Of_days > 3 && rentel_Employee_Class.number_Of_days <= 4)
                {
                    cancel_coast = First_Payment * 0.8;// deducated 80%
                }
                if (rentel_Employee_Class.number_Of_days > 4)
                {
                    cancel_coast = rentel_Employee_Class.First_Payment * 1;
                }
                remaining_Money = rentel_Employee_Class.First_Payment - cancel_coast;

                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\t\tThe Cancel coast is = {cancel_coast} ");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"has been deducated from your balance\n");

                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n\t\tYour Remaining money is = ${remaining_Money}");
               

                // now add the remaining money for the client to his account
                client.AddingBalamce(Renter_SSN, remaining_Money);
                Car_Class.Change_Car_Statuu(Car_ID,3);
                

            }
            else if (Car_Class.Car_Status == 3 )
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tThe Car is not reserved ,it's available");
            }
            else if (Car_Class.Car_Status == 2 )
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tThe Car is not reserved ,it's Rented");
            }

        }
        public override void Searching_For_(int carID)
        {
            if (!File.Exists(File_Name2))// create the file if it's not exist
            {
                try
                {
                    File.Create(File_Name2);
                    using (FileStream fs = File.Create(File_Name2)) { }
                }
                catch
                {
                    Console.WriteLine("Faild to Create File");
                }
            }
            Truth = false;
            using (StreamReader reader = new StreamReader(File_Name2))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if (data.Length >= 9 && int.Parse(data[1]) == carID)
                    {
                        First_name = data[0];
                        Car_ID = int.Parse(data[1]);
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
    }
}
