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
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PauseSignal>(PauseGame);
            _signalBus.Unsubscribe<UnpauseSignal>(UnpauseGame);
            _signalBus.Unsubscribe<StartGameSignal>(StartGame);
            _signalBus.Unsubscribe<LoseGameSignal>(LoseGame);
        }

        private void CheckPlayerPrefs()
        {
            if (_saveSystem.CheckOnNewProfile())
                _saveSystem.CreateNewData();
            else
                _saveSystem.LoadData();
        }

        private async void StartGame()
        {
            _levelController.InitLevel();
        }

        private void PauseGame()
        {

        }

        private void UnpauseGame()
        {

        }

        private void LoseGame()
        {
            _saveSystem.SaveData();
            _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Lose));
        }
    }
}

