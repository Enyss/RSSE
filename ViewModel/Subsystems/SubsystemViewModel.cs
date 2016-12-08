using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE
{
    public class SubsystemViewModel : ObservableObject, IViewModel<Subsystem>
    {
        private Subsystem _subsystem;
        public Subsystem Model { get { return _subsystem; } }
        virtual public SubsystemTypeEnum SystemType { get { return _subsystem.SystemType; } }
        virtual public string SystemGroup { get { return _subsystem.SystemGroup; } }

        public SubsystemViewModel() { }

        public SubsystemViewModel(Subsystem subsystem)
        {
            LoadFrom(subsystem);
        }

        virtual public void LoadFrom(Subsystem model)
        {
            _subsystem = model;
        }

        public bool IsViewModelOf(Subsystem model)
        {
            return model.Equals(_subsystem);
        }

    }
}
