using UnityEngine;

public class PdfAutoLoad : MonoBehaviour
{
    [Header("Drag ici le composant du package (Pdf Viewer UI)")]
    [SerializeField] private MonoBehaviour pdfViewerUI;

    [Header("Chemin relatif dans StreamingAssets")]
    [Tooltip("Ex: document.pdf ou PDF/document.pdf")]
    [SerializeField] private string pdfPathInStreamingAssets = "document.pdf";

    [SerializeField] private bool loadOnStart = true;

    private void Start()
    {
        if (!loadOnStart) return;

        if (pdfViewerUI == null)
        {
            Debug.LogError("PdfAutoLoad: assigne le composant 'Pdf Viewer UI (Script)' dans Pdf Viewer UI.");
            return;
        }

        if (string.IsNullOrWhiteSpace(pdfPathInStreamingAssets))
        {
            Debug.LogError("PdfAutoLoad: renseigne pdfPathInStreamingAssets (ex: document.pdf).");
            return;
        }

        // Appelle LoadPDF(string) sur le composant du package
        pdfViewerUI.SendMessage("LoadPDF", pdfPathInStreamingAssets, SendMessageOptions.RequireReceiver);
    }
}
