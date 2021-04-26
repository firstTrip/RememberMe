using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if(gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
        }
        return _gameData;
    }

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
                    container.name = "AudioManager";
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


}
