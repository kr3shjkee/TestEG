using AbstractClasses;
using Cysharp.Threading.Tasks;
using Signals;
using UnityEngine;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/OptionPanel")]
    public class OptionPanel : BasePanel
    {
        public override async UniTask OnActive()
        {
            _signalBus.Fire<PauseSignal>();
        }

        public override async UniTask OnUnactive()
        {
            _signalBus.Fire<UnpauseSignal>();
        }
    }
}

