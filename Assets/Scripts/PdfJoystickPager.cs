using UnityEngine;
using UnityEngine.InputSystem;

public class PdfJoystickPager : MonoBehaviour
{
    [Header("Référence au composant Pdf Viewer UI (du package)")]
    [SerializeField] private MonoBehaviour pdfViewerUI;

    [Header("Input System")]
    [Tooltip("Assigne l'action 'Stick' (Value/Vector2) du contrôleur droit ou gauche.")]
    [SerializeField] private InputActionProperty stickAction;

    [Header("Réglages")]
    [SerializeField] private float threshold = 0.7f;
    [SerializeField] private float repeatDelaySeconds = 0.35f;

    private float _nextAllowedTime;

    private void OnEnable()
    {
        if (stickAction.action != null) stickAction.action.Enable();
    }

    private void OnDisable()
    {
        if (stickAction.action != null) stickAction.action.Disable();
    }

    private void Update()
    {
        if (pdfViewerUI == null || stickAction.action == null) return;
        if (Time.unscaledTime < _nextAllowedTime) return;

        Vector2 v = stickAction.action.ReadValue<Vector2>();

        // Droite = page suivante, gauche = page précédente
        if (v.x > threshold)
        {
            pdfViewerUI.SendMessage("NextPage", SendMessageOptions.RequireReceiver);
            _nextAllowedTime = Time.unscaledTime + repeatDelaySeconds;
        }
        else if (v.x < -threshold)
        {
            pdfViewerUI.SendMessage("PreviousPage", SendMessageOptions.RequireReceiver);
            _nextAllowedTime = Time.unscaledTime + repeatDelaySeconds;
        }
    }
}
