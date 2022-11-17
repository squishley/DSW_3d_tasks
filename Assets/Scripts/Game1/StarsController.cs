using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    [SerializeField] private int points;
    
    public int Collect()
    {
        Destroy(gameObject);
        return points;
    }
}