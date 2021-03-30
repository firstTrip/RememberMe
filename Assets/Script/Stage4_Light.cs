using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_Light : Stage
{

    public bool[] Answer;

    // Start is called before the first frame update
    private void Update()
    {
        if (stageStartFlag)
        {
            for (int j = 0; j < closeDoors.Length; j++)
            {
                closeDoors[j].SetActive(true);
            }
        }
        OpenNextStage();

    }

    public override void CallFinish()
    {
        for (int i = 0; i < Key.Length; i++)
        {

            if (Key[i] == null)
            {
                Debug.Log("no have Key");
            }
            Answer[i] = Key[i].GetComponent<Stage2_Button>().isFinish;
        }

        if (Answer[0] && Answer[1] && Answer[2] && Answer[3] && Answer[4])
            clearFlag = true;

    }

    public override void OpenNextStage()
    {
        base.OpenNextStage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.stageStartFlag = true;
        }
    }
}
