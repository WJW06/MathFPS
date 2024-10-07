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
        // �̵� ���� = �÷��̾��� ȸ�� �� * ���� ��
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        // �̵� �� = �̵����� * �ӵ�
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
