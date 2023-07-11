using Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AbstractClasses
{
    public abstract class BaseButtonController : MonoBehaviour
    {
        protected SignalBus _signalBus;
        protected SaveSystem _saveSystem;
        protected Button _button;

        [Inject]
        public void Construct(SignalBus signalBus, SaveSystem saveSystem)
        {
            _signalBus = signalBus;
            _saveSystem = saveSystem;
        }

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected virtual void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected virtual void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected abstract void OnClick();
    }
}

