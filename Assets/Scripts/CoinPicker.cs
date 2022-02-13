using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPicker : MonoBehaviour
{
    public int coin;
    public Text coinT;

    private void Awake() 
    {
        if(!PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
    }
    
    void Start() 
    {
        coin = PlayerPrefs.GetInt("Coin");
        coinT.text = coin.ToString();
    }


    private void OnTriggerEnter2D(Collider2D coll)

    {

        if(coll.gameObject.tag == "Coin")
        {
            coin += 1;
            coinT.text = coin.ToString(); 
            Destroy (coll.gameObject);
            PlayerPrefs.SetInt("Coin", coin );
        }
    }
   
}
