using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_Light : Stage
{

    public bool[] Answer;

    // Start is called before the first frame update
    private void Update()
    {
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
            Debug.Log("into");
        }

        if (Answer[0] && Answer[1] && Answer[2] && Answer[3] && Answer[4])
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
