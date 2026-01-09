using UnityEngine;

public class CarInfo : MonoBehaviour
{
    [Header("Panel placement")]
    public float heightOffset = 0.35f;
    public float forwardOffset = 0.0f;

    public Transform anchorOverride;

    public Bounds GetWorldBounds()
    {
        var renderers = GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return new Bounds(transform.position, Vector3.one);

        Bounds b = renderers[0].bounds;
        for (int i = 1; i < renderers.Length; i++) b.Encapsulate(renderers[i].bounds);
        return b;
    }
}
