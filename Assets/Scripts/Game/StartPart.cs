using AbstractClasses;
using Zenject;

namespace Game
{
    public class StartPart : BasePart
    {
        public class Factory : PlaceholderFactory<PartPosition, StartPart>
        {

        }

        [Inject]
        public void Construct(PartPosition position)
        {
            this.gameObject.transform.position = position.LocalPosition;
        }
    }
}

