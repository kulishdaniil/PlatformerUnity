using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManagerHealth : MonoBehaviour
{ 
    public static int playerHealth;
    public static bool gameOver;
    public TextMeshProUGUI playerHealthText;
    public GameObject RedOverlay;

    void Start()
    {
        playerHealth = 100;
        gameOver = false;
    }

    void Update()
    {
        playerHealthText.text = "" + playerHealth;
        if (gameOver)
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Menu");
        }
    }

    public IEnumerator Damage(int damageCount)
    {
        playerHealth -= damageCount;
        RedOverlay.SetActive(true);

        if (playerHealth <= 0) gameOver = true;

        yield return new WaitForSeconds(0.5f);
        RedOverlay.SetActive(false);
    }
}
