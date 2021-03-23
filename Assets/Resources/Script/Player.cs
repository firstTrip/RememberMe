using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [Header("이동 속도")]
    [SerializeField] private float moveForce;

    [Space]

    private float x;
    private float y;
    private float yRaw;
    private float xRaw;

    private Vector3 dir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager();
        dir = new Vector3(x, 0, y);

        Move();

    }

    // 추후에 빠질수도 있음
    private void inputManager()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        rb.AddForce(dir *moveForce, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
  
        if (other.tag == "Item")
        {
            Debug.Log("get Item");

        }


    }
}
