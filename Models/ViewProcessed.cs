using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TRAINER.Services;

namespace TRAINER.Models
{
    internal class ViewProcessed
    {

        private BindingList<UserModel_InData> _userDataList = null;
        public BindingList<UserModel_InData> UserDataList
        {
            get { return _userDataList; }
        }
        private FileIOServices _fileIOServices;
        

        public void ProcessUsers(int daysTotal)
        {

            for (int days = 1; days <= daysTotal; days++)
            {

                string PATH_TOLOAD = $"{Directory.GetCurrentDirectory()}\\Data\\day{days}.json";

                try
                {
                    _fileIOServices = new FileIOServices(PATH_TOLOAD);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                BindingList<USER_WITHOUT_DICTIONARY> Obj = _fileIOServices.LoadData();
                BindingList<UserModel_InData> Objects = new();
                foreach (var User in Obj)
                {
                    UserModel_InData USER_WITH_DICTIONARY= new();

                    USER_WITH_DICTIONARY.User = User.User;

                    Dictionary<int, int> StepsDictionary = new();
                    StepsDictionary.Add(days, User.Steps);
                    USER_WITH_DICTIONARY.Steps = StepsDictionary;

                    Dictionary<int, string> StatusDictionary = new();
                    StatusDictionary.Add(days, User.Status);
                    USER_WITH_DICTIONARY.Status = StatusDictionary;


                    Dictionary<int, int> RankDictionary = new();
                    RankDictionary.Add(days, User.Rank);
                    USER_WITH_DICTIONARY.Rank = RankDictionary;


                    Objects.Add(USER_WITH_DICTIONARY);
                }


                if (_userDataList == null)
                    _userDataList = Objects;
                else
                {
                    foreach (var User in Objects)
                    {//Здесь теряется один разпустов кто-то там, (в 13 день его нет) (как его вернуть?)

                        

                        foreach (var User1 in _userDataList)
                        {
                            
                            if (User.User == User1.User)
                            {
                                
                                User1.Steps.Add(days, User.Steps[days]);
                                User1.Status.Add(days, User.Status[days]);
                                User1.Rank.Add(days, User.Rank[days]);

                            }
                        }

                    }
                }







                //foreach (var User in _userDataList)
                //{

                //    string PATH_TOWRITE = $"{Directory.GetCurrentDirectory()}\\PROCESSED_DATA\\{User.User}.json";



                //    bool fileExist = File.Exists(PATH_TOWRITE);
                //    if (fileExist)
                //    {
                //        BindingList<UserModel_InData> userList = new();

                //        _fileIOServices = new FileIOServices(PATH_TOWRITE);

                //        userList = _fileIOServices.LoadData();

                //        userList.Add(User);

                //        _fileIOServices.SaveData(userList);

                //    }
                //    else
                //    {
                //        BindingList<UserModel_InData> userList = new();
                //        userList.Add(User);
                //        _fileIOServices = new FileIOServices(PATH_TOWRITE);
                //        _fileIOServices.SaveData(userList);
                //    }

                //}

            }



        }

    }
}
