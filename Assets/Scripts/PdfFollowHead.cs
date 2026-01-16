using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PdfTabletFollowHeadWhenHeld : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grab;
    [SerializeField] private Transform head; // Main Camera
    [SerializeField] private Vector3 localOffset = new Vector3(0f, -0.25f, 0.55f);
    [SerializeField] private Vector3 localEuler = new Vector3(10f, 0f, 0f);

    private bool held;

    private void Reset()
    {
        grab = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        if (grab != null)
        {
            grab.selectEntered.AddListener(_ => held = true);
            grab.selectExited.AddListener(_ => held = false);
        }
    }

    private void OnDisable()
    {
        if (grab != null)
        {
            grab.selectEntered.RemoveAllListeners();
            grab.selectExited.RemoveAllListeners();
        }
    }

    private void LateUpdate()
    {
        if (!held || head == null) return;

        transform.position = head.TransformPoint(localOffset);
        transform.rotation = head.rotation * Quaternion.Euler(localEuler);
    }
}
