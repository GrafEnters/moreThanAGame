using System;
using UnityEngine;

public static class SaveLoadManager {
    public static GameData GameData;

    private static string _gameDataKey = "gameData";

    public static void LoadGame() {
        if (PlayerPrefs.HasKey(_gameDataKey)) {
            string saveJson = PlayerPrefs.GetString(_gameDataKey);
            GameData = JsonUtility.FromJson<GameData>(saveJson);
        } else {
            GameData = new GameData();
        }
        Debug.Log("Сохранение:\n" + JsonUtility.ToJson(GameData));
    }

    public static void SaveGame() {
        string saveJson = JsonUtility.ToJson(GameData);
        PlayerPrefs.SetString(_gameDataKey, saveJson);
    }
}