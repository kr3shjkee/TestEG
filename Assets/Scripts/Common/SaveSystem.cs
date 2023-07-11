using UnityEngine;

namespace Common
{
    public class SaveSystem 
    {
        private const string DATA_KEY = "GameData";

        public GameData Data { get; private set; }

        public bool CheckOnNewProfile()
        {
            if (PlayerPrefs.HasKey(DATA_KEY))
                return false;

            return true;
        }

        public void LoadData()
        {
            var jsonData = PlayerPrefs.GetString(DATA_KEY);
            Data = JsonUtility.FromJson<GameData>(jsonData);
        }

        public void SaveData()
        {
            var jsonData = JsonUtility.ToJson(Data);
            PlayerPrefs.SetString(DATA_KEY, jsonData);
        }

        public void CreateNewData()
        {
            Data = new GameData();
            SaveData();
        }
    }
}

