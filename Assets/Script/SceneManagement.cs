using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject startPanel, guidePanel, optionsPanel;

    public void Start()
    {
        volumeSlider.value = 0.7f;
    }
    public void startGame()
    {
        SceneManager.LoadScene(2);
    }

    public void SettingButton()
    {
        startPanel.SetActive(false);
        guidePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void GuideButton()
    {
        startPanel.SetActive(false);
        guidePanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void BackButton()
    {
        startPanel.SetActive(true);
        guidePanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
