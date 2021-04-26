using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterObject : MonoBehaviour
{

    public bool isFinish;
    protected bool isActive;
    public GameObject thisStage;
    // Start is called before the first frame update

    void Start()
    {
        isActive = false;
        isFinish = false;
    }

    public virtual void FinishKey()
    {
        isFinish = true;
        thisStage.GetComponent<Stage>().CallFinish(isFinish);
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
