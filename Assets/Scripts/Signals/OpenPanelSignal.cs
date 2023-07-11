using Enums;

namespace Signals
{
    public class OpenPanelSignal
    {
        private PanelsEnum _panel;

        public PanelsEnum Panel => _panel;

        public OpenPanelSignal(PanelsEnum panel)
        {
            _panel = panel;
        }
    }
}

