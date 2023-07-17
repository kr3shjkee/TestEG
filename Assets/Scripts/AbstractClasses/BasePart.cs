using Game;
using UnityEngine;
using Zenject;

namespace AbstractClasses
{
    public abstract class BasePart : MonoBehaviour
    {
        public class StartPartFactory : PlaceholderFactory<PartPosition, BasePart>
        {

        }

        public class LevelPartFactory : PlaceholderFactory<DamagePosition, BonusItemPosition, PartPosition, BasePart>
        {

        }

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

