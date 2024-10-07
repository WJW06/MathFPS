using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField]
    float rotCamXAxisSpeed = 5; // ī�޶� x�� ȸ���ӵ�
    [SerializeField]
    float rotCamYAxisSpeed = 3; // ī�޶� y�� ȸ���ӵ�
    float limitMinX = -80; // ī�޶� x�� ȸ�� �ּҹ���
    float limitMaxX = 50; // ī�޶� x�� ȸ�� �ּҹ���
    float eulerAngleX, eulerAngleY; // ���Ϸ� ���� X,Y


    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed; // ��/�� ���콺 -> y�� ȸ��
        eulerAngleX += mouseY * rotCamXAxisSpeed; // ��/�� ���콺 -> x�� ȸ��

        // ī�޶� x�� ȸ�� ���� ����
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(-eulerAngleX, eulerAngleY, 0);
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle >  360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
