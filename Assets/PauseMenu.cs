using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    public GameObject Player;
    float X, Y, Z;

    
    void Update()
    {
        if (MainMenu.Save)
        {
            MainMenu.Save = false;
            Player.transform.position = new Vector3(PlayerPrefs.GetFloat("SavePositionX"), PlayerPrefs.GetFloat("SavePositionY"), PlayerPrefs.GetFloat("SavePositionZ"));
        }
        X = Player.transform.position.x;
        Y = Player.transform.position.y;
        Z = Player.transform.position.z;
        /*if (PauseGame)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("SavePositionX", X);
        PlayerPrefs.SetFloat("SavePositionY", Y);
        PlayerPrefs.SetFloat("SavePositionZ", Z);
       
        PlayerPrefs.Save();
        Debug.Log("Save");
    }
}
