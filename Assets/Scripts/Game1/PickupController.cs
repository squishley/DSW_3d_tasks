using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public int points;

    public int Collect()
    {
        Destroy(gameObject);
        return points;
    }
}
