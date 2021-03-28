using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{

    public bool clearFlag;
    public GameObject[] doors;
    public GameObject[] Key;

    void Start()
    {
        clearFlag = false;
    }

    public virtual void CallFinish(bool temp)
    {
        clearFlag = temp;
    }

    public virtual void CallFinish()
    {

    }

    public virtual void OpenNextStage()
    {
        if (clearFlag)
        {
            
        }
    }
}
