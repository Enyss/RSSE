using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        private object currentViewModel;
        public object CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }
        public string ShipName { get; set; }

        private Appli()
        {
        }

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


    }
}
