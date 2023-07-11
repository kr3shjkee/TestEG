using AbstractClasses;
using Enums;
using Signals;
using UnityEngine;

namespace Ui.Buttons
{
    [AddComponentMenu("Ui/Buttons/BaseButtonController/ClosePanelButton")]
    public class ClosePanelButton : BaseButtonController
    {
        [SerializeField] private PanelsEnum panel;
        protected override void OnClick()
        {
            _signalBus.Fire(new ClosePanelSignal(panel));
        }
    }
}

