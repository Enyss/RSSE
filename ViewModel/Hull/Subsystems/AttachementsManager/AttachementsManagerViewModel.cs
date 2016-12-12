using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace RSSE
{
    class AttachementsManagerViewModel : SubsystemViewModel
    {
        private AttachementsManager _manager;

        new public AttachementsManager Model { get { return _manager; } }
        override public SubsystemTypeEnum SystemType { get { return _manager.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_manager.SystemType); }
        }
        public string Group { get { return _manager.SystemGroup; } }
        public ObservableCollection<AttachementViewModel> Attachements { get; set; }


        public ICommand AddAttachementCommand { get; private set; }
        public ICommand RemoveAttachementCommand { get; private set; }


        public AttachementsManagerViewModel()
            : this(null)
        {
        }

        public AttachementsManagerViewModel(AttachementsManager attachementsManager)
        {
            AddAttachementCommand = new DelegateCommand(AddAttachement);
            RemoveAttachementCommand = new DelegateCommand<AttachementViewModel>(RemoveAttachement);

            if (attachementsManager != null)
            {
                LoadFrom(attachementsManager);
            }

        }

        override public void LoadFrom(Subsystem attachementsManager)
        {
            _manager = (AttachementsManager)attachementsManager;

            Attachements = new ObservableCollection<AttachementViewModel>();
            foreach (Attachement attachement in _manager.attachements)
            {
                Attachements.Add(new AttachementViewModel(attachement));
            }
            
        }

        public bool IsViewModelOf(AttachementsManager manager)
        {
            return manager == _manager;
        }

        public void AddAttachement()
        {
            Attachement attachement = new Attachement();
            attachement.name = "default";
            AttachementViewModel vm = new AttachementViewModel(attachement);
            Attachements.Add(vm);
            _manager.attachements.Add(attachement);
        }

        public void RemoveAttachement(AttachementViewModel attachement)
        {
            Attachements.Remove(attachement);
            _manager.attachements.Remove(attachement.Model);
        }
    }
}

