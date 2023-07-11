using AbstractClasses;
using Cysharp.Threading.Tasks;
using Signals;
using UnityEngine;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/GamePanel")]
    public class GamePanel : BasePanel
    {
        public override async UniTask OnActive()
        {
            _signalBus.Fire<StartGameSignal>();
        }

        public override async UniTask OnUnactive()
        {
            _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Main));
        }
    }
}

