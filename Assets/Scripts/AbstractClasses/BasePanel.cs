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
        public PanelsEnum CurrentPanel => currentPanel;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public abstract UniTask OnActive();
        public abstract UniTask OnUnactive();

    }
}

