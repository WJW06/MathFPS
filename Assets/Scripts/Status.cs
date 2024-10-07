using UnityEngine;

public class Status : MonoBehaviour
{
    [Header("Walk, Run Speed")]
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float runSpeed;
    public float WalkSpeed => walkSpeed;
    public float RunSpeed => runSpeed;
}
