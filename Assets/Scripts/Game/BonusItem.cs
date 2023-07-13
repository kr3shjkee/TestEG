using ScriptableObjects;
using UnityEngine;

namespace Game
{
    public class BonusItem : MonoBehaviour
    {
        private SpriteRenderer spr;
        private string name;
        private int score;

        public SpriteRenderer Spr => spr;
        public string Name => name;
        public int Score => score;

        public void Init(ItemConfig config)
        {
            spr.sprite = config.Spr;
            name = config.Name;
            score = config.Score;
        }
    }
}

