using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace RSSE
{
    class ApplicationStartupViewModel : ObservableObject
    {
        ShipHullManager _shipHullManager;

        public ICommand OpenShipHullCommand { get; private set; }
        public ICommand OpenMainMenuCommand { get; private set; }

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
        
        public ApplicationStartupViewModel()
        {
            OpenShipHullCommand = new DelegateCommand<ShipHullViewModel>(OpenShipHull);
            OpenMainMenuCommand = new DelegateCommand(OpenMainMenu);
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
