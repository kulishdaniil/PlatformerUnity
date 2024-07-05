using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool Save;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlaySavedGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
