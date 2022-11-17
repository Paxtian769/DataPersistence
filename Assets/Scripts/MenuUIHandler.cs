using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    string playerName;
    int highScore;
    string currentPlayerName;

    [SerializeField] TextMeshProUGUI topScoreText;
    [SerializeField] TextMeshProUGUI currentPlayerNameText;

    private void Start()
    {
        playerName = GameManager.Instance.highScorePlayerName;
        highScore = GameManager.Instance.highScore;
        topScoreText.text = "Top Score: " + highScore + " by " + playerName;
    }

    private void SetPlayerName()
    {
        GameManager.Instance.currPlayerName = currentPlayerNameText.text;
    }

    public void StartNewGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        GameManager.Instance.SaveScoreData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
