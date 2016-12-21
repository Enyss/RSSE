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
using Microsoft.Win32; // for file open/save box
using System.IO;





namespace RSSE
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Appli appli;

        public MainWindow()
        {
            InitializeComponent();

            appli = Appli.Instance;
            DataContext = appli;
            appli.Init();

        }

        private void FileNew_Click(object sender, RoutedEventArgs e)
        {
            ShipHull ship = new ShipHull();
            appli.ShipName = ship.name;
            appli.CurrentViewModel = new ShipHullViewModel(ship);
        }

        private void FileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ROG file (*.ROG)|*.ROG|Lua file (*.lua)|*.lua";
            if (openFileDialog.ShowDialog() == true)
            {
                
            }
        }

        private void FileSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            /*SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ROG file (*.ROG)|*.ROG|Lua file (*.lua)|*.lua";
            if (saveFileDialog.ShowDialog() == true)
            {
                ShipTable table = ship.ToShipTable();
                string serialized = table.ToString();
                File.WriteAllText(saveFileDialog.FileName, serialized);
            }
            */
        }
    }
}
