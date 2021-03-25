using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{


    public bool clearFlag;
    protected GameObject[] doors;
    protected GameObject[] Key;

    // Start is called before the first frame update
    void Start()
    {
        clearFlag = false;
    }

  
    public virtual void OpenNextStage()
    {
        if (clearFlag)
        {
            // 스테이지의 문이 활성화 상태로 변신 
        }
    }
}
