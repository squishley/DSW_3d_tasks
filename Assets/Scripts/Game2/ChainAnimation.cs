using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChainAnimation : MonoBehaviour
{
    private bool isTweeing;

    [SerializeField] private MeshRenderer meshRenderer;

    private Material material;
    private Color currentColor = Color.white;
    
    private void Awake()
    {
        material = meshRenderer.material;
    }

    private void OnMouseDown()
    {
        if (isTweeing) return;
        Animate();
    }

    private void Animate()
    {
        if (isTweeing) return;
        Sequence sequence = DOTween.Sequence();

        sequence.Append(MoveLeft());
        sequence.Append(ChangeColor());
        sequence.Append(Rotate());
        sequence.Append(ChangeColor());
        sequence.Append(MoveRight());
        sequence.onComplete += AllowTweening;;
    }

    private void AllowTweening()
    {
        isTweeing = false;
    }

    private Tween MoveLeft()
    {
        Vector3 targetPosition = transform.position + Vector3.left;
        return transform.DOMove(targetPosition, 1f);
    }

    private Tween Rotate()
    {
        Vector3 targetRotation = transform.eulerAngles + Vector3.up * 360f;
        return transform.DORotate(targetRotation, 1f, RotateMode.FastBeyond360);
    }

    private Tween MoveRight()
    {
        Vector3 targetPosition = transform.position;
        return transform.DOMove(targetPosition, 1f);
    }

    private Tween ChangeColor()
    {
        Color targetColor = currentColor == Color.white ? Color.black : Color.white;
        currentColor = targetColor;
        return material.DOColor(targetColor, 1f);
    }
}
