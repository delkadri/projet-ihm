using UnityEngine;

public class BillboardToCamera : MonoBehaviour
{
    public Transform targetCamera;

    void LateUpdate()
    {
        if (!targetCamera) return;

        Vector3 dir = transform.position - targetCamera.position;
        dir.y = 0f;
        if (dir.sqrMagnitude < 0.0001f) return;

        transform.rotation = Quaternion.LookRotation(dir);
    }
}
