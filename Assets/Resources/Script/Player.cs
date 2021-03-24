using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [Header("이동 속도")]
    [SerializeField] private float moveForce;
    [SerializeField] private float applyForce;
    [SerializeField] private float runForce;
    [SerializeField] private float jumpForce;
    [Header("카메라 이동 속도")]
    [SerializeField] private float rotSpeed;

    [Space]


    [SerializeField] private Camera camera;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    private bool isRun;

    private Vector3 dir;
    private PlayerCollision coll;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<PlayerCollision>();
        camera = Camera.main;
        isRun = false;
        applyForce = moveForce;
    }

    // Update is called once per frame
    void Update()
    {
        //inputManager();
        TryJump();

        TryRun();

        Move();
        CharacterRotation();
        CameraRotation();

    }

    #region 이동 함수
    private void Move()
    {

        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applyForce;

        rb.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    private void TryRun()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancle();
        }
    }
    private void TryJump()
    {
        // coll 에서 콜라이더 안부디치는거 수정
        if (Input.GetKeyDown(KeyCode.Space) && !coll.OnGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
    private void Running()
    {

        isRun = true;
        applyForce = runForce;
    }

    private void RunningCancle()
    {
        isRun = false;
        applyForce = moveForce;
    }
    #endregion

    #region 카메라
    private void CharacterRotation()
    {
        // 좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(_characterRotationY));
    }

    private void CameraRotation()
    {
        // 상하 카메라 회전
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        camera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
    #endregion

    private void OnTriggerStay(Collider other)
    {
  
        if (other.tag == "Item")
        {
            Debug.Log("get Item");

        }

    }
}
