using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{

    protected bool crearFlag;
    protected GameObject[] doors;

    // Start is called before the first frame update
    void Start()
    {
        crearFlag = false;
    }

  
    public virtual void OpenNextStage()
    {
        if (crearFlag)
        {
            // 스테이지의 문이 활성화 상태로 변신 
        }
    }
}
