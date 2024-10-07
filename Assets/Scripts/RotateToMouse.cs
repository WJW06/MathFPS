using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField]
    float rotCamXAxisSpeed = 5; // 카메라 x축 회전속도
    [SerializeField]
    float rotCamYAxisSpeed = 3; // 카메라 y축 회전속도
    float limitMinX = -80; // 카메라 x축 회전 최소범위
    float limitMaxX = 50; // 카메라 x축 회전 최소범위
    float eulerAngleX, eulerAngleY; // 오일러 각도 X,Y


    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed; // 좌/우 마우스 -> y축 회전
        eulerAngleX += mouseY * rotCamXAxisSpeed; // 상/하 마우스 -> x축 회전

        // 카메라 x축 회전 범위 설정
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
