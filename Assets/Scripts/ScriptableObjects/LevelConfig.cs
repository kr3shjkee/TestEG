using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private GameObject startPart;
        [SerializeField] private GameObject levelPart;
        [SerializeField] private float partsForInit;

        [SerializeField] private GameObject player;
        [SerializeField] private float upPower;

        [SerializeField] private float levelSpeed;
        [SerializeField] private float speedMultiplier;
        [SerializeField] private int partsForSpeedUp;

        public GameObject StartPart => startPart;
        public GameObject LevelPart => levelPart;
        public float PartsForInit => partsForInit;

        public GameObject Player => player;
        public float UpPower => upPower;

        public float LevelSpeed => levelSpeed;
        public float SpeedMultiplier => speedMultiplier;
        public int PartsForSpeedUp => partsForSpeedUp;

    }
}

