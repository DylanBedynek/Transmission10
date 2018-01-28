using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {
    public GameObject mainCanvas;
    public GameObject optionsCanvas;
    public GameObject controlsCanvas;
    public GameObject creditsCanvas;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {

        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainCanvas.SetActive(true);
            optionsCanvas.SetActive(false);
            controlsCanvas.SetActive(false);
            creditsCanvas.SetActive(false);

        }
    }
    public void Options()
    {
        optionsCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
        mainCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }
    public void Credits()
    {
        creditsCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        controlsCanvas.SetActive(false);
        mainCanvas.SetActive(false);
    }
    public void Controls()
    {
        creditsCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }
}
