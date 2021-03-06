using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using BansheeGz.BGDatabase;

public class DataManager : MonoBehaviour 
{

    #region SingleTon
    /* SingleTon */
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(DataManager)) as DataManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "DataManager";
                    instance = container.AddComponent(typeof(DataManager)) as DataManager;
                }
            }

            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        #region SingleTon
        if (instance  == null)
        {
            instance = this;
        }else if(instance != null)
        {
            Destroy(this);
        }
        #endregion

    }
    
    public bool HasSavedFile
    {
        get{ return File.Exists(SaveFilePath); }
    }

    public string SaveFilePath
    {
        get{ return Path.Combine(Application.persistentDataPath, "bg_save_data.dat"); }
    }

    public void Save()
    {
        stageManager.Instance.SavePoint();
        File.WriteAllBytes(SaveFilePath, BGRepo.I.Addons.Get<BGAddonSaveLoad>().Save());
    }

    public void Load()
    {
        if (!HasSavedFile) return;

        stageManager.Instance.LoadPoint();
        BGRepo.I.Addons.Get<BGAddonSaveLoad>().Load(File.ReadAllBytes(SaveFilePath));
    }

   
}
