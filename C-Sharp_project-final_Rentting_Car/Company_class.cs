using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C_Sharp_project_final_Rentting_Car
{


    public class Company_class
    {

        //public string passWord;
        //public string Copmpany_Name { get; set; }
        //public string Copmany_managerf { get; set; }
        //public string Copmany_managerL { get; set; }

        //public int Copmany_Phone { get; set; }
        //public string Company_website { get; set; }
        //public string All_Data { get; set; }
        //public double CompanyBalance { get; set; }
        //public string fileName = "Company Files.txt";
        

       
        ////constructor given default values for the company data
        //public void CompanyDataSefsultSet()
        //{
           
        //    this.passWord = "00000";
        //    this.Copmpany_Name = "Cars Rentting Company";
        //    this.Copmany_managerf = "Unkown";
        //    this.Copmany_managerL = "Unkown";
        //    this.Copmany_Phone = 00000;
        //    this.Company_website = "WWW.@GhaiCar.Com";
        //    Show_company_data();
        //}

        ////*********************************************************************
        //public void Edit_Copmany_Info()
        //{
        //    int num = 0;
        //    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\n\n\n\t\t\t\t\t COMPANY PART ");
        //    bool found = false;
        //    do
        //    {

        //        Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\n\t\tEnter the Company passWord : ");
        //       string password = Console.ReadLine();
        //        if ((checkFile() && checkPassword(password)) || (!(checkFile() == false) && password == "00000"))
        //        {
        //            Console.Clear();
        //            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Company Name : ");
        //            Console.ForegroundColor = ConsoleColor.Yellow; Copmpany_Name = Console.ReadLine();
        //            while (!Copmpany_Name.IS_STRING_TYPEs() || Copmpany_Name.IsEmptyInput())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
        //                Console.ForegroundColor = ConsoleColor.Yellow; Copmpany_Name = Console.ReadLine();
        //            }
        //            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Company Manager's first name : ");
        //            Console.ForegroundColor = ConsoleColor.Yellow; Copmany_managerf = Console.ReadLine();
        //            while (!Copmany_managerf.IS_STRING_TYPEs() || Copmany_managerf.IsEmptyInput())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
        //                Console.ForegroundColor = ConsoleColor.Yellow; Copmany_managerf = Console.ReadLine();
        //            }
        //            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Company Manager's Last name:");
        //            Console.ForegroundColor = ConsoleColor.Yellow; Copmany_managerL = Console.ReadLine();
        //            while (!Copmany_managerL.IS_STRING_TYPEs() || Copmany_managerL.IsEmptyInput())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
        //                Console.ForegroundColor = ConsoleColor.Yellow; Copmany_managerL = Console.ReadLine();
        //            }
        //            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Compsny Phone Number :");
        //            Console.ForegroundColor = ConsoleColor.Yellow; Copmany_Phone = int.Parse(Console.ReadLine());
        //            while (Copmany_Phone.IS_INTEGER_TYPE() == false)
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
        //                Console.ForegroundColor = ConsoleColor.Yellow; Copmany_Phone = int.Parse(Console.ReadLine());
        //            }
        //            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Company Web Site");
        //            Console.ForegroundColor = ConsoleColor.Yellow; Company_website = Console.ReadLine();
        //            while (!Company_website.IS_STRING_TYPEs() || Company_website.IsEmptyInput())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
        //                Console.ForegroundColor = ConsoleColor.Yellow; Company_website = Console.ReadLine();
        //            }
        //            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\tEnter the Company new password :");
        //            Console.ForegroundColor = ConsoleColor.Yellow; passWord = Console.ReadLine();
        //            while ( Company_website.IsEmptyInput())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\t\t\tUnvalid input,Enter again : ");
        //                Console.ForegroundColor = ConsoleColor.Yellow; passWord = Console.ReadLine();
        //            }
        //             found = true;
        //        }
        //        else
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\n\n\t\t- Password does not match ,Try agin");
        //            num++;
        //        }
        //    } while (found == false && num != 3);
        //    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\tPress any key to continue...");
        //    Console.ReadKey();
        //    Console.Clear();
        //}
        //public bool checkPassword(string pass)
        //{
        //    bool found = false;
        //    StreamReader Com = new StreamReader(fileName);
        //    string lines;

        //    while ((lines = Com.ReadLine()) != null)
        //    {
        //        string[] data = lines.Split(','); // The data seprate by comma split all and assign the data into the array
        //        if (data.Length >= 6 && data[0] == pass)
        //        {
        //            found = true;
        //            break;
        //        }
        //    }
        //    Com.Close();
        //    return found;
        //}
        //public void WriteToFile()
        //{

        //    if (!File.Exists(fileName))// create the file if it's not exist
        //    {
        //        try
        //        {
        //            using (FileStream fs = File.Create(fileName)) { }
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Faild to Create File");
        //        }
        //    }

        //    if (File.Exists(fileName))
        //    {
        //        All_Data = $"{passWord},{this.Copmpany_Name},{this.Copmany_managerf}" +
        //            $",{this.Copmany_managerL},{Copmany_Phone},{Company_website},{CompanyBalance}";
        //        File.Delete(fileName);// delet old data the update the data
        //        using (StreamWriter ff = File.AppendText(fileName))// open the file in append mode
        //        {
        //            ff.WriteLine(All_Data);// writting the data in the file
        //            ff.Close();
        //        }
        //    }

        //}

        //public bool checkFile()
        //{
        //    // this function check if the password is empty or has data stored
        //    if (!File.Exists(fileName))// create the file if it's not exist
        //    {
        //        try
        //        {
        //            using (FileStream fs = File.Create(fileName)) { }
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Faild to Create File");
        //        }
        //    }
        //    bool found = false;
        //    StreamReader Com = new StreamReader(fileName);
        //    string lines;

        //    while ((lines = Com.ReadLine()) != null)
        //    {
        //        string[] data = lines.Split(',');
        //        if (data.Length > 0)
        //        {
        //            found = true;
        //            break;
        //        }
        //    }
        //    Com.Close();
        //    return found;

        //}
        //public void ReadingData()
        //{// reading the company data
        //    if (!File.Exists(fileName))// create the file if it's not exist
        //    {
        //        StreamReader DepartFile = new StreamReader(fileName);
        //    }
        //    StreamReader CompData = new StreamReader(fileName);


        //    string lines;
        //    bool found = false;
        //    while ((lines = CompData.ReadLine()) != null)
        //    {// reading the data of the company from the file
        //        if (lines.Length > 0)
        //        {// this for ignoring the empty lines in the file
        //            string[] data = lines.Split(',');
        //            this.passWord = data[0];
        //            this.Copmpany_Name = data[1];
        //            this.Copmany_managerf = data[2];
        //            this.Copmany_managerL = data[3];
        //            this.Copmany_Phone = int.Parse(data[4]);
        //            this.Company_website = data[5];
        //            this.CompanyBalance = double.Parse(data[6]);
        //            if (passWord != "0")
        //                found = true;
        //        }
        //    }
        //    if (found == false)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\t\t\t\tNo data foound....");

        //        CompanyDataSefsultSet();
        //    }
        //}

        //public void displayBalance()
        //{
        //    ReadingData();
        //    Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("\n\t\t|-------------------------------------------|");

        //    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write($"\n\n\t\t\tCompany Balance id = ");
        //    Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($" ${CompanyBalance}\n");

        //    Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("\n\t\t|-------------------------------------------|\n");
        //}

        //public void Show_company_data()
        //{
        //    //-----------------------------------------
        //    var table = new Table();
        //    table.AddColumns("[darkslategray2]Company name[/]", "[aquamarine1]Company Phone[/]",
        //    "[seagreen1_1]Company Website[/]", "[seagreen1]Company Manager [/]", "[seagreen2]Company Balance[/]",
        //    "[honeydew2] Company Password [/]");
        //    //-----------------------------------------
           
        //    table.AddRow($"[darkslategray2]{Copmpany_Name}[/]", $"[aquamarine1]{Copmany_Phone}[/]", $"[seagreen1_1]{Company_website}[/]",
        //                       $"[seagreen1]{Copmany_managerf} {Copmany_managerL}[/]", $"[seagreen2]{CompanyBalance}[/]",
        //                       $"[darkolivegreen1_1]{passWord}[/]");
        //    AnsiConsole.Write(table);
        //    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
        //    Console.ReadKey(); Console.Clear();
        //    //-----------------------------------------

          



        //}

        ////***************************** Company Account Part ******************
        //public void SetAccount(double account)
        //{
        //    if (!File.Exists(fileName))// create the file if it's not exist
        //    {
        //        StreamReader DepartFile = new StreamReader(fileName);
        //    }
        //    else
        //    {
        //        double pro = 0;
        //        using (StreamReader reader = new StreamReader(fileName))
        //        using (StreamWriter writer = new StreamWriter("Temp file.txt"))
        //        {
        //            string line;
        //            while ((line = reader.ReadLine()) != null)
        //            {
        //                string[] objectData = line.Split(',');
        //                // if the line of car id not found write the data to the temp file
        //                if (objectData.Length > 0)
        //                {
        //                    if (double.TryParse(objectData[6], out double num))
        //                        pro = num;
        //                    pro += account;
        //                    string all = $"{objectData[0]},{objectData[1]},{objectData[2]},{objectData[3]},{objectData[4]},{objectData[5]},{pro}";
        //                    writer.WriteLine(all);
        //                }

        //            }
        //        }
        //        // replace the original file with the update file
        //        File.Delete(fileName);
        //        File.Move("Temp file.txt", fileName);
        //    }
        //}

        //public void Increse_Company_balance(double incre)
        //{
        //    if (!File.Exists("Balance.txt"))// create the file if it's not exist
        //    {
        //        try
        //        {
        //            File.Create("Balance.txt");
        //            using (FileStream fs = File.Create("Balance.txt")) { }
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Faild to Create File");
        //        }
        //    }
        //    using (StreamReader reader = new StreamReader("Balance.txt"))
        //    using (StreamWriter writer = new StreamWriter("Temp file.txt"))
        //    {
        //        string line;
        //        double Balance = 0L;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            Balance = double.Parse(line);
        //            // if the line of car id not found write the data to the temp file
        //            if (line.Length>0 )
        //            {
        //                Balance += incre;
        //                writer.WriteLine(Balance);
                       
        //            }

        //            using (FileStream fil = new FileStream("Balance.txt", FileMode.Truncate, FileAccess.Write))
        //            {
        //                fil.SetLength(0);
        //            }


        //        }
        //        Balance += incre;
        //    }
        //    // replace the original file with the update file
        //    File.Delete("Balance.txt");
        //    File.Move("Temp file.txt", "Balance.txt");
        //}
        //public void Display_Company_balance()
        //{
        //    double balance=0l;
        //    if (!File.Exists("Balance.txt"))// create the file if it's not exist
        //    {
        //        try
        //        {
        //            File.Create("Balance.txt");
        //            using (FileStream fs = File.Create("Balance.txt")) { }
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Faild to Create File");
        //        }
        //    }
            
        //    using (StreamReader CarF = new StreamReader("Balance.txt"))
        //    {
        //        string line;
        //        while ((line = CarF.ReadLine()) != null)
        //        {
        //            if (line.Length > 0)
        //            {
        //                balance = double.Parse(line);
        //            }
        //        }
               
        //    }
        //    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("Company Balance is : ");
        //    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"{balance}");

        //}

        //*********************************************************************

    }
   
}
