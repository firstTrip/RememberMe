using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{

    public bool clearFlag;
    public bool stageStartFlag;
    public GameObject[] doors;
    public GameObject[] closeDoors;
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
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.stageStartFlag = true;
        }
    }
}
