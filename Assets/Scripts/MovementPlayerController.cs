using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementPlayerController : MonoBehaviour
{
    CharacterController playerController;
    Vector3 moveForce;
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpForce;
    [SerializeField]
    float gravity;


    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }

    void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!playerController.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }

        playerController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        // 이동 방향 = 플레이어의 회전 값 * 방향 값
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        // 이동 힘 = 이동방향 * 속도
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        if (playerController.isGrounded)
        {
            moveForce.y = jumpForce;
        }
    }
}
