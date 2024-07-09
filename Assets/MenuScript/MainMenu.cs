using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool Save =false;
    void Start()
    {
        AudioListener.pause = true;
        ToggleSceneActivity("GameScene", false);
    }
    public void PlayGame()
    {
        BotSpawner.waveNumber = 0;
        BotSpawner.numberOfEnemies = 2;
        ToggleSceneActivity("GameScene", true);
        SceneManager.LoadScene(1);
        AudioListener.pause = false;
    }
    public void PlaySavedGame()
    {
        ToggleSceneActivity("GameScene", true);
        AudioListener.pause = false;
        SceneManager.LoadScene(1);
        if (PlayerPrefs.HasKey("SavePositionX") == true)
        {
            Save = true;
           
            /*Player.transform.position = new Vector3(PlayerPrefs.GetFloat("SavePositionX"), PlayerPrefs.GetFloat("SavePositionY"), PlayerPrefs.GetFloat("SavePositionZ"));*/
        }
    }
    void ToggleSceneActivity(string name, bool isActive)
    {
        Scene scene = SceneManager.GetSceneByName(name);
        if (scene.IsValid())
        {
            if (isActive)
            {
                SceneManager.SetActiveScene(scene);
                Debug.Log("—цена " + name + " включена");
            }
            else
            {
                SceneManager.UnloadSceneAsync(name);
                Debug.Log("—цена " + name + " выключена");
            }
        }
        else
        {
            Debug.LogError("—цена " + name + " не найдена");
        }
    }
    public void ExitGame()
    {
        Debug.Log("Buh");
        Application.Quit();
    }
}
