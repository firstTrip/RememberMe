using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGDatabase;

public class stageManager : B_StageData
{

    #region SingleTon
    /* SingleTon */
    private static stageManager instance;
    public static stageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(stageManager)) as stageManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "stageManager";
                    instance = container.AddComponent(typeof(stageManager)) as stageManager;
                }
            }

            return instance;
        }
    }
    #endregion

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        

        #region SingleTon
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        #endregion
    }


    public void SavePoint()
    {
        ResponsePosition = Player.transform.position;
        ResponseRotation = Player.transform.rotation;
    }

    public void LoadPoint()
    {
        Player.transform.position = ResponsePosition;
        Player.transform.rotation = ResponseRotation;
    }

    public void NextEntity()
    {
        int i = 0;
        var meta = BGRepo.I["StageData"];
        var entity = meta.GetEntity(i);
        Debug.Log(meta.Name);
        Debug.Log(entity);
        i++;
        entity = meta.GetEntity(i);
        entity.Set("StageData", i);
        Debug.Log(entity.Name);
    }
}
