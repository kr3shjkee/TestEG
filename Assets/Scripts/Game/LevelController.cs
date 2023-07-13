using AbstractClasses;
using ScriptableObjects;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using Zenject;
using UnityEngine;

namespace Game
{
    public class LevelController : MonoBehaviour
    {
        private bool _isPause;

        private SignalBus _signalBus;
        private LevelConfig _levelConfig;
        private LevelPart.Factory _factory;
        private List<BasePart> _levelParts;

        [Inject]
        public void Construct(SignalBus signalBus, LevelConfig levelConfig, LevelPart.Factory factory)
        {
            _signalBus = signalBus;
            _levelConfig = levelConfig;
            _factory = factory;
        }

        public void InitLevel()
        {
            _levelParts = new List<BasePart>(_levelConfig.PartsForInit);
            for(int i=0; i< _levelConfig.PartsForInit; i++)
            {
                if (i == 0)
                {
                    _levelParts.Add(_levelConfig.StartPart);
                    Instantiate(_levelParts[0]);
                }
                else
                {
                    _levelParts.Add(CreateLevelPart());
                    _levelParts[i].gameObject.transform.position = _levelParts[i - 1].gameObject.transform.position + new Vector3(_levelParts[i - 1].PartHeidth, 0f, 0f);
                    _levelParts[i].Init();
                }
            }
        }

        public void InitPlayer()
        {

        }

        public void StartGame()
        {

        }

        public void PauseGame()
        {

        }

        public void ClearLevel()
        {

        }

        private BasePart CreateLevelPart()
        {
            BasePart part = _factory.Create(
                new DamagePosition(new Vector2(0f, Random.Range(_levelConfig.DamagePosMinY, _levelConfig.DamagePosMaxY))),
                new BonusItemPosition(_levelConfig.BonusPositions[Random.Range(0, _levelConfig.BonusPositions.Length)]));
            return part;
        }
    }
}

