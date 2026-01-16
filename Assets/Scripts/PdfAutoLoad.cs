using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class PdfAutoLoad : MonoBehaviour
{
    [SerializeField] private MonoBehaviour pdfViewerUI; // composant Pdf Viewer UI (du package)
    [Tooltip("Chemin relatif dans StreamingAssets. Ex: document.pdf ou PDF/document.pdf")]
    [SerializeField] private string pdfPathInStreamingAssets = "document.pdf";

    private void Start()
    {
        if (pdfViewerUI == null)
        {
            Debug.LogError("PdfAutoLoad: assigne le composant 'Pdf Viewer UI (Script)' dans pdfViewerUI.");
            return;
        }

        if (string.IsNullOrWhiteSpace(pdfPathInStreamingAssets))
        {
            Debug.LogError("PdfAutoLoad: renseigne pdfPathInStreamingAssets (ex: document.pdf).");
            return;
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        StartCoroutine(CopyAndLoadFromPersistent());
#else
        // Editor / PC : StreamingAssets est un vrai fichier, on charge direct
        pdfViewerUI.SendMessage("LoadPDF", pdfPathInStreamingAssets, SendMessageOptions.RequireReceiver);
#endif
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private IEnumerator CopyAndLoadFromPersistent()
    {
        // Source dans StreamingAssets (dans l'APK => accès via UnityWebRequest)
        string src = Path.Combine(Application.streamingAssetsPath, pdfPathInStreamingAssets);

        using (UnityWebRequest www = UnityWebRequest.Get(src))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"PdfAutoLoad: impossible de lire StreamingAssets: {src}\n{www.error}");
                yield break;
            }

            // Destination locale lisible par File IO
            string dst = Path.Combine(Application.persistentDataPath, pdfPathInStreamingAssets);
            string dstDir = Path.GetDirectoryName(dst);
            if (!string.IsNullOrEmpty(dstDir)) Directory.CreateDirectory(dstDir);

            File.WriteAllBytes(dst, www.downloadHandler.data);

            // IMPORTANT : selon la lib, LoadPDF peut accepter un chemin complet.
            // On tente d'abord le chemin complet (le plus logique).
            try
            {
                pdfViewerUI.SendMessage("LoadPDF", dst, SendMessageOptions.RequireReceiver);
            }
            catch
            {
                // Fallback: si la lib n'accepte que "nom relatif", essaie juste le nom
                pdfViewerUI.SendMessage("LoadPDF", pdfPathInStreamingAssets, SendMessageOptions.RequireReceiver);
            }
        }
    }
#endif
}
