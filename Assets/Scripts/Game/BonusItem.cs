using DG.Tweening;
using ScriptableObjects;
using UnityEngine;

namespace Game
{
    public class BonusItem : MonoBehaviour
    {
        private const float SCALE_TIME = 0.5f;

        [SerializeField] private SpriteRenderer spr;
        private string _name;
        private int _score;
        private bool _isActive = true;
        public bool IsActive => _isActive;

        public SpriteRenderer Spr => spr;
        public string Name => _name;
        public int Score => _score;

        public void Init(ItemConfig config)
        {
            spr.sprite = config.Spr;
            _name = config.Name;
            _score = config.Score;
        }

        public void DestroySelf()
        {
            _isActive = false;
            gameObject.transform.DOScale(Vector3.zero, SCALE_TIME);
        }
    }
}

