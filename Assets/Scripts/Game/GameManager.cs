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
        private UiController _uiController;
        private int _score;
        private bool _isStart = false;

        public GameManager(SignalBus signaslBus, SaveSystem saveSystem, LevelController levelController, UiController uiController)
        {
            _signalBus = signaslBus;
            _saveSystem = saveSystem;
            _levelController = levelController;
            _uiController = uiController;
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
            if(_levelController.LevelParts != null)
            {
                _levelController.ClearLevel();
            }
            _uiController.CheckGame(_isStart);
            _levelController.InitLevel();
            _levelController.InitPlayer();
            _levelController.StartGame();
            _score = 0;
            _isStart = true;
            
        }

        private void PauseGame()
        {
            _levelController.PauseGame();
        }

        private void UnpauseGame(UnpauseSignal signal)
        {
            if (!_isStart)
                return;
            _levelController.StartGame();
        }

        private void LoseGame()
        {
            CheckScore();
            _saveSystem.SaveData();
            _levelController.PauseGame();
            _isStart = false;
            _uiController.CheckGame(_isStart);
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

