using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointsManager : MonoBehaviour
{
    private int currentPoints;

    public static event Action<int> OnCurrentPointsChange;

    private void OnEnable()
    {
        Clicker.OnCubeClicked += Clicker_OnCubeClicked;
    }

    private void OnDisable()
    {
        Clicker.OnCubeClicked -= Clicker_OnCubeClicked;
    }

    private void Clicker_OnCubeClicked(int points)
    {
        currentPoints += points;
        OnCurrentPointsChange?.Invoke(currentPoints);
    }
}
