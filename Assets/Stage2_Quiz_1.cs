using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Quiz_1 : InterObject
{


    public override void FinishKey()
    {
        Debug.Log("FinishKey");
        isFinish = true;
        thisStage.GetComponent<Stage>().CallFinish(isFinish);
    }

    public override void Action()
    {
        Debug.Log("play2");
        isActive = true;
    }

    public override void StopAction()
    {
        Debug.Log("playStop2");
        isActive = false;
    }
}
