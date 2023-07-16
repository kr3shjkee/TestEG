using AbstractClasses;
using Cysharp.Threading.Tasks;
using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/OptionPanel")]
    public class OptionPanel : BasePanel
    {
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Toggle soundToggle;
        public override async UniTask OnActive()
        {
            _saveSystem.LoadData();
            musicToggle.isOn = _saveSystem.Data.IsMusic;
            soundToggle.isOn = _saveSystem.Data.IsSound;

            _signalBus.Fire<PauseSignal>();
        }

        public override async UniTask OnUnactive()
        {
            
        }

        public void CheckboxChanged()
        {
            _saveSystem.Data.IsMusic = musicToggle.isOn;
            _saveSystem.Data.IsSound = soundToggle.isOn;
            _saveSystem.SaveData();

            _signalBus.Fire<OptionChangedSignal>();
        }
    }
}

