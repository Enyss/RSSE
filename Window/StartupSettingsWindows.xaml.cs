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
using Avalon.Windows.Dialogs;
using Avalon;


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
            Avalon.Windows.Dialogs.FolderBrowserDialog dialog = new Avalon.Windows.Dialogs.FolderBrowserDialog();
            dialog.BrowseFiles = false;
            if (dialog.ShowDialog() == true)
            {
                RogueSystemFolder.Text = dialog.SelectedPath;
            }
        }

        private void SaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            RogueSystemFolder.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ((Settings)DataContext).Save<Settings>("settings.xml");
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
