using Common;
using Cysharp.Threading.Tasks;
using Enums;
using UnityEngine;
using Zenject;

namespace AbstractClasses
{
    public abstract class BasePanel : MonoBehaviour
    {
        [SerializeField] protected PanelsEnum currentPanel;

        protected SignalBus _signalBus;
        protected SaveSystem _saveSystem;
        public PanelsEnum CurrentPanel => currentPanel;

        [Inject]
        public void Construct(SignalBus signalBus, SaveSystem saveSystem)
        {
            _signalBus = signalBus;
            _saveSystem = saveSystem;
        }

        public abstract UniTask OnActive();
        public abstract UniTask OnUnactive();
        public virtual void BestScore(int bestScore)
        {

        }

        public virtual void CurrentScore(int currentScore, int bestScore)
        {

        }
    }
}

