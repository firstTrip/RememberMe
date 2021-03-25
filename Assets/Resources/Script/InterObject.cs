using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterObject : MonoBehaviour
{

    protected bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }


    public virtual void Action()
    {
        isActive = true;
        Debug.Log("Play1");
    }

    public virtual void StopAction()
    {
        isActive = false;
        Debug.Log("PlayStop1");
    }
}
