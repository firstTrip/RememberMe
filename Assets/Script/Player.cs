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
    [SerializeField] private float crouchForce;
    [SerializeField] private float rayLength;


    [Space]

    [Header("카메라 이동 속도")]
    [SerializeField] private float rotSpeed;

    [Space]
    [Header("좌표")]
    [SerializeField] private float crouchPosY;
    [SerializeField] private float originPosY;
    [SerializeField] private float applyCrouchPosY;
    [SerializeField] private GameObject rayTran;

    [Space]
    [Header("레이어 마스크")]
    [SerializeField] private LayerMask interactionObject;
    [SerializeField] private LayerMask GruondLayer;

    [SerializeField] private Camera theCamera;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit = 60f;
    private float currentCameraRotationX = 0;

    [Space]

    private GameObject interObject;
    private RaycastHit ray;
    private bool isCrouch;
    [SerializeField] [Tooltip("땅이야?")] private bool isGruond;

    private Vector3 dir;
    private PlayerCollision coll;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<PlayerCollision>();
        theCamera = Camera.main;
        applyForce = moveForce;
        originPosY = theCamera.transform.localPosition.y;
        applyCrouchPosY = originPosY;
    }

    // Update is called once per frame
    void Update()
    {
        IsGruond();
        Interaction();
        //inputManager();
        TryJump();
        TryCroush();
        TryRun();

        Move();
        CharacterRotation();
        CameraRotation();

    }

    private void Initialized()
    {
        
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
        float time = 0f;
        time += Time.deltaTime;

        if (time > 0.2f)
        {
            //AudioManager.Instance.PlaySound("Walk");
            time = 0f;
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && isGruond)
        {
            Jump();
        }
    }
    private void IsGruond()
    {
        isGruond = Physics.Raycast(transform.position, Vector3.down, 5f, GruondLayer);
    }

    private void TryCroush()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }

    public void Crouch()
    {
        isCrouch = !isCrouch;

        if (isCrouch)
        {
            applyForce = crouchForce;
            applyCrouchPosY = crouchPosY;
        }
        else
        {
            applyForce = moveForce;
            applyCrouchPosY = originPosY;
        }

        StartCoroutine(CrouchCoroutine());
    }

    IEnumerator CrouchCoroutine()
    {
        float _posY = theCamera.transform.localPosition.y;
        int count = 0;

        Debug.Log(_posY);
        while(_posY != applyCrouchPosY)
        {
            count++;
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);
            if (count > 15)
                break;

            yield return null;
        }

        theCamera.transform.localPosition = new Vector3(0f, applyCrouchPosY, 0f);
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
        AudioManager.Instance.PlaySound("Jump");
    }
    private void Running()
    {

        applyForce = runForce;
    }

    private void RunningCancle()
    {
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

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
    #endregion

    private void Interaction()
    {

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Don't ineraction touch");
            Debug.DrawRay(transform.position,transform.forward,Color.red,100f);
            if (Physics.Raycast(transform.position, transform.forward, out ray, rayLength, interactionObject))
            {
                Debug.Log("touch");
                Debug.Log(ray.collider.name);
                interObject = ray.collider.gameObject;
                interObject.GetComponent<InterObject>().Action();
            }
        }
        else
        {
            if (interObject != null)
            {
                Debug.Log("Don't touch");
                interObject.GetComponent<InterObject>().StopAction();
                interObject = null;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
  
        if (other.tag == "Item")
        {
            Debug.Log("get Item");
        }

    }
}
