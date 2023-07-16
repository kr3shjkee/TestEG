using UnityEngine;
using Zenject;

namespace AbstractClasses
{
    abstract public class BasePart : MonoBehaviour
    {
        [SerializeField] protected float partHeidth;

        protected SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public float PartHeidth => partHeidth;

        public virtual void Init()
        {

        }

        public virtual void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}

