using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Windows;

namespace RSSE
{
    class Appli : ObservableObject
    {
        #region Singleton 

        private static readonly Lazy<Appli> lazy = new Lazy<Appli>(() => new Appli());

        public static Appli Instance { get { return lazy.Value; } }

        #endregion

        private Settings settings;
        public Settings Settings { get { return settings; } }

        private IMainViewModel currentViewModel;
        public IMainViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
                OnPropertyChanged("Title");
            }
        }

        public string Title { get { return CurrentViewModel.Title; } } 

        public string ShipName { get; set; }
        public MenuViewModel menuViewModel;

        public ICommand ViewShipHullCommand { get; set; }
        public ICommand ViewMenuCommand { get; set; }

        private Appli()
        {
            ViewShipHullCommand = new DelegateCommand<string>(ViewShipHull);
            ViewMenuCommand = new DelegateCommand(ViewMenu);
        }

        public void Init()
        {
            LoadSettings("settings.xml");
            if (Settings.RogueSysemFileRoot == null)
            {
                StartupSettingsWindows setBaseFolder = new StartupSettingsWindows();
                setBaseFolder.ShowDialog();
                SaveSettings("settings.xml");
            }

            menuViewModel = new MenuViewModel();
            menuViewModel.Load();
            CurrentViewModel = menuViewModel;
        }

        #region Settings
        public void LoadSettings(string filename)
        {
            try
            {
                settings = Settings.Load<Settings>(filename);
            }
            catch(Exception)
            {
                settings = new Settings();
            }
            
        }

        public void SaveSettings(string filename)
        {
            Settings.Save<Settings>(filename);
        }
        #endregion

        #region Commands

        private void ViewMenu()
        {
            CurrentViewModel = menuViewModel;
        }

        private void ViewShipHull(string shipHullName)
        {
            try
            {
                ShipName = shipHullName;
                string content = File.ReadAllText(Settings.RogueSysemFileRoot+ "/Mod/RogSysCM/Ships/"+shipHullName+".ROG");
                ShipHullTable shipHullTable = new ShipHullTable(shipHullName, content);
                ShipHull shipHull = new ShipHull(shipHullTable);
                ShipHullViewModel shipHullViewModel = new ShipHullViewModel(shipHull);
                CurrentViewModel = shipHullViewModel;
            }
            catch(FileNotFoundException e)
            {
                MessageBox.Show("Cannot found the ship file !");
            }
        }

        #endregion
    }
}
