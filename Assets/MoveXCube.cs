using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveXCube : MonoBehaviour
{

    [SerializeField] float EndValue = 3;
    [SerializeField] float StartValue = 3;
    [SerializeField] float ShakeDuration = 1;
    [Header("동작 가능 여부")]
    [Tooltip("Y 축으로 이동하는가")] public bool isStart;
    [Tooltip("진동 하는가")] public bool isVibration;
    [Space]
    [Header("선형 타입")]
    [Tooltip("이동 방법")] public Ease ease;
    [Space]

    [Header("반복 여부")]
    [Tooltip("체크시 루브")] public bool isLoop;
    [Space]
    [Header("루프 타입")]
    [Tooltip("루프 타입 reStart 일경우 처음부터 시작 , yoyo 일경우 돌아온 동작 반복, increment 일경우 시작점 유지")] public LoopType loopType;
    
    private int loopNum;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLoop)
        {
            loopNum = 0;
        }
        else
        {
            loopNum = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isStart)
        {
            if (isVibration)
            {
                transform.DOShakePosition(3f);
                isVibration = false;
            }
            transform.DOMoveX(EndValue, StartValue).SetEase(ease).SetLoops(loopNum, loopType);
            isStart = false;
        }

    }
}
