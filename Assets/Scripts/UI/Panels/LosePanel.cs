using AbstractClasses;
using Cysharp.Threading.Tasks;
using Signals;
using TMPro;
using UnityEngine;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/LosePanel")]
    public class LosePanel : BasePanel
    {
        private const string NEW_BEST_SCORE = "NEW BEST SCORE: ";
        private const string CURRENT_SCORE = "CURRENT SCORE: ";
        private const string BEST_SCORE = "BEST SCORE: ";

        [SerializeField] private TextMeshProUGUI newBestText;
        [SerializeField] private TextMeshProUGUI currentText;
        [SerializeField] private TextMeshProUGUI bestText;

        public override async UniTask OnActive()
        {
            
        }

        public override async UniTask OnUnactive()
        {
            CloseScoreInfo();
            _signalBus.Fire(new ClosePanelSignal(Enums.PanelsEnum.Game));
        }

        public override void BestScore(int bestScore)
        {
            newBestText.gameObject.SetActive(true);
            newBestText.text = NEW_BEST_SCORE + bestScore.ToString();
        }

        public override void CurrentScore(int currentScore, int bestScore)
        {
            currentText.gameObject.SetActive(true);
            currentText.text = CURRENT_SCORE + currentScore.ToString();

            bestText.gameObject.SetActive(true);
            bestText.text = BEST_SCORE + bestScore.ToString();
        }

        private void CloseScoreInfo()
        {
            newBestText.gameObject.SetActive(false);
            currentText.gameObject.SetActive(false);
            bestText.gameObject.SetActive(false);
        }
    }
}

