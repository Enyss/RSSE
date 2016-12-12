using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace RSSE
{
    public class SubsystemsManagerViewModel : IViewModel<SubsystemsManager>
    {
        private SubsystemsManager _subsystems;
        public SubsystemsManager Model { get { return _subsystems; } }
        public ObservableCollection<SubsystemViewModel> Subsystems { get; set; }
        public SubsystemsManagerTemplateSelector TemplateSelector {get; set; }
        public SubsystemViewModel SelectedItem
        {
            get;
            set;
        }

        public SubsystemsManagerViewModel()
        {
            TemplateSelector = new SubsystemsManagerTemplateSelector();
            Subsystems = new ObservableCollection<SubsystemViewModel>();
        }

        public SubsystemsManagerViewModel(SubsystemsManager model)
        {
            TemplateSelector = new SubsystemsManagerTemplateSelector();
            Subsystems = new ObservableCollection<SubsystemViewModel>();
            LoadFrom(model);
        }

        public void LoadFrom(SubsystemsManager model)
        {
            _subsystems = model;

            Subsystems.Clear();

            foreach( var subsystem in model.subsystems)
            {
                SubsystemViewModel vm;

                // need to factor this into an item factory
                switch( subsystem.SystemType )
                {
                    case SubsystemTypeEnum.AccessoriesManager:
                        vm = new AccessoriesManagerViewModel();
                        break;
                    case SubsystemTypeEnum.AttachementsManager:
                        vm = new AttachementsManagerViewModel();
                        break;
                    case SubsystemTypeEnum.BMS:
                        vm = new BMSViewModel();
                        break;
                    case SubsystemTypeEnum.CameraManager:
                        vm = new CameraManagerViewModel();
                        break;
                    case SubsystemTypeEnum.COMM:
                        vm = new COMMViewModel();
                        break;
                    case SubsystemTypeEnum.CSSM:
                        vm = new CSSMViewModel();
                        break;
                    case SubsystemTypeEnum.ECS:
                        vm = new ECSViewModel();
                        break;
                    case SubsystemTypeEnum.FCM:
                        vm = new FCMViewModel();
                        break;
                    case SubsystemTypeEnum.Legacy:
                        vm = null;
                        break;
                    case SubsystemTypeEnum.LENR:
                        vm = new LENRViewModel();
                        break;
                    case SubsystemTypeEnum.LSS:
                        vm = new LSSViewModel();
                        break;
                    case SubsystemTypeEnum.MES:
                        vm = new MESViewModel();
                        break;
                    case SubsystemTypeEnum.MFD:
                        vm = new MFDViewModel();
                        break;
                    case SubsystemTypeEnum.MTS:
                        vm = new MTSViewModel();
                        break;
                    case SubsystemTypeEnum.NAS:
                        vm = new NASViewModel();
                        break;
                    case SubsystemTypeEnum.RCM:
                        vm = new RCMViewModel();
                        break;
                    case SubsystemTypeEnum.RCS:
                        vm = new RCSViewModel();
                        break;
                    case SubsystemTypeEnum.RMS:
                        vm = new RMSViewModel();
                        break;
                    case SubsystemTypeEnum.TMS:
                        vm = new TMSViewModel();
                        break;
                    case SubsystemTypeEnum.VMS:
                        vm = new VMSViewModel();
                        break;
                    default:
                        vm = new SubsystemViewModel();
                        break;
                }
                if (vm != null)
                {
                    vm.LoadFrom(subsystem);
                    Subsystems.Add(vm);
                }
            }
        }

        public bool IsViewModelOf(SubsystemsManager model)
        {
            return model.Equals(_subsystems);
        }

    }
}
