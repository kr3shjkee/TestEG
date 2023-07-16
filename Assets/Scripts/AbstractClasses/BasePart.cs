using UnityEngine;
using Zenject;

namespace AbstractClasses
{
    public abstract class BasePart : MonoBehaviour
    {
        [SerializeField] protected float partHeidth;

        protected SignalBus _signalBus;
        public float PartHeidth => partHeidth;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        } 

        public virtual void Init()
        {

        }

        public virtual void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}

