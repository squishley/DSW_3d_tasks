using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenInitializer : MonoBehaviour
{
    private void Awake()
    {
        DOTween.Init();
    }
}
