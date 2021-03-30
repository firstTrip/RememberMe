﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage2_Cube : Stage
{
    public bool[] Answer;

    private void Start()
    {
        transform.DORotate(new Vector3(90, 0, 0), 30).SetLoops(-1,LoopType.Incremental);
    }
    private void Update()
    {
        OpenNextStage();

    }

    public override void CallFinish()
    {
        for(int i = 0; i < Key.Length; i++)
        {

            if(Key[i] == null)
            {
                Debug.Log("no have Key");
            }
            Answer[i] = Key[i].GetComponent<Stage2_Button>().isFinish;
            Debug.Log("into");
        }

        if (Answer[0] && Answer[1] && Answer[2] && Answer[3])
            clearFlag = true;

        Debug.Log(clearFlag);
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