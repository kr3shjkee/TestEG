using UnityEngine;

namespace AbstractClasses
{
    abstract public class BasePart : MonoBehaviour
    {
        [SerializeField] protected float partHeidth;

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

