

namespace C_Sharp_project_final_Rentting_Car
{
    public interface IMain_Actions
    {
        void The_Main_Class_Menue();
        void Registting_Data(int primary);
        void Reading_Data_From_File();
        // i dont't put this function in the file class,becouse all class must read its own data
        void Displaying_data_();
        void Searching_For_(int PrimaryKey);
    }
}
