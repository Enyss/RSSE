using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;

namespace RSSE
{
    class ApplicationStartupViewModel : ObservableObject
    {
        public Settings settings;

        public string Title { get { return "Overview"; } }

        #region ShipHull list
        private ShipHullManager _shipHullManager;
        public ObservableCollection<ShipHullViewModel> ShipHulls { get; set; }
        #endregion

        #region  

        #region Commands
        public ICommand OpenShipHullCommand { get; private set; }
        public ICommand OpenMainMenuCommand { get; private set; }
        #endregion

        // TODO? Refactor this into another class? 
        private object selectedViewModel;
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ApplicationStartupViewModel()
        {
            // Bind commands to functions
            OpenShipHullCommand = new DelegateCommand<ShipHullViewModel>(OpenShipHull);
            OpenMainMenuCommand = new DelegateCommand(OpenMainMenu);

            // Startup
            LoadSettings();
            LoadShipHulls();
            SelectedViewModel = this;
        }

        private void LoadSettings()
        {
            try
            {
                settings = Settings.Load<Settings>("settings.xml");
            }
            catch (FileNotFoundException)
            {
                settings = new Settings();
                StartupSettingsWindows win = new StartupSettingsWindows();
                win.DataContext = settings;
                win.ShowDialog();
            }
        }

        private void LoadShipHulls()
        {
            ShipHulls = new ObservableCollection<ShipHullViewModel>();
            _shipHullManager = new ShipHullManager(settings.RogueSysemFileRoot + "/Mod/RogSysCM/Ships/");
            foreach(ShipHull shipHull in _shipHullManager.shipHulls)
            {
                ShipHulls.Add(new ShipHullViewModel(shipHull));
            }
        }

        private void OpenShipHull(ShipHullViewModel shipHull)
        {
            SelectedViewModel = shipHull;
        }

        private void OpenMainMenu()
        { 
            SelectedViewModel = this;
        }
    }
}
