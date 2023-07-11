using AbstractClasses;
using Cysharp.Threading.Tasks;
using Signals;
using UnityEngine;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/LosePanel")]
    public class LosePanel : BasePanel
    {
        public override async UniTask OnActive()
        {
            
        }

        public override async UniTask OnUnactive()
        {
            _signalBus.Fire(new ClosePanelSignal(Enums.PanelsEnum.Game));
        }
    }
}

