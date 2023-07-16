using Enums;

namespace Signals
{
    public class PushSoundSignal 
    {
        private SoundsEnum _sound;
        public SoundsEnum Sound => _sound;
        public PushSoundSignal(SoundsEnum sound)
        {
            _sound = sound;
        }
    }
}

