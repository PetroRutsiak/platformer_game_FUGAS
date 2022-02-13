using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    public float coins;
    public TMP_Text coinsText;
    private void OnTriggerEnter2D(Collider2D coll)
    {

        if(coll.gameObject.tag == "Coin")
        {
            coins += 1;
            coinsText.text = coins.ToString(); 
            Destroy (coll.gameObject);
        }
    }
   
}
