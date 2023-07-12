using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BonusItemsConfig", menuName = "Configs/BonusItemsConfig", order = 0)]
    public class BonusItemsConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig[] items;

        public ItemConfig[] Items => items;
    }

    [Serializable]
    public class ItemConfig
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite spr;
        [SerializeField] private int score;

        public string Name => name;
        public Sprite Spr => spr;
        public int Score => score;
    }
}

