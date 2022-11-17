using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.SceneControl
{
    public class LoadSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject loadingSpinning;
        [SerializeField] private Slider loadingBar;
        [SerializeField] private Button activateGameButton;

        public static LoadSceneManager instance;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName)); 
        }
        
        private IEnumerator LoadSceneAsync(string sceneName)
        {
            canvas.SetActive(true);
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
            loading.allowSceneActivation = false;
            while(!loading.isDone)
            {
                loadingBar.value = loading.progress/0.9f;
                if (loading.progress >= 0.9f)
                {
                    break; 
                }
                yield return null;
            }
            activateGameButton.gameObject.SetActive(true);
            activateGameButton.onClick.AddListener( () =>
            {
                loading.allowSceneActivation = true;
                canvas.SetActive(false);
            });
        } 
    }
}