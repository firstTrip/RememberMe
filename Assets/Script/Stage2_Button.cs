using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Button : InterObject
{
    public int RightCnt;
    private float time;
    private Animator anim;
    private int cnt;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cnt = 0;
        time = 0;
    }

    private void Update()
    {
        FinishKey();
    }
    public override void FinishKey()
    {

        if (cnt == RightCnt)
        {
            Debug.Log("collect");
            isFinish = true;
            thisStage.GetComponent<Stage>().CallFinish();
        }
        else
        {
            isFinish = false;
            thisStage.GetComponent<Stage>().CallFinish();
        }

    }
    public bool setIsFinish()
    {
        return isFinish;
    }

    public override void Action()
    {
        time += Time.deltaTime;
        anim.SetBool("Button", true);

        if (time > 0.1f)
        {
            cnt++;
            anim.speed = 3.0f;
            anim.SetBool("Button", false);
            Debug.Log(cnt);
            time = 0;
        }
    }

    public override void StopAction()
    {


        //cnt = 0;
    }
}
