using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    // Number of level, if we want to be able to go back in levels need to make it a parameter instead of static 1++
    public int index = 1;
    public Image black;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Enemy.enemiesAmount <= 0)
        {
            StartCoroutine(Fading());
            SceneManager.LoadScene(index);
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
    }
}
