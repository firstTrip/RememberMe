using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage2_Cube : Stage
{
    

    private void Start()
    {
        transform.DORotate(new Vector3(90, 0, 0), 30).SetLoops(-1,LoopType.Incremental);
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
        Debug.Log(clearFlag);
        if (clearFlag)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }
        }
    }

}
