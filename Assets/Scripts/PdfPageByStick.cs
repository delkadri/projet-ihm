using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PdfPageByButtons : MonoBehaviour
{
    [SerializeField] private MonoBehaviour pdfViewerUI;
    [SerializeField] private XRGrabInteractable grab; // pour n'activer que quand tenu

    [SerializeField] private InputActionProperty nextAction; // Button
    [SerializeField] private InputActionProperty prevAction; // Button

    private bool held;

    private void OnEnable()
    {
        nextAction.action?.Enable();
        prevAction.action?.Enable();

        if (grab != null)
        {
            grab.selectEntered.AddListener(_ => held = true);
            grab.selectExited.AddListener(_ => held = false);
        }
    }

    private void OnDisable()
    {
        nextAction.action?.Disable();
        prevAction.action?.Disable();
    }

    private void Update()
    {
        if (!held || pdfViewerUI == null) return;

        if (nextAction.action != null && nextAction.action.WasPressedThisFrame())
            pdfViewerUI.SendMessage("NextPage", SendMessageOptions.RequireReceiver);

        if (prevAction.action != null && prevAction.action.WasPressedThisFrame())
            pdfViewerUI.SendMessage("PreviousPage", SendMessageOptions.RequireReceiver);
    }
}
