using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float rotateSensitivity = 3;
    public float sprintSpeed = 6;
    public float walkSpeed = 3;
    public float jumpForce = 350;
    public bool grounded;
    public GameObject cameraHolder;

    private float verticalLookRotation;
    private Rigidbody rigidbody;
    private Vector3 moveDirection;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();    
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Look();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Look()
    {
        //把輸入的值傳給遊戲腳色
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * rotateSensitivity);
        //計算滑鼠Y軸位移量
        verticalLookRotation += Input.GetAxis("Mouse Y") * rotateSensitivity;

        //設定最小及最大仰角
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        //把輸入的值傳給Camera的父物件
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Move()
    {
        //讓斜著走的時候是0.5+0.5而不是1+1
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveDirection * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed) * Time.fixedDeltaTime));
    }
    void Jump()
    {
        if (!grounded)
            return;
        rigidbody.AddForce(transform.up * jumpForce);
    }
}
