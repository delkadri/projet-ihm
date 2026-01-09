using UnityEngine;

public enum DocumentType { Image, Video, Pdf, Ppt }

[CreateAssetMenu(menuName = "Docs/Document Data")]
public class DocumentData : ScriptableObject
{
    public string id;
    public string title;
    public DocumentType type;

    public Sprite thumbnail;     

    // Pour PDF/PPT convertis en images
    public PdfPageSet pageSet;
}
