using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Number of level, if we want to be able to go back in levels need to make it a parameter instead of static 1++
    public int index;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Enemy.enemiesAmount <= 0)
            SceneManager.LoadScene(index);
    }
}
