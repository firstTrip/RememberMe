using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placard : InterObject
{

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            anim.speed = 0.4f;
            anim.SetBool("spin", true);
         
        }
        else
        {
            anim.speed = 0;
        }


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
