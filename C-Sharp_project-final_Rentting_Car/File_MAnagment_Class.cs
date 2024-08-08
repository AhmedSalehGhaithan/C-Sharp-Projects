using Spectre.Console;
using System;
using System.IO;
using System.Threading;

namespace C_Sharp_project_final_Rentting_Car
{
    public class File_MAnagment_Class
    {
        public void Adding_Data_Into_File(string file_name_, string data_)
        {
            
                if (!File.Exists(file_name_))// create the file if it's not exist
                {
                    try
                    {
                       File.Create(file_name_);
                        using (FileStream fs = File.Create(file_name_)) { }
                    }
                    catch
                    {
                        Console.WriteLine("Faild to Create File");
                    }
                }

                if (File.Exists(file_name_))
                {
                using (StreamWriter Data_File = File.AppendText(file_name_))// open the file in append mode
                {
                        Data_File.WriteLine(data_);// writting the data in the file
                        Data_File.Close();
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
            //...............................
           
            
        }
        public void Update_And_delet_Data_In_File_(string file_name_, string data_,int id,int type_Of_Process)
        { 
            using (StreamReader reader = new StreamReader(file_name_))
                using (StreamWriter writer = new StreamWriter("Temp file.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] objectData = line.Split(',');
                    // if the line of car id not found write the data to the temp file
                    if (objectData.Length > 0 && int.Parse(objectData[0]) != id)
                        {
                            writer.WriteLine(line);
                        }
                         else if (objectData.Length > 0 && int.Parse(objectData[0]) == id && type_Of_Process==2)
                        {// else if the car id found update the data
                            writer.WriteLine(data_);
                        }
                    }
                }
            // replace the original file with the update file
            File.Delete(file_name_);
            File.Move("Temp file.txt", file_name_);
            //.....................................
            
            
            //...............................
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t\t\tCar Updated Successfully.");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\t\t\t\t\tPress any key to continue...");
            Console.ReadKey(); Console.Clear();
        }
    }
}
