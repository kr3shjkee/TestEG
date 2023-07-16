using AbstractClasses;
using Cysharp.Threading.Tasks;
using DG.Tweening;
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

        private const float HIDE_TITTLE_POS_Y = 1100f;
        private const float SHOW_TITTLE_POS_Y = 450f;

        private const float HIDE_POPUP_POS_Y = -1400f;
        private const float SHOW_POPUP_POS_Y = 0f;

        private const float TIME = 1.5f;

        [SerializeField] private TextMeshProUGUI newBestText;
        [SerializeField] private TextMeshProUGUI currentText;
        [SerializeField] private TextMeshProUGUI bestText;

        [SerializeField] private GameObject tittle;
        [SerializeField] private GameObject popup;

        public override async UniTask OnActive()
        {
            await OpenPanelAnimation();
        }

        public override async UniTask OnUnactive()
        {
            await ClosePanelAnimation();
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

        private async UniTask OpenPanelAnimation()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Join(tittle.transform.DOLocalMove(new Vector3(0, SHOW_TITTLE_POS_Y, 0), TIME)).
                Join(popup.transform.DOLocalMove(new Vector2(0f, SHOW_POPUP_POS_Y), TIME));
        }

        private async UniTask ClosePanelAnimation()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Join(tittle.transform.DOLocalMove(new Vector3(0, HIDE_TITTLE_POS_Y, 0), TIME)).
                Join(popup.transform.DOLocalMove(new Vector3(0f, HIDE_POPUP_POS_Y), TIME));
        }
    }
}

