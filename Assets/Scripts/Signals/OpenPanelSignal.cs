using Enums;

namespace Signals
{
    public class OpenPanelSignal
    {
        private PanelsEnum _panel;
        private int _currentScore;
        private int _bestScore;
        private bool _isNewBest;

        public PanelsEnum Panel => _panel;
        public int CurrentScore => _currentScore;
        public int BestScore => _bestScore;
        public bool IsNewBest => _isNewBest;

        public OpenPanelSignal(PanelsEnum panel)
        {
            _panel = panel;
        }

        public OpenPanelSignal(PanelsEnum panel, int currentScore, int bestScore, bool isNewBest)
        {
            _panel = panel;
            _currentScore = currentScore;
            _bestScore = bestScore;
            _isNewBest = isNewBest;
        }
    }
}

