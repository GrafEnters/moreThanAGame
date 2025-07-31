using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {
    [SerializeField]
    private GameObject _highscoresPanel;

    [SerializeField]
    private List<TextMeshProUGUI> _recordsTexts;

    public void StartGame() {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void UpdateHighscores(List<string> highscores) {
        if (highscores.Count == 0) {
            _highscoresPanel.gameObject.SetActive(false);
        } else {
            _highscoresPanel.gameObject.SetActive(true);
            for (int i = 0; i < highscores.Count; i++) {
                _recordsTexts[i].text = highscores[i];
            }
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}