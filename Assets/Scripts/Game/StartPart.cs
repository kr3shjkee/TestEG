using AbstractClasses;
using Signals;
using UnityEngine;

namespace Game
{
    public class StartPart : BasePart
    {
        public bool _isStart = false;

        public override void Init()
        {
            base.Init();
            _isStart = true;
        }

        private void FixedUpdate()
        {
            if(_isStart)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(-partHeidth, 0), Time.fixedDeltaTime * 1.2f);
            }           
        }

        public override void DestroySelf()
        {
            base.DestroySelf();
        }

    }
}

