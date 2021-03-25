using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera theCamera;

    public bool useStaticBillboard;
    // Start is called before the first frame update
    void Start()
    {
        theCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            transform.LookAt(theCamera.transform);
        }else
        {
            transform.rotation = theCamera.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
