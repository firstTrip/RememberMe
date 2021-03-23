using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Camera camera;

    [SerializeField] private float xOffset,yOffSet, zOffset;
    [SerializeField] private Vector3 camOffSet;
    [Tooltip("플레이어 :")] [SerializeField] private GameObject player;
    GameObject temp;

    [Space]

    [Tooltip("벽 레이어 ")][SerializeField] private LayerMask wall;

    private RaycastHit hit;
    // Start is called before the first frame update
    void Awake()
    {
        Initialized();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        //invisibleObject();
        camera.transform.position = player.transform.position + new Vector3(xOffset, yOffSet, zOffset);

    }

    void Initialized()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //yOffSet = 2;
        //zOffset = -3;
    }

    void invisibleObject()
    {
        int layerMask = 1 << LayerMask.NameToLayer("wall");

        if (temp != null)
        {
            temp.SetActive(true);

        }

        if(Physics.Raycast(transform.position + camOffSet, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("wall laycast");
            Debug.Log(hit.collider.gameObject.name);
            Debug.DrawRay(transform.position + camOffSet, transform.forward * hit.distance, Color.red, 0.3f);
            temp = hit.collider.gameObject;
            temp.SetActive(false);
            // 나중에 스프라이트만 삭제로 변경

        }
        else
        {
            Debug.Log("not wall laycast");
            Debug.DrawRay(transform.position + camOffSet, transform.forward * 1000f, Color.blue, 0.3f);

        }

       
    }

}
