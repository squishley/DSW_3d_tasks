using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class PointsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private Gradient colorGradient;
    [SerializeField] private int[] thresholds;

    private int points;

    private int Points
    {
        get => points;
        set
        {
            points = value;
            pointsText.text = "Counter: " + points;
            ChangeTextColor();
        }
    }

    private void OnEnable()
    {
        ChangeTextColor();
        PointsManager.OnCurrentPointsChange += PointsManager_OnCurrentPointsChange;
    }

    private void OnDisable()
    {
        PointsManager.OnCurrentPointsChange -= PointsManager_OnCurrentPointsChange;
    }

    private void PointsManager_OnCurrentPointsChange(int currentPoints)
    {
        ChangePoints(currentPoints, 1f);
    }

    private Tween ChangePoints(int targetPoints, float duration)
    {
        return DOTween.To(() => Points, x => Points = x, targetPoints, duration);
    }

    private Tween ChangeTextColor()
    {
        float thresholdValue = 0f;
        thresholdValue = Points > thresholds[4] ? 0.8f :(Points > thresholds[3] ? 0.64f : (Points > thresholds[2] ? 0.48f : (Points > thresholds[1] ? 0.32f :
        (Points > thresholds[0] ? 0.16f : 0))));
        Color targetColor = colorGradient.Evaluate(thresholdValue);
        return pointsText.DOColor(targetColor, 1f);
    }

}
