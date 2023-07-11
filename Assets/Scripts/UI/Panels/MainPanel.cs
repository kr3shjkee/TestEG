using AbstractClasses;
using Cysharp.Threading.Tasks;
using Signals;
using UnityEngine;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/MainPanel")]
    public class MainPanel : BasePanel
    {
        public override async UniTask OnActive()
        {
           
        }

        public override async UniTask OnUnactive()
        {
            _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Game));
        }
    }
}

