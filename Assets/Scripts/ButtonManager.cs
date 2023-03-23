using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] int scene;
    [SerializeField] GameObject options;
    public GameState gameState {get; set;}
    
    public void SwitchScene()
    {
        if (GameState.NOT_RUNNING.Equals(gameState))
        {
            SceneManager.LoadScene(scene);   
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableOptions(bool active)
    {
        if (GameState.NOT_RUNNING.Equals(gameState))
        {
            options.gameObject.SetActive(active);
        }
    }

}
