using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BansheeGz.BGDatabase;

public class Stage1_Cube : Stage 
{

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        OpenNextStage();

        /*
        if (Input.GetKeyDown(KeyCode.L))
        {

            Player.transform.position= ResponsePosition ;
            Player.transform.rotation = ResponseRotation ;
            //this.clearFlag = StageClear;
            DataManager.Instance.Load();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StageClear = true;
            //var id = Entity.Name;
            var meta = BGRepo.I["Stage1"];
            var entity = meta.GetEntity(0);
            Debug.Log(entity.Name);

            ResponsePosition = Player.transform.position;
            ResponseRotation = Player.transform.rotation;
            DataManager.Instance.Save();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {

        }*/
    }

    
    public override void CallFinish(bool temp)
    {
        clearFlag = temp;
    }

    public override void OpenNextStage()
    {
        if (clearFlag)  
        {
            for(int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }
        }
    }
    
}
