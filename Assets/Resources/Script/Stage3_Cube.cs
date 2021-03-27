using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage3_Cube : Stage
{

    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeVector;
    private void Start()
    {
        shakeVector = 1.5f;
        shakeDuration = 0.2f;
        transform.DOShakePosition(shakeDuration, new Vector3(shakeVector, 0, shakeVector)).SetLoops(-1, LoopType.Incremental);
    }
    private void Update()
    {
        OpenNextStage();
    }

    public override void CallFinish(bool temp)
    {
        clearFlag = temp;
    }

    public override void OpenNextStage()
    {
        Debug.Log(clearFlag);
        if (clearFlag)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }
        }
    }
}
