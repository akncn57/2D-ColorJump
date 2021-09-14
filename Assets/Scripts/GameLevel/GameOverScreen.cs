using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOverScreen : MonoBehaviour
{
    // Game Over function.
    public void GameOver()
    {
        // Enable gameobject.
        gameObject.SetActive(true);

        // Fade animation.
        this.GetComponent<CanvasGroup>().DOFade(1f, 0.50f);
    }

    public void RestartButton()
    {
        // Game time start.

        Time.timeScale = 1;
        // Active scene reload.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        // Game time start.
        Time.timeScale = 1;

        // MainMenu scene load.
        SceneManager.LoadScene("MainMenu");
    }
}
