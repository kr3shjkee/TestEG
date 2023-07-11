using AbstractClasses;
using Enums;
using Signals;
using UnityEngine;

namespace Ui.Buttons
{
    [AddComponentMenu("Ui/Buttons/BaseButtonController/OpenPanelButton")]
    public class OpenPanelButton : BaseButtonController
    {
        [SerializeField] private PanelsEnum panel;
        protected override void OnClick()
        {
            _signalBus.Fire(new OpenPanelSignal(panel));
        }
    }
}

