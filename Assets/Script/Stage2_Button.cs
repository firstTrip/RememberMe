using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Button : InterObject
{
    private int cnt;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
    }
    public override void FinishKey()
    {
        Debug.Log("FinishKey");
        isFinish = true;
        thisStage.GetComponent<Stage>().CallFinish(isFinish);
    }

    public override void Action()
    {
        cnt++;
        Debug.Log(cnt);
    }

    public override void StopAction()
    {

    }
}
