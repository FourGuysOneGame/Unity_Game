using System.Collections.Generic;
using UnityEngine;


public class Barrel : MonoBehaviour, IHitable
{
    public List<GameObject> itemDrops;
    [SerializeField] private int barrelHp = 3;

    private void ItemDrop()
    {
        if (barrelHp == 0)
        {
            for (int i = 0; i < itemDrops.Count; i++)
            {
                Instantiate(itemDrops[i], transform.position, Quaternion.identity);
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