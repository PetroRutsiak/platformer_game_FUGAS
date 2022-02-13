using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lastbutton : MonoBehaviour
{
    [SerializeField] private int LevelIndex;
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - LevelIndex);
    }
}
