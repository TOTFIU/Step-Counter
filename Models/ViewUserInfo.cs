using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAINER.Services;

namespace TRAINER.Models
{
    internal class ViewUserInfo
    {

        private FileIOServices _fileIOServices;

        //public string PATH { get; set; }




    //    public ObservableCollection<UserModel_InTable> RemakeUserModel_InData_to_UserModel_InTable()
    //    {
    //        ObservableCollection<UserModel_InTable> TABLE_DATA = new();

    //        DirectoryInfo dirInfo = new($"{Directory.GetCurrentDirectory()}\\PROCESSED_DATA\\");

    //        foreach (FileInfo file in dirInfo.GetFiles())
    //        {
    //            if (file.Extension == ".json")
    //            {
    //                BindingList<UserModel_InData> UserInfoList = new BindingList<UserModel_InData>();

    //                string PATH = $"{file.FullName}";

    //                _fileIOServices = new FileIOServices(PATH);

    //                UserInfoList = _fileIOServices.LoadData();




    //                UserModel_InTable USER_InTable = new UserModel_InTable();

    //                List<int> TOTAL_STEPS = new List<int>();
    //                List<int> TOTAL_RANK = new List<int>();
    //                List<string> TOTAL_STATUS = new List<string>();


    //                foreach (var user in UserInfoList)
    //                {
    //                    USER_InTable.User ??= user.User;

    //                    TOTAL_STEPS.Add(user.Steps);

    //                    TOTAL_RANK.Add(user.Rank);

    //                    TOTAL_STATUS.Add(user.Status);//пока что будет null в User_inTable

    //                }

    //                USER_InTable.StepsMin = TOTAL_STEPS.Min();
    //                USER_InTable.StepsMax = TOTAL_STEPS.Max();
    //                USER_InTable.StepsAverage = TOTAL_STEPS.Sum() / TOTAL_STEPS.Count();
    //                USER_InTable.RankAverage = TOTAL_RANK.Sum() / TOTAL_RANK.Count();

    //                TABLE_DATA.Add(USER_InTable);

    //                _fileIOServices = new FileIOServices($"{Directory.GetCurrentDirectory()}\\TABLE_DATA\\{USER_InTable.User}.json");
    //                _fileIOServices.SaveTableData(USER_InTable);
    //            }
    //            else continue;

    //        }
    //        return TABLE_DATA;

    //    }
    }
}
