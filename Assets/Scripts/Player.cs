using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    KeyCode keyCodeRun = KeyCode.LeftShift;
    [SerializeField]
    KeyCode keyCodeJump = KeyCode.Space;

    [Header("Audio Clips")]
    [SerializeField]
    AudioClip[] audioClip;

    RotateToMouse rotateToMouse; // 마우스 회전 컴포넌트
    MovementPlayerController movement; // 플레이어 키보드 입력
    Status status; // 플레이어 정보
    AudioSource audioSource;


    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotateToMouse = GetComponent<RotateToMouse>();
        movement = gameObject.GetComponent<MovementPlayerController>();
        status = gameObject.GetComponent<Status>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateRotate();
        UpdateMove();
        UpdateJump();
    }
    
    void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0 || z != 0)
        {
            bool isRun = false;
            if (z > 0) isRun = Input.GetKey(keyCodeRun);

            movement.MoveSpeed = isRun ? status.RunSpeed : status.WalkSpeed;
            audioSource.clip = audioClip[0];
            audioSource.pitch = isRun ?  1.1f : 1f;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            Debug.Log(audioSource.isPlaying);
        }
        else
        {
            movement.MoveSpeed = 0;
            if (audioSource.isPlaying) audioSource.Stop();
        }

        movement.MoveTo(new Vector3(x, 0, z));
    }

    void UpdateJump()
    {
        if (Input.GetKeyDown(keyCodeJump))
        {
            movement.Jump();
        }
    }
}
