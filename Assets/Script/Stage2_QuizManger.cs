using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_QuizManger : InterObject
{
   
    public override void FinishKey()
    {
        Debug.Log("FinishKey");
        isFinish = true;
        thisStage.GetComponent<Stage>().CallFinish(isFinish);
    }

    public override void Action()
    {
    }

    public override void StopAction()
    {
    }
}
