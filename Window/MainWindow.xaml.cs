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
        Ship ship;

        public MainWindow()
        {
            InitializeComponent();

            FileNew_Click(null, null);
        }

        private void FileNew_Click(object sender, RoutedEventArgs e)
        {
            ship = new Ship();
            RSSE_MainWindow.DataContext = new ShipViewModel(ship);
        }

        private void FileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ROG file (*.ROG)|*.ROG|Lua file (*.lua)|*.lua";
            if (openFileDialog.ShowDialog() == true)
            {
                string content = File.ReadAllText(openFileDialog.FileName);

                //get the basename : no better solution? 
                string[] s = openFileDialog.FileName.Split('.', '\\', '/');
                string name = s[s.Count() - 2];

                ShipTable table = new ShipTable(name, content);
                ship = new Ship(table);
                RSSE_MainWindow.DataContext = new ShipViewModel(ship);
            }
        }

        private void FileSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ROG file (*.ROG)|*.ROG|Lua file (*.lua)|*.lua";
            if (saveFileDialog.ShowDialog() == true)
            {
                ShipTable table = ship.ToShipTable();
                string serialized = table.ToString();
                File.WriteAllText(saveFileDialog.FileName, serialized);
            }
        }
    }
}
