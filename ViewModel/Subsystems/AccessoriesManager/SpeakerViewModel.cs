using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RSSE.Interface;

namespace RSSE
{
    class SpeakerViewModel : ObservableObject
    {
        private Speaker _speaker;
        public Speaker Model { get { return _speaker; } }

        public SpeakerViewModel() { }

        public SpeakerViewModel(Speaker speaker)
        {
            LoadFrom(speaker);
        }

        public string Name
        {
            get { return _speaker.Name; }
            set
            {
                _speaker.Name = value;
                OnPropertyChanged();
            }
        }
        public Vector3 Position
        {
            get { return _speaker.Position; }
            set
            {
                _speaker.Position = value;
                OnPropertyChanged();
            }
        }

        public void LoadFrom(Speaker speaker)
        {
            _speaker = speaker;
        }

        public bool IsViewModelOf(Speaker speaker)
        {
            return speaker.Equals(_speaker);
        }
    }
}
