using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public Text text_profile;
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
