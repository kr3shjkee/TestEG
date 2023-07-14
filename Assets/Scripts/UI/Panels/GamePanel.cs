using AbstractClasses;
using Cysharp.Threading.Tasks;
using Signals;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/GamePanel")]
    public class GamePanel : BasePanel
    {
        private const float TIME_ITEM_INFO = 2f;

        [SerializeField] private TextMeshProUGUI scoreText;

        [SerializeField] private TextMeshProUGUI itemText;
        [SerializeField] private Image itemSpr;
        [SerializeField] private GameObject itemInfoObj;

        private int _score = 0;

        private void Start()
        {
            _signalBus.Subscribe<ScoreChangedSignal>(ShowItemInfo);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ScoreChangedSignal>(ShowItemInfo);
        }
        public override async UniTask OnActive()
        {
            _signalBus.Fire<StartGameSignal>();
        }

        public override async UniTask OnUnactive()
        {
            _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Main));
            _score = 0;
            ChangeScore();
        }

        private void ChangeScore()
        {
            scoreText.text = _score.ToString();
        }

        private async void ShowItemInfo(ScoreChangedSignal signal)
        {
            _score += signal.Score;
            ChangeScore();

            itemInfoObj.SetActive(true);
            itemSpr.sprite = signal.Spr;
            itemText.text = signal.Name;
            Sequence sequence1 = DOTween.Sequence();
            sequence1.Join(itemSpr.DOFade(1, 0.01f)).
                Join(itemText.DOFade(1, 0.01f));
            await sequence1;

            Sequence sequence2 = DOTween.Sequence();
            sequence2.Join(itemSpr.DOFade(0, TIME_ITEM_INFO)).
                Join(itemText.DOFade(0, TIME_ITEM_INFO));
            await sequence2;
            itemInfoObj.SetActive(false);
        }
    }
}

