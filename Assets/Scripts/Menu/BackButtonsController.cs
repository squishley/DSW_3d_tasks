using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonsController : MonoBehaviour
{
    [SerializeField] private Button BackButton;
    [SerializeField] private GameObject MainMenu;

    private void Awake()
    {
        BackButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnBackButtonClick()
    {
        gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }
}
