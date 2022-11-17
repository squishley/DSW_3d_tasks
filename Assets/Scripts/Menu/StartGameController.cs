using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Code.SceneControl;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private Button RollBallButton;
    [SerializeField] private Button AnimationButton;
    [SerializeField] private string rollBallScene;
    [SerializeField] private string animationScene;

    private void Awake()
    {
        RollBallButton.onClick.AddListener(OnStartRollBallButtonClicked);
        AnimationButton.onClick.AddListener(OnStartAnimationButtonClicked);
    }

    private void OnStartRollBallButtonClicked()
    {
        LoadSceneManager.instance.LoadScene(rollBallScene);
    }

    private void OnStartAnimationButtonClicked()
    {
        LoadSceneManager.instance.LoadScene(animationScene);
    }
}
