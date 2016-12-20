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
using System.Windows.Shapes;
using System.IO;

namespace RSSE
{
    /// <summary>
    /// Logique d'interaction pour SettingsWindows.xaml
    /// </summary>
    public partial class StartupSettingsWindows : Window
    {
        public StartupSettingsWindows()
        {
            InitializeComponent();
        }
        
        private void SelectRogueSystemFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new WPFFolderBrowser.WPFFolderBrowserDialog();
            if ( (bool)dialog.ShowDialog() )
            {
                RogueSystemFolder.Text = dialog.FileName;
            }
            
        }

        private void SaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            string folder = RogueSystemFolder.Text.Replace("\\", "/");
            Appli.Instance.Settings.RogueSysemFileRoot = folder;
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
