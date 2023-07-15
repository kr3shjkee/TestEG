using AbstractClasses;
using Cysharp.Threading.Tasks;
using Signals;
using TMPro;
using UnityEngine;

namespace Ui.Panels
{
    [AddComponentMenu("Ui/Panels/BasePanel/MainPanel")]
    public class MainPanel : BasePanel
    {
        private const string BEST_SCORE = "BEST SCORE: ";

        [SerializeField] private TextMeshProUGUI bestScoreText;
        public override async UniTask OnActive()
        {
            BestScore();
        }

        public override async UniTask OnUnactive()
        {
            _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Game));
        }

        private void BestScore()
        {
            _saveSystem.LoadData();
            bestScoreText.text = BEST_SCORE + _saveSystem.Data.BestScore.ToString();
        }
    }
}

