using UnityEngine;
using UnityEngine.InputSystem;

public class PdfPageByButtons_NoAsset : MonoBehaviour
{
    [Header("Référence au composant du package (Pdf Viewer UI)")]
    [SerializeField] private MonoBehaviour pdfViewerUI;

    [Header("Boutons OpenXR")]
    [Tooltip("Main droite: primaryButton")]
    [SerializeField] private bool useRightHand = true;

    [Tooltip("Ne change les pages que si l'objet est tenu (optionnel).")]
    [SerializeField] private bool requireHeld = false;

    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable grab;

    private InputAction nextAction;
    private InputAction prevAction;

    private void Awake()
    {
        string hand = useRightHand ? "{RightHand}" : "{LeftHand}";

        nextAction = new InputAction(
            name: "NextPage",
            type: InputActionType.Button,
            binding: $"<XRController>{hand}/primaryButton"
        );

        prevAction = new InputAction(
            name: "PrevPage",
            type: InputActionType.Button,
            binding: $"<XRController>{hand}/secondaryButton"
        );
    }

    private void OnEnable()
    {
        nextAction.Enable();
        prevAction.Enable();
    }

    private void OnDisable()
    {
        nextAction.Disable();
        prevAction.Disable();
    }

    private void Update()
    {
        if (pdfViewerUI == null) return;

        if (requireHeld && grab != null && !grab.isSelected) return;

        if (nextAction.WasPressedThisFrame())
            pdfViewerUI.SendMessage("NextPage", SendMessageOptions.RequireReceiver);

        if (prevAction.WasPressedThisFrame())
            pdfViewerUI.SendMessage("PreviousPage", SendMessageOptions.RequireReceiver);
    }
}
