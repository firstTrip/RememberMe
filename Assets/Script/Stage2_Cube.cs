using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage2_Cube : Stage
{
    public bool[] Answer;
    public GameObject[] nextStage;

    private void Start()
    {
        stageStartFlag = false;
    }
    private void Update()
    {
        if (stageStartFlag)
        {
            for (int i = 0; i < closeDoors.Length; i++)
            {
                closeDoors[i].SetActive(true);
            }

            for (int j = 0; j < nextStage.Length; j++)
            {
                nextStage[j].SetActive(false);
            }

            transform.DORotate(new Vector3(90f, 0f, 0f), 30, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental);
            
            stageStartFlag = false;
        }

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
        }

        if (Answer[0] && Answer[1] && Answer[2] && Answer[3])
        {
            clearFlag = true;
            transform.DOPause();
            //this.gameObject.transform.localRotation = new Quaternion(-0.647f,-90,180,0);
        }

    }

    public override void OpenNextStage()
    {
        if (clearFlag)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }

            for (int j = 0; j < nextStage.Length; j++)
            {
                nextStage[j].SetActive(true);
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
