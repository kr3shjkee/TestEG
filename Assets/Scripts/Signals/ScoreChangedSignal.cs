using UnityEngine;

namespace Signals
{
    public class ScoreChangedSignal
    {
        public readonly int Score;
        public readonly Sprite Spr;
        public readonly string Name;

        public ScoreChangedSignal(int score, Sprite spr, string name)
        {
            Score = score;
            Spr = spr;
            Name = name;
        }
    }
}

