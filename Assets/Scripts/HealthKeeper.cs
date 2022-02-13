using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthKeeper : MonoBehaviour
{
    private float health = 3;
    private float maxhealth = 0;
    public TMP_Text healthText;
    [SerializeField]
    GameObject pause;

    
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseMenuButton()
    {
        
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if(coll.gameObject.tag == "FallDetector")
        {
            health -= 1;
            if(health <= 0)
            {
                PauseMenuButton();
            }
            healthText.text = health.ToString(); 

        }
    }

    public void Death()
    {
      if(health == maxhealth)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
