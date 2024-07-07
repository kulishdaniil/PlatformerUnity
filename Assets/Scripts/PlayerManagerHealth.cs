using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManagerHealth : MonoBehaviour
{ 

    public static int playerHealth;
    public static bool gameOver;
    public int maxHealth = 100;

    Image healthBar;
    public TextMeshProUGUI playerHealthText;
    public GameObject RedOverlay;

    void Start()
    {
        healthBar = GetComponent<Image>();
        playerHealth = maxHealth;
        gameOver = false;
    }

    void Update()
    {
        healthBar.fillAmount = playerHealth / maxHealth;
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
