using AbstractClasses;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game
{
    [AddComponentMenu("Game/BasePart/LevelPart")]
    public class LevelPart : BasePart
    {



        [SerializeField] private GameObject damageElement;
        [SerializeField] private BonusItem bonusItem;

        private DamagePosition _damageLocalPos;
        private BonusItemPosition _bonusItemLocalPos;

        private BonusItemsConfig _bonusItemsConfig;


        [Inject]
        public void Construct(DamagePosition damagePosition, BonusItemPosition bonusItemPosition, BonusItemsConfig bonusItemsConfig, PartPosition position)
        {
            _damageLocalPos = damagePosition;
            _bonusItemLocalPos = bonusItemPosition;
            _bonusItemsConfig = bonusItemsConfig;
            this.gameObject.transform.position = position.LocalPosition;
        }

        public override void Init()
        {
            damageElement.transform.localPosition = _damageLocalPos.LocalPosition;
            bonusItem.transform.localPosition = _bonusItemLocalPos.LocalPosition;
            ItemConfig itemCfg = _bonusItemsConfig.Items[Random.Range(0, _bonusItemsConfig.Items.Length)];
            bonusItem.Init(itemCfg);
        }
    }
}

