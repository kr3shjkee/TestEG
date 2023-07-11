
namespace Common
{
    public class GameData
    {
        private const int BEST_SCORE = 0;
        private const bool IS_MUSIC = true;
        private const bool IS_SOUND = true;

        public int BestScore;
        public bool IsMusic;
        public bool IsSound;

        public GameData()
        {
            BestScore = BEST_SCORE;
            IsMusic = IS_MUSIC;
            IsSound = IS_SOUND;
        }
    }
}

