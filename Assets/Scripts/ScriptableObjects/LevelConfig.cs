using AbstractClasses;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private BasePart startPart;
        [SerializeField] private BasePart levelPart;
        [SerializeField] private int partsForInit;

        [SerializeField] private GameObject player;
        [SerializeField] private float upPower;

        [SerializeField] private float levelSpeed;
        [SerializeField] private float speedMultiplier;
        [SerializeField] private int partsForSpeedUp;

        [SerializeField] private float damagePosMinY;
        [SerializeField] private float damagePosMaxY;

        [SerializeField] private Vector2[] bonusPositions;

        public BasePart StartPart => startPart;
        public BasePart LevelPart => levelPart;
        public int PartsForInit => partsForInit;

        public GameObject Player => player;
        public float UpPower => upPower;

        public float LevelSpeed => levelSpeed;
        public float SpeedMultiplier => speedMultiplier;
        public int PartsForSpeedUp => partsForSpeedUp;

        public float DamagePosMinY => damagePosMinY;
        public float DamagePosMaxY => damagePosMaxY;

        public Vector2[] BonusPositions => bonusPositions;

    }
}

