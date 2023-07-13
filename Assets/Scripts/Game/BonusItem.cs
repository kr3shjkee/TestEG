using ScriptableObjects;
using UnityEngine;

namespace Game
{
    public class BonusItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spr;
        private string _name;
        private int _score;

        public SpriteRenderer Spr => spr;
        public string Name => _name;
        public int Score => _score;

        public void Init(ItemConfig config)
        {
            spr.sprite = config.Spr;
            _name = config.Name;
            _score = config.Score;
        }
    }
}

