using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] CameraRotateTouchPanel playerRotateTouchPanel;

    [SerializeField] float sensitivity = 0.2f;
    [SerializeField] float sensitivityPanelRotate = 0.5f;
    [SerializeField] float maxXAngle = 90.0f;

    private float rotationX;
    private float rotationY;
    private void Start()
    {
        rotationX = transform.rotation.eulerAngles.x;
        rotationY = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        float directionX = 0;
        float directionY = 0;

        if (playerRotateTouchPanel.pressed)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == playerRotateTouchPanel.fingerId)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        directionY = touch.deltaPosition.y * sensitivityPanelRotate;
                        directionX = touch.deltaPosition.x * sensitivityPanelRotate;
                    }

                    if (touch.phase == TouchPhase.Stationary)
                    {
                        directionY = 0;
                        directionX = 0;
                    }
                }
            }
        }

        rotationX -= directionY * sensitivity;
        rotationY += directionX * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -maxXAngle, maxXAngle);
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
    }
}