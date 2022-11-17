using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clicker : MonoBehaviour
{
    [SerializeField] private int points;

    public static event Action<int> OnCubeClicked;

    private void OnMouseDown()
    {
        OnCubeClicked.Invoke(points);
    }
}
