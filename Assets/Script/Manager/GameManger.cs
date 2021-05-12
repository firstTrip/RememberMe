using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySound("BGM");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Awake()
    {
        //DataManager.Instance.Load();

    }

   
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            DataManager.Instance.Load();

        }
    }


    private void OnApplicationQuit()
    {
        DataManager.Instance.Save();
    }
}
