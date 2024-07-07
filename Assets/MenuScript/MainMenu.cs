using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool Save;
    void Start()
    {
        AudioListener.pause = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        AudioListener.pause = false;
    }
    public void PlaySavedGame()
    {
        SceneManager.LoadScene(1);
        if (PlayerPrefs.HasKey("SavePositionX") == true)
        {
            Save = true;
           
            /*Player.transform.position = new Vector3(PlayerPrefs.GetFloat("SavePositionX"), PlayerPrefs.GetFloat("SavePositionY"), PlayerPrefs.GetFloat("SavePositionZ"));*/
        }
    }
    public void ExitGame()
    {
        Debug.Log("Buh");
        Application.Quit();
    }
}
