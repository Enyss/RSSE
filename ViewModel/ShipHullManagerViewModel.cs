using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace RSSE.ViewModel
{
    class ShipHullManagerViewModel
    {
        private ShipHullManager manager;
        public ShipHullManager Model { get { return manager; } }

        ObservableCollection<ShipHullViewModel> ShipHulls { get; set; }

        public ShipHullManagerViewModel()
        {
            manager = new ShipHullManager();

        }
    }
}
