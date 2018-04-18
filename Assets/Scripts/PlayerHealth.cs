using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public bool player = false;

    public int maxHealth = 20;
    public int currentHealth;

    float timer = 2;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == true)
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    string sceneName = SceneManager.GetActiveScene().name;

                    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                }
            }
        }
        else if (player == false)
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
