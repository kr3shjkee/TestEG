using AbstractClasses;
using ScriptableObjects;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using Signals;

namespace Game
{
    public class LevelController : MonoBehaviour
    {
        private bool _isPause = true;

        private SignalBus _signalBus;
        private LevelConfig _levelConfig;
        private LevelPart.Factory _factory;
        private List<BasePart> _levelParts;
        private PlayerController _player;

        [Inject]
        public void Construct(SignalBus signalBus, LevelConfig levelConfig, LevelPart.Factory factory, PlayerController player)
        {
            _signalBus = signalBus;
            _levelConfig = levelConfig;
            _factory = factory;
            _player = player;
        }

        private void Start()
        {
            _signalBus.Subscribe<FinishTriggerSignal>(CreateNewPart);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<FinishTriggerSignal>(CreateNewPart);
        }

        public void InitLevel()
        {
            _levelParts = new List<BasePart>();
            for(int i=0; i< _levelConfig.PartsForInit; i++)
            {
                if (i == 0)
                {
                    _levelParts.Add(_levelConfig.StartPart);
                    _levelParts[0].gameObject.transform.position = Vector3.zero;
                    Instantiate(_levelParts[0]);
                    
                }
                else
                {
                    _levelParts.Add(CreateLevelPart(_levelParts[i - 1].gameObject.transform.position + new Vector3(_levelParts[i - 1].PartHeidth,0,0)));
                }
            }
        }

        public void InitPlayer()
        {
            _player.gameObject.transform.position = Vector2.zero;
            _player.IsGravity(true);
            _player.IsPause(false);
        }

        public void StartGame()
        {
            _isPause = false;
        }

        public void PauseGame()
        {
            _isPause = true;
        }

        public void ClearLevel()
        {

        }

        private BasePart CreateLevelPart(Vector2 pos)
        {
            BasePart part = _factory.Create(
                new DamagePosition(new Vector2(0f, Random.Range(_levelConfig.DamagePosMinY, _levelConfig.DamagePosMaxY))),
                new BonusItemPosition(_levelConfig.BonusPositions[Random.Range(0, _levelConfig.BonusPositions.Length)]),
                new PartPosition(pos));
            part.Init();
            return part;
        }

        private void CreateNewPart()
        {
            _levelParts.Add(CreateLevelPart(_levelParts[_levelParts.Count - 1].gameObject.transform.position + new Vector3(_levelParts[_levelParts.Count - 1].PartHeidth,0,0)));
            var partForLose = _levelParts[0];
            _levelParts.Remove(_levelParts[0]);
            partForLose.DestroySelf();
        }

        private void FixedUpdate()
        {
            if(!_isPause)
            {
                for(int i = 0; i<_levelParts.Count;i++)
                {
                    _levelParts[i].gameObject.transform.position = Vector3.MoveTowards(_levelParts[i].transform.position, 
                        new Vector3(-_levelParts[i].PartHeidth, 0), Time.fixedDeltaTime * _levelConfig.LevelSpeed);         
                }
            }
        }
    }
}

