using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Cube : Stage
{
    // Start is called before the first frame update
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
         
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
