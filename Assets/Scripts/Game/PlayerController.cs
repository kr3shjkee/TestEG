using ScriptableObjects;
using Signals;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {

        private float _upPower;
        private bool _isPause;
        private Rigidbody2D _body;
        private SignalBus _signalBus;
        private LevelConfig _config;
        private Animator _animator;

        [Inject]
        public void Construct(LevelConfig config, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _config = config;
        }
        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _upPower = _config.UpPower;
            _isPause = true;
        }

        private void Start()
        {
            _signalBus.Subscribe<PauseSignal>(Pause);
            _signalBus.Subscribe<UnpauseSignal>(Unpause);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<PauseSignal>(Pause);
            _signalBus.Unsubscribe<UnpauseSignal>(Unpause);
        }
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    _body.AddForce(Vector2.up * _upPower, ForceMode2D.Impulse);
                }
            }

            if (Input.GetMouseButtonDown(0) && !_isPause)
            {
                _body.AddForce(Vector2.up * _upPower, ForceMode2D.Impulse);
            }
        }

        public void IsGravity(bool isGravity)
        {
            _body.simulated = isGravity;
        }

        public void IsPause(bool isPause)
        {
            _isPause = isPause;
            _animator.enabled = !isPause;
        }

        private void Pause()
        {
            _body.simulated = false;
            _isPause = true;
            _animator.enabled = false;
            //_animator.speed = 0;
        }

        private void Unpause()
        {
            _body.simulated = true;
            _isPause = false;
            _animator.enabled = true;
            //_animator.speed = 1;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.GetComponent<FinishElement>())
            {
                _signalBus.Fire<FinishTriggerSignal>();
            }
            else if(collision.gameObject.GetComponent<BonusItem>())
            {
                var item = collision.gameObject.GetComponent<BonusItem>();
                if(item.IsActive)
                {
                    _signalBus.Fire(new ScoreChangedSignal(item.Score, item.Spr.sprite, item.Name));
                    item.DestroySelf();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<DamageElement>())
            {
                _signalBus.Fire<LoseGameSignal>();
            }
        }
    }
}

