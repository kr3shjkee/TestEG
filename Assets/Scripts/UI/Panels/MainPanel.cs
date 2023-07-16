using AbstractClasses;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Signals;
using TMPro;
using UnityEngine;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/MainPanel")]
    public class MainPanel : BasePanel
    {
        private const string BEST_SCORE = "BEST SCORE: ";

        private const float HIDE_TITTLE_POS_Y = 1100f;
        private const float SHOW_TITTLE_POS_Y = 200f;

        private const float HIDE_POPUP_POS_Y = -1400f;
        private const float SHOW_POPUP_POS_Y = -300f;

        private const float TIME = 1.5f;

        [SerializeField] private TextMeshProUGUI bestScoreText;

        [SerializeField] private GameObject tittle;
        [SerializeField] private GameObject popup;
        public override async UniTask OnActive()
        {
            BestScore();
            await OpenPanelAnimation();
        }

        public override async UniTask OnUnactive()
        {
            await ClosePanelAnimation();
            _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Game));
        }

        private void BestScore()
        {
            _saveSystem.LoadData();
            bestScoreText.text = BEST_SCORE + _saveSystem.Data.BestScore.ToString();
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

