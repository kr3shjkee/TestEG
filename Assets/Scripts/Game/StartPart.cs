using AbstractClasses;
using UnityEngine;

namespace Game
{
    public class StartPart : BasePart
    {
        private bool _isPause = false;
        public bool _isStart = false;

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

        public void Pause()
        {
            _isPause = true;
        }

        public void Unpause()
        {
            _isPause = false;
        }
    }
}

