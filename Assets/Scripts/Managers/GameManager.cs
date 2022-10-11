using System;

namespace ShotMergerClone.Managers
{
    public static class GameManager
    {
        public static Action onLevelStart;
        public static Action onLevelOver;

        public static Action onLevelSuccess;
        public static Action onLevelFail;

        public static void GameStart()
        {
            onLevelStart?.Invoke();
        }

        public static void GameFail()
        {
            onLevelOver?.Invoke();
            onLevelFail?.Invoke();
        }

        public static void GameSuccess()
        {
            onLevelOver?.Invoke();
            onLevelSuccess?.Invoke();
        }
    }
}


