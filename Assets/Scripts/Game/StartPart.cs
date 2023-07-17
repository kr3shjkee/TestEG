using AbstractClasses;
using Zenject;

namespace Game
{
    public class StartPart : BasePart
    {


        [Inject]
        public void Construct(PartPosition position)
        {
            this.gameObject.transform.position = position.LocalPosition;
        }
    }
}

