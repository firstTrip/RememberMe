using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage1_Cube : Stage
{
    // Start is called before the first frame update
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        transform.DORotate(new Vector3(90,0,0), 3);

    }


    public override void OpenNextStage()
    {
        if (crearFlag)
        {
            for(int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }
        }
        
    }
}
