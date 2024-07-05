using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("SavePositionX", Player.transform.position.x);
        PlayerPrefs.SetFloat("SavePositionY", Player.transform.position.y);
        PlayerPrefs.SetFloat("SavePositionZ", Player.transform.position.z);
        Debug.Log("Save");
    }
    
}
