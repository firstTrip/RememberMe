using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region 변수

    [Header("이동 속도")]
    [SerializeField] private float moveForce;
    [SerializeField] private float applyForce;
    [SerializeField] private float runForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float crouchForce;

    [Space]
    [Header("HP")]
    [Tooltip("HP")][SerializeField] private float HP;

    [Space]
    [Header("물건 인식 길이:")]
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
    [SerializeField] private LayerMask grabObject;
    [SerializeField] private LayerMask gruondLayer;


    [Space]
    [Header("카메라 민감도")]
    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit = 60f;
    private float currentCameraRotationX = 0;

    [Space]
    [SerializeField] [Tooltip("땅이야?")] private bool isGruond;


    [SerializeField] private GameObject hasItem;
    [SerializeField] private GameObject itmePoint;
 
    [Space]
    private GameObject interObject;
    private RaycastHit ray;
    private bool isCrouch;

    #endregion

    #region Component

    private Rigidbody rb;
    [SerializeField] private Camera theCamera;

    #endregion

    #region Start
    private void Start()
    {
        Initialized();
    }
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        IsGruond();
        Interaction();
        //inputManager();
        TryTalk();
        TryGrab();
        TryJump();
        TryCroush();
        TryRun();


        Move();

        if (!UIManager.Instance.isAction)
        {
            CharacterRotation();
            CameraRotation();
        }
        

    }

    #endregion 

    #region Initialized
    private void Initialized()
    {
        rb = GetComponent<Rigidbody>();
        theCamera = Camera.main;
        applyForce = moveForce;
        originPosY = theCamera.transform.localPosition.y;
        applyCrouchPosY = originPosY;

    }
    #endregion

    #region Move
    private void Move()
    {

        float _moveDirX = UIManager.Instance.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        float _moveDirZ = UIManager.Instance.isAction ? 0 : Input.GetAxisRaw("Vertical");

        
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
    #endregion

    #region Try Func
    private void TryGrab()
    {
       
        if (Input.GetMouseButton(0))
        {
            Grab();
        }

        if (Input.GetMouseButtonUp(0))
        {
            CancleGrab();
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Grab();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            CancleGrab();
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
    private void TryCroush()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }


    private void TryTalk()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            UIManager.Instance.Action();
        }
    }
    #endregion

    #region action

    public void GetDamage(float Damage)
    {
        HP -= Damage;

        if(HP == 0)
        {
            Debug.Log("Death");
        }
    }

    private void Grab()
    {
        Debug.DrawRay(transform.position, theCamera.transform.forward, Color.blue, 100f);
        if (Physics.Raycast(transform.position, theCamera.transform.forward, out ray, rayLength, grabObject))
        {
            Debug.Log("Grab");
            Debug.Log(ray.collider.name);
            hasItem = ray.collider.gameObject;
            SetEquip(hasItem, true);
            hasItem.GetComponent<GrabObject>().Action();
        }
    }

    private void CancleGrab()
    {
        if(hasItem != null)
        {
            Debug.Log("Cancle");
            SetEquip(hasItem, false);
            hasItem.GetComponent<GrabObject>().DisAction();
            hasItem = null;
        }
     
    }

    private void SetEquip(GameObject item, bool isEquip)
    {
        Collider[] itemColliders = item.GetComponents<Collider>();
        Rigidbody itemRigidody = item.GetComponent<Rigidbody>();

        foreach (Collider itemCollider in itemColliders)
        {
            itemCollider.enabled = !isEquip;
        }

        itemRigidody.isKinematic = isEquip;
    }

    private void IsGruond()
    {
        isGruond = Physics.Raycast(transform.position, Vector3.down, 5f, gruondLayer);
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

    #region Interaction
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
    #endregion

    #region OnTrigger
    private void OnTriggerStay(Collider other)
    {
  
        if (other.tag == "Item")
        {
            Debug.Log("get Item");
        }

    }

    #endregion
}
