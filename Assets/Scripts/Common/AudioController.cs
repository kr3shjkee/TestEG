using Signals;
using UnityEngine;
using Zenject;

namespace Common
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private GameObject music;
        [SerializeField] private GameObject sound;

        [SerializeField] private AudioSource damage;
        [SerializeField] private AudioSource fly;
        [SerializeField] private AudioSource collect;

        private SaveSystem _saveSystem;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SaveSystem saveSystem, SignalBus signalBus)
        {
            _saveSystem = saveSystem;
            _signalBus = signalBus;
        }

        private void Start()
        {
            _signalBus.Subscribe<OptionChangedSignal>(CheckSave);
            CheckSave();
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<OptionChangedSignal>(CheckSave);
        }

        private void CheckSave()
        {
            if (_saveSystem.CheckOnNewProfile())
                return;

            _saveSystem.LoadData();
            if (_saveSystem.Data.IsSound)
                sound.SetActive(true);
            else
                sound.SetActive(false);

            if (_saveSystem.Data.IsMusic)
                music.SetActive(true);
            else
                music.SetActive(false);
        }

        
    }
}

