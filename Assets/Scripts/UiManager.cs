using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Text _diamondText;

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject endMenu;
    [SerializeField]
    private Text _EndScoreText;
    private string diamondScore;
    public static bool GameisPaused = false;
    public void UpdateCoinDisplay(int diamond)
    {
        diamondScore = diamond.ToString();
        _diamondText.text = diamondScore;
    }

    public void GamePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;

    }
    public void GameResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    public void onPlayerDeath(int diamondCollected)
    {
        _EndScoreText.text = "Your Score : " + diamondCollected.ToString();
        _diamondText.gameObject.SetActive(false);
        endMenu.SetActive(true);
    }

    public void onStartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void onMainMenuButtonClick()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
