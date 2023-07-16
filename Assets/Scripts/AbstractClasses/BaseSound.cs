using Enums;
using Signals;
using UnityEngine;
using Zenject;

public abstract class BaseSound : MonoBehaviour
{
    [SerializeField] protected SoundsEnum _currentSound;

    protected AudioSource _sound;
    protected SignalBus _signalBus;

    public SoundsEnum CurrentSound => _currentSound;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _signalBus.Subscribe<PushSoundSignal>(PlaySound);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<PushSoundSignal>(PlaySound);
    }
    public void PlaySound(PushSoundSignal signal)
    {
        if(_currentSound == signal.Sound)
        {
            _sound.Play();
        }
    }
}
