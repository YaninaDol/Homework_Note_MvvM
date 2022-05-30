using Homework_Note_MvvM.Model;
using Homework_Note_MvvM.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Homework_Note_MvvM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public File_Model read_write = new File_Model();
        ApplicationViewModel myModel= new ApplicationViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = myModel;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            read_write.Write(myModel.Notes);
        }
    }
}
