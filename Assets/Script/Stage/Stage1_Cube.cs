using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage1_Cube : Stage
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        OpenNextStage();
    }

    public override void CallFinish(bool temp)
    {
        clearFlag = temp;
    }

    public override void OpenNextStage()
    {
        if (clearFlag)  
        {
            for(int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }
        }
    }
}
