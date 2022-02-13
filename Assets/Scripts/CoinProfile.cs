using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinProfile : MonoBehaviour
{
    public TMP_Text text_profile;
    public InputField inputfield;


    private void Start()
    {
        text_profile.text = My_Text.MyText;
    }

    public void LoadText()
    {
        My_Text.MyText = inputfield.text;
    }
    
}
