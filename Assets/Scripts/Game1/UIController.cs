using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starsText;
    //[SerializeField] private GameObject endGameText;

    private void Start()
    {
        UpdateStars(0);
    }
    
    public void UpdateStars(int points)
    {
        starsText.text = "Stars: " + points;
        /*if(star >= 5)
        {

        }*/
    }
}
