
namespace Signals
{
    public class UnpauseSignal
    {
        private bool _isStart;
        public bool IsStart => _isStart;
        public UnpauseSignal(bool isStart)
        {
            _isStart = isStart;
        }
    }
}

