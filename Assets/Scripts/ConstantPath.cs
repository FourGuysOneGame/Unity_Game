using UnityEngine;

public class ConstantPath : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Vector3[] positions;

    private int _index;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[_index], Time.deltaTime * speed);

        if (transform.position == positions[_index])
        {
            _index = (_index + 1) % positions.Length;
        }
    }
}