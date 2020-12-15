using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
    // x = 0 / y = 25 / z = -10

    #region Member Variables

    public Transform target;
    private const float SMOOTH_SPEED = 0.125f;
    public Vector3 offset;

    #endregion

    #region Methods

    private void Start()
    {
        offset = new Vector3(0, 15, -10);
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogException(new Exception("Target == null"));
            return;
        }
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SMOOTH_SPEED);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    #endregion
}
