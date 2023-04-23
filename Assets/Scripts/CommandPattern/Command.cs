using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    public KeyCode Key { get; private set; }

    public Command(KeyCode key)
    {
        this.Key = key;
    }

    // executed in a first frame when key is clicked
    public virtual void GetKeyDown()
    {
        
    }

    //executed in a frame when key is unlocked
    public virtual void GetKeyUp()
    {
        
    }

    //executed in every frame when key is clicked
    public virtual void GetKey()
    {
        
    }
}
