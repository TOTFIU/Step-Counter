using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRAINER.Models;
using TRAINER.Services;
using TRAINER.ViewModel;

namespace TRAINER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = new ApplicationViewModel();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            //UserGraph userGraph = new();

            //Polyline myPolyLine = userGraph.DrawUserGraphic();

            //GraphicCanvas.Children.Add(myPolyLine);
            

        }

        private void Window_Closing(object sender, CancelEventArgs e)
            
        {
            DirectoryInfo dirInfo = new($"{Directory.GetCurrentDirectory()}\\PROCESSED_DATA\\") ;

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }


    }
   
}
