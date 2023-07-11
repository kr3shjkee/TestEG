using Enums;

namespace Signals
{
    public class ClosePanelSignal
    {
        private PanelsEnum _panel;

        public PanelsEnum Panel => _panel;

        public ClosePanelSignal(PanelsEnum panel)
        {
            _panel = panel;
        }
    }
}

