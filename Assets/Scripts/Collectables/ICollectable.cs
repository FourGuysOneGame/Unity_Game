using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    void Collect(Collider2D collider2D);
}