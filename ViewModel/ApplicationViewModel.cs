using Newtonsoft.Json;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Shapes;
using TRAINER.Commands;
using TRAINER.Models;
using DataPoint = TRAINER.Models.DataPoint;

namespace TRAINER.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private UserModel_InTable selectedUser;
        //private Polyline myPolyLine;
        private IEnumerable<DataPoint> dataPoints;

        private BindingList<UserModel_InData> _userDataList;
        public ObservableCollection<UserModel_InTable> USERS { get; set; }
        private bool _ISSELECTED;
        //public Polyline MyPolyLine
        //{
        //    get { return myPolyLine; }
        //    set
        //    {
        //        myPolyLine = value;
        //        OnPropertyChanged("MyPolyLine");
        //    }
        //}
        public bool ISSELECTED
        {
            get { return _ISSELECTED; }
            set 
            { 
                _ISSELECTED = value;
                OnPropertyChanged("ISSELECTED");
            }
        }
        public IEnumerable<DataPoint> DataPoints
        {
            get { return dataPoints; }
            set
            {
                dataPoints = value;
                OnPropertyChanged(nameof(DataPoints));

            }
        }

        public UserModel_InTable SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
                GetPoints();
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            //Save почему-то не работает, не могу понять почему. При нажатии на кнопку даже не входит сюда
            // не успеваю доделать, простите... :(
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      using (StreamWriter writer = File.CreateText($"{Directory.GetCurrentDirectory}\\SAVED_USERS\\{selectedUser}.json"))
                      {
                          string output = JsonConvert.SerializeObject(selectedUser);
                          writer.Write(output);
                      }
                  }));
            }
        }


       





        public ApplicationViewModel()
        {
            USERS = new ObservableCollection<UserModel_InTable>();

            ViewProcessed View = new();

            View.ProcessUsers(30);

            _userDataList = View.UserDataList;

            foreach (var User in View.UserDataList)
            {
                UserModel_InTable currentUser = new();

                currentUser.User = User.User;

                currentUser.StepsAverage = User.Steps.Values.Sum() / User.Steps.Values.Count();

                currentUser.StepsMin = User.Steps.Values.Min();

                currentUser.StepsMax = User.Steps.Values.Max();

                if (currentUser.StepsMax >= currentUser.StepsAverage * 1.2 || currentUser.StepsAverage >= currentUser.StepsMin * 1.2)
                {
                    currentUser.Colour = true;
                }
                else currentUser.Colour = false;

                USERS.Add(currentUser);
            }
        }


        public IEnumerable<DataPoint> GetPoints()
        {
            var listPoints = new List<DataPoint>();
            string name = selectedUser.User;
            try
            {
                
                foreach (var User in _userDataList)
                {
                    if (User.User == name)
                    {
                        int i = 1;
                        foreach (var thing in User.Steps)
                        {
                            int y = User.Steps[i];
                            
                            listPoints.Add(new DataPoint { ValueX = i, ValueY = y });
                            i++;
                        }
                    }
                    else continue;
                }
                DataPoints = listPoints;
                return DataPoints;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error " + ex.Message.ToString());
                return null;
            }
        }
        //public void SaveSelected()
        //{
        //    foreach (var User in USERS)
        //    {
        //        if (_ISSELECTED == true)
        //        {
        //            using (StreamWriter writer = File.CreateText($"{Directory.GetCurrentDirectory}\\SAVED_USERS\\"))
        //            {
        //                string output = JsonConvert.SerializeObject(User);
        //                writer.Write(output);
        //            }
        //        }
        //    }
        //}


        //public Polyline Dothing(UserModel_InTable SelectedUser)
        //{
        //    UserGraph userGraph = new();
        //    Dictionary<int, int> DotDictionary = userGraph.GetGraphicDots(SelectedUser);
        //    Polyline myPolyLine = userGraph.DrawUserGraphic(DotDictionary);
        //    return myPolyLine;
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

 

            }
        }
        
    }
}
