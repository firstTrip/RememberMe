using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage3_Cube : Stage
{

    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeVector;

    public GameObject[] nextStage;
    private void Start()
    {
        shakeVector = 1.5f;
        shakeDuration = 0.2f;
        stageStartFlag = false;
        clearFlag = true;
    }
    private void Update()
    {
        if (stageStartFlag)
        {
            transform.DOShakePosition(shakeDuration, new Vector3(shakeVector, 0, shakeVector)).SetLoops(-1, LoopType.Incremental);
            stageStartFlag = false;
            OpenNextStage();

            for (int j =0; j < closeDoors.Length; j++)
            {
                closeDoors[j].SetActive(true);
            }

            for (int j = 0; j < nextStage.Length; j++)
            {
                nextStage[j].SetActive(false);
            }

        }
    }

    public override void CallFinish(bool temp)
    {
        clearFlag = temp;
    }

    public override void OpenNextStage()
    {
        base.OpenNextStage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.stageStartFlag = true;
        }
    }
}
