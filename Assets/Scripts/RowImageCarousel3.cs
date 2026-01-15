using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowImageCarousel3 : MonoBehaviour
{
    [Header("Slots visibles (3)")]
    [SerializeField] private Image slot1;
    [SerializeField] private Image slot2;
    [SerializeField] private Image slot3;

    [Header("Buttons")]
    [SerializeField] private Button btnLeft;
    [SerializeField] private Button btnRight;

    [Header("Images (Sprites)")]
    [SerializeField] private List<Sprite> images = new List<Sprite>();

    private int startIndex = 0;

    private void Awake()
    {
        if (btnLeft) btnLeft.onClick.AddListener(Prev);
        if (btnRight) btnRight.onClick.AddListener(Next);
        Refresh();
    }

    private void Prev()
    {
        if (images.Count == 0) return;
        startIndex -= 1;
        if (startIndex < 0) startIndex = images.Count - 1;
        Refresh();
    }

    private void Next()
    {
        if (images.Count == 0) return;
        startIndex += 1;
        if (startIndex >= images.Count) startIndex = 0;
        Refresh();
    }

    private void Refresh()
    {
        SetSlot(slot1, GetWrapped(startIndex));
        SetSlot(slot2, GetWrapped(startIndex + 1));
        SetSlot(slot3, GetWrapped(startIndex + 2));

        bool canScroll = images.Count > 3;
        if (btnLeft) btnLeft.interactable = canScroll;
        if (btnRight) btnRight.interactable = canScroll;
    }

    private Sprite GetWrapped(int index)
    {
        if (images.Count == 0) return null;
        int i = index % images.Count;
        if (i < 0) i += images.Count;
        return images[i];
    }

    private void SetSlot(Image slot, Sprite sprite)
    {
        if (!slot) return;

        slot.sprite = sprite;
        slot.enabled = (sprite != null);
    }

    // Optionnel: si tu veux changer la liste depuis un autre script plus tard
    public void SetImages(List<Sprite> newImages)
    {
        images = newImages ?? new List<Sprite>();
        startIndex = 0;
        Refresh();
    }
}
