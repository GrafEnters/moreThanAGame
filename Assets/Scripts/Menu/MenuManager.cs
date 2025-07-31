using System;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    [SerializeField]
    private MenuUI _menuUI;

    private void Awake() {
        SaveLoadManager.LoadGame();
        _menuUI.UpdateHighscores(SaveLoadManager.GameData.Highscores);
    }
}