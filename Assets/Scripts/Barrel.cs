using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;


public class Barrel : MonoBehaviour, IHitable
{
    public List<GameObject> itemDrops;
    private int barrelHp = 3;

    private void ItemDrop()
    {
        if (barrelHp == 0)
        {
            for (int i = 0; i < itemDrops.Count; i++)
            {
                Debug.Log(itemDrops);
                Instantiate(itemDrops[i], transform.position, Quaternion.identity);
                Debug.Log("Item dropped");
            }

            Destroy(gameObject);
        }
        else
            barrelHp--;
    }
    
    public void TakeHit()
    {
        ItemDrop();
    }
}
