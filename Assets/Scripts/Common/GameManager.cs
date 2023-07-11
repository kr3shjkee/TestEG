using Cysharp.Threading.Tasks;
using Signals;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public class GameManager : IInitializable, IDisposable
    {
        private SignalBus _signalBus;
        private SaveSystem _saveSystem;

        public GameManager(SignalBus signaslBus, SaveSystem saveSystem)
        {
            _signalBus = signaslBus;
            _saveSystem = saveSystem;
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
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PauseSignal>(PauseGame);
            _signalBus.Unsubscribe<UnpauseSignal>(UnpauseGame);
            _signalBus.Unsubscribe<StartGameSignal>(StartGame);
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
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            LoseGame();
        }

        private void PauseGame()
        {

        }

        private void UnpauseGame()
        {

        }

        private void LoseGame()
        {
            _signalBus.Fire(new OpenPanelSignal(Enums.PanelsEnum.Lose));
        }
    }
}

