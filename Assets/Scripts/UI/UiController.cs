using AbstractClasses;
using Common;
using Signals;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class UiController : MonoBehaviour
{
    private BasePanel[] _panels;
    private SignalBus _signalBus;
    private SaveSystem _saveSystem;
    private bool _isStart;

    [Inject]
    public void Construct(SignalBus signalBus, SaveSystem saveSystem)
    {
        _signalBus = signalBus;
        _saveSystem = saveSystem;
    }

    private void Awake()
    {
        _panels = GetComponentsInChildren<BasePanel>(true);

        SubscribeSignals();
    }

    private void OnDestroy()
    {
        UnsubscribeSignals();
    }

    private void SubscribeSignals()
    {
        _signalBus.Subscribe<OpenPanelSignal>(OpenPanel);
        _signalBus.Subscribe<ClosePanelSignal>(ClosePanel);
    }

    private void UnsubscribeSignals()
    {
        _signalBus.Unsubscribe<OpenPanelSignal>(OpenPanel);
        _signalBus.Unsubscribe<ClosePanelSignal>(ClosePanel);
    }

    private async void OpenPanel(OpenPanelSignal signal)
    {
        var panel = _panels.FirstOrDefault(panel => panel.CurrentPanel == signal.Panel);

        if(signal.Panel == Enums.PanelsEnum.Option)
        {
            _signalBus.Fire<PauseSignal>();
        }
        else if(signal.Panel == Enums.PanelsEnum.Lose)
        {
            if(signal.IsNewBest)
            {
                panel.BestScore(signal.BestScore);
            }
            else
            {
                panel.CurrentScore(signal.CurrentScore, signal.BestScore);
            }
        }
        panel.gameObject.SetActive(true);
        await panel.OnActive();
    }

    private async void ClosePanel(ClosePanelSignal signal)
    {
        var panel = _panels.FirstOrDefault(panel => panel.CurrentPanel == signal.Panel);

        if(signal.Panel == Enums.PanelsEnum.Option)
            _signalBus.Fire(new UnpauseSignal(_isStart));

        await panel.OnUnactive();
        panel.gameObject.SetActive(false);
    }

    public void CheckGame(bool isStart)
    {
        _isStart = isStart;
    }
}
