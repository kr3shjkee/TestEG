using AbstractClasses;
using UnityEngine;
using Zenject;

namespace Game
{
    [AddComponentMenu("Game/BasePart/StartPart")]
    public class StartPart : BasePart
    {


        [Inject]
        public void Construct(PartPosition position)
        {
            this.gameObject.transform.position = position.LocalPosition;
        }
    }
}

