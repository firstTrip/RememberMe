using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Camera camera;
    LayerMask layer;

    // Start is called before the first frame update
    void Awake()
    {
        Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialized()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

}
