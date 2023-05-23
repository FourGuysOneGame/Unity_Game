using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    [SerializeField] private Transform lifeParent;

    [SerializeField] private GameObject fullLifePrefab;
    [SerializeField] private GameObject emptyLifePrefab;

    private List<GameObject> _lives = new();

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }

    public void AddLifeContainer(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _lives.Add(Instantiate(fullLifePrefab, lifeParent));
        }
    }

    public void AddLife(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int count = -1, index = 1;

            while (index != 0)
            {
                index = _lives.FindIndex(lifePrefab => lifePrefab.CompareTag("EmptyHeart"));
                if (index == -1)
                    break;
                GameObject life = _lives[index];
                _lives.RemoveAt(index);
                Destroy(life);
                ++count;
            }

            if (count != -1)
            {
                _lives.Add(Instantiate(fullLifePrefab, lifeParent));

                for (int j = 0; j < count; j++) 
                {
                    _lives.Add(Instantiate(emptyLifePrefab, lifeParent));
                }
            }
        }
    }

    public void RemoveLife(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int index = _lives.FindLastIndex(lifePrefab => lifePrefab.CompareTag("FullHeart"));
            if (index == -1)
                break;
            GameObject life = _lives[index];
            _lives.RemoveAt(index);
            Destroy(life);
            _lives.Add(Instantiate(emptyLifePrefab, lifeParent));

            // If after taking hit you have 0 health -> restart scene
            if (index == 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RemoveLifeContainer(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Destroy(_lives.FindLast(lifePrefab => lifePrefab.CompareTag("EmptyHeart")));
        }
    }
}