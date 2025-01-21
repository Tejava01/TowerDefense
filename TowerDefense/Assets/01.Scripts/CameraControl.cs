using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private float MoveRate;
    [SerializeField] private float LeftX;
    [SerializeField] private float RightX;

    private Vector3 m_camPosition;
    private Vector3 m_clickPosition;

    //-----------------------------------------------------------------

    private void Update()
    {
        PrivMoveCamera();
    }

    //-----------------------------------------------------------------

    private void PrivMoveCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_clickPosition = Input.mousePosition;
            m_camPosition = Camera.transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 movePosition = Camera.main.ScreenToViewportPoint(m_clickPosition - Input.mousePosition);
            Vector3 newPosition = m_camPosition + (movePosition * MoveRate);
            if (newPosition.x <= LeftX || newPosition.x >= RightX)
            {
                if (newPosition.x < 0)
                {
                    newPosition.x = LeftX;
                }
                else if (newPosition.x > 0)
                {
                    newPosition.x = RightX;
                }
            }
            Camera.transform.position = new Vector3(newPosition.x, m_camPosition.y, m_camPosition.z);
        }
    }
}
