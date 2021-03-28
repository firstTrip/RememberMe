using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placard : InterObject
{

    [SerializeField] private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (isActive)
        {
            anim.speed = 0.8f;
            anim.SetBool("spin", true);
         
        }
        else
        {
            anim.speed = 0;
        }

    }


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
