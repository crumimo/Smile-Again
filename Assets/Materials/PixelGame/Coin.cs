using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private float coins = 0;
    public TMP_Text coinsText;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(coll.gameObject);
        }
    }
}
