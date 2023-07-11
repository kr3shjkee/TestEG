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
            CheckPlayerPrefs();
        }
        public void Dispose()
        {
            
        }

        private void CheckPlayerPrefs()
        {
            if (_saveSystem.CheckOnNewProfile())
                _saveSystem.CreateNewData();
            else
                _saveSystem.LoadData();
        }
    }
}

