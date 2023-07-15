using Common;
using Cysharp.Threading.Tasks;
using Signals;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameManager : IInitializable, IDisposable
    {
        private SignalBus _signalBus;
        private SaveSystem _saveSystem;
        private LevelController _levelController;
        private int _score;

        public GameManager(SignalBus signaslBus, SaveSystem saveSystem, LevelController levelController)
        {
            _signalBus = signaslBus;
            _saveSystem = saveSystem;
            _levelController = levelController;
        }
        public void Initialize()
        {
            SubscribeSignals();

            CheckPlayerPrefs();
            _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Main));
        }
        public void Dispose()
        {
            UnsubscribeSignals();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<PauseSignal>(PauseGame);
            _signalBus.Subscribe<UnpauseSignal>(UnpauseGame);
            _signalBus.Subscribe<StartGameSignal>(StartGame);
            _signalBus.Subscribe<LoseGameSignal>(LoseGame);
            _signalBus.Subscribe<ScoreChangedSignal>(ChangeScore);
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PauseSignal>(PauseGame);
            _signalBus.Unsubscribe<UnpauseSignal>(UnpauseGame);
            _signalBus.Unsubscribe<StartGameSignal>(StartGame);
            _signalBus.Unsubscribe<LoseGameSignal>(LoseGame);
            _signalBus.Unsubscribe<ScoreChangedSignal>(ChangeScore);
        }

        private void CheckPlayerPrefs()
        {
            if (_saveSystem.CheckOnNewProfile())
                _saveSystem.CreateNewData();
            else
                _saveSystem.LoadData();
        }

        private void StartGame()
        {
            _levelController.InitLevel();
            _levelController.InitPlayer();
            _levelController.StartGame();
            _score = 0;
        }

        private void PauseGame()
        {
            _levelController.PauseGame();
        }

        private void UnpauseGame()
        {
            _levelController.StartGame();
        }

        private void LoseGame()
        {
            CheckScore();
            _saveSystem.SaveData();
            _levelController.PauseGame();
            
        }

        private void ChangeScore(ScoreChangedSignal signal)
        {
            _score += signal.Score;
        }

        private void CheckScore()
        {
            if(_saveSystem.Data.BestScore>= _score)
            {
                _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Lose, _score, _saveSystem.Data.BestScore, false));
            }
            else
            {
                _saveSystem.Data.BestScore = _score;
                _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Lose, _score, _saveSystem.Data.BestScore, true));
            }
        }
    }
}

