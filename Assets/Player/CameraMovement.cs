using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform PlayerTransform;
    public Vector3 CameraBuffer;
    private Transform CameraTransform;

    void Update()
    {
        if (PlayerTransform != null)
        {
            CameraTransform.position = PlayerTransform.position + CameraBuffer;
        }
    }

    private void Start()
    {
        CameraTransform = GetComponent<Transform>();
    }
}