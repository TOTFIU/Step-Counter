using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using TRAINER.Services;

namespace TRAINER.Models
{
    public class UserGraph
    {
        private FileIOServices _fileIOServices;

        private BindingList<UserModel_InData> _userDataList = null;
        public BindingList<UserModel_InData> UserDataList
        {
            get { return _userDataList; }
        }


        

        //шаг 12 пикселей


        //public Dictionary<int, int> GetGraphicDots(UserModel_InTable _selectedUser)
        //{
        //    int step = 25;
        //    Dictionary<int, int> DotCoordinates = new();

        //    foreach (var User in UserInfoList)
        //    {
        //        DotCoordinates.Add(step, User.Steps / 100);
        //        step += 12;
        //    }

        //    return DotCoordinates;


        //}


        //public Polyline DrawUserGraphic(Dictionary<int, int> Dot_Dictionary)
        //{

        //    Polyline myPolyLine = new Polyline();
        //    myPolyLine.Stroke = Brushes.SlateGray;
        //    myPolyLine.StrokeThickness = 2;
        //    PointCollection myPointCollection = new PointCollection();


        //    foreach (var point in Dot_Dictionary)
        //    {
        //        System.Windows.Point Point1 = new System.Windows.Point(point.Key, point.Value);
        //        myPointCollection.Add(Point1);
        //    }
        //    myPolyLine.Points = myPointCollection;

        //    return myPolyLine;
        //}
    }
}
