using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nickname : MonoBehaviour
{

    [SerializeField] private InputField InputName;
    [SerializeField] private GameObject PanelName;

    [SerializeField] private Text TextName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        if(InputName.text == "")
        {
            Debug.Log("Error");
        }
        else
        {
            PanelName.SetActive(false);
            TextName.text += " " + InputName.text;
            Debug.Log("Ok");
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
