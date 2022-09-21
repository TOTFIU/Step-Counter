using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TRAINER.Models
{
    public class UserModel_InTable : INotifyPropertyChanged
    {
        private string _user;
        private int _stepsAverage;
        private int _stepsMin;
        private int _stepsMax;
        private bool _colour;
        public string User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public int StepsAverage 
        {
            get { return _stepsAverage; }
            set
            {
                _stepsAverage = value;
                OnPropertyChanged("StepsAverage");
            }
        }

        public int StepsMin 
        {
            get { return _stepsMin; }
            set
            {
                _stepsMin = value;
                OnPropertyChanged("StepsMin");
            }
        }

        public int StepsMax 
        {
            get { return _stepsMax; }
            set
            {
                _stepsMax = value;
                OnPropertyChanged("StepsMax");
            }
        }
        public string Status { get; set; }
        public int RankAverage { get; set; }

        public bool Colour
        {
            get { return _colour; }
            set
            {
                _colour = value;
                OnPropertyChanged("Colour");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
