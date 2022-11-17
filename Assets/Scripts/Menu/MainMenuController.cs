using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Code.SceneControl;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject playMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;
    
    private void Awake()
    {
        startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        optionsButton.onClick.AddListener(OnOptionsButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnStartGameButtonClicked()
    {
        playMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnOptionsButtonClicked()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnCreditsButtonClicked()
    {
        creditsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    
    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
