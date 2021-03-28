using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_QuizManger : InterObject
{
    // Start is called before the first frame update
    void Start()
    {

    }
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
