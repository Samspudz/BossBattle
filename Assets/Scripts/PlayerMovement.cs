using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float jumpForce = 8.0f;
    public float turnSpeed = 0.15f;
    [SerializeField] private bool facingRight;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool canShoot;

    public Transform groundCheck;
    public LayerMask thisIsGround;
    Collider[] groundCol;

    private Rigidbody rBody;
    private Vector2 moveInput;

    KnightInput kInput;
    PlayerShoot pShoot;

    private void Awake()
    {
        kInput = new KnightInput();
        facingRight = true;
        canShoot = true;
    }

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        pShoot = GetComponent<PlayerShoot>();
    }

    private void OnEnable()
    {
        kInput.Enable();
    }

    private void OnDisable()
    {
        kInput.Disable();
    }

    void Update()
    {
        groundCol = Physics.OverlapSphere(groundCheck.position, 0.2f, thisIsGround);
        if (groundCol.Length > 0)
            isGrounded = true;
        else
            isGrounded = false;

        moveInput.x = kInput.Player.Move.ReadValue<Vector2>().x;

        if (kInput.Player.Jump.triggered && isGrounded)
            PlayerJump();

        if (kInput.Player.Shoot.triggered && canShoot)
        {
            pShoot.PlayerShot();
            StartCoroutine(ShotTime());
        }

        if (moveInput.x > 0 && !facingRight)
            PlayerTurn();

        if (moveInput.x < 0 && facingRight)
            PlayerTurn();
    }

    private void FixedUpdate()
    {
        rBody.MovePosition(transform.position + new Vector3(moveInput.x, 0, 0) * moveSpeed * Time.fixedDeltaTime);
    }

    void PlayerJump()
    {
        rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void PlayerTurn()
    {
        facingRight = !facingRight;

        if (facingRight)
            transform.DORotate(Vector3.up * 0f, turnSpeed, RotateMode.Fast);
        else
            transform.DORotate(Vector3.up * 180f, turnSpeed, RotateMode.Fast);
    }

    IEnumerator ShotTime()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
