using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        ScoreText.coinAmount += 1;
        Destroy(gameObject);
    }
}
