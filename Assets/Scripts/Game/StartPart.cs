using AbstractClasses;
using Signals;
using UnityEngine;

namespace Game
{
    public class StartPart : BasePart
    {
        private bool _isPause = false;
        public bool _isStart = false;

        private void Start()
        {
            _signalBus.Subscribe<PauseSignal>(Pause);
            _signalBus.Subscribe<UnpauseSignal>(Unpause);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<PauseSignal>(Pause);
            _signalBus.Unsubscribe<UnpauseSignal>(Unpause);
        }
        public override void Init()
        {
            base.Init();
            _isStart = true;
        }

        private void FixedUpdate()
        {
            if(_isStart && !_isPause)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(-partHeidth, 0), Time.fixedDeltaTime * 1.2f);
            }           
        }

        private void Pause()
        {
            _isPause = true;
        }

        private void Unpause()
        {
            _isPause = false;
        }
    }
}

