using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    PlayerControls control;

    private void Awake()
    {
        control = new PlayerControls();

        //control.Gameplay.ReloadGame.performed += ctx => reloadGame();
        control.Gameplay.ExitGame.performed += ctx => exitGame();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnEnable()
    {
        control.Gameplay.Enable();
    }

    public void reloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
