using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantPath : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Vector3[] positions;

    private int _index;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[_index], Time.deltaTime * speed);

        if (transform.position == positions[_index])
        {
            _index = (_index + 1) % positions.Length;
        }
    }
}