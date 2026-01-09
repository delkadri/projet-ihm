using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CarDocsPanelSpawner : MonoBehaviour
{
    [Header("XR")]
    [SerializeField] private XRRayInteractor rightRay;

    [Header("UI")]
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private Transform xrCamera;

    private CarInfo currentCar;
    private GameObject currentPanel;

    private void OnEnable()
    {
        rightRay.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        rightRay.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        var car = args.interactableObject.transform.GetComponentInParent<CarInfo>();
        if (car == null || panelPrefab == null) return;

        if (currentCar == car && currentPanel != null)
        {
            currentPanel.SetActive(!currentPanel.activeSelf);
            return;
        }

        currentCar = car;

        if (currentPanel == null)
        {
            currentPanel = Instantiate(panelPrefab);
            var bb = currentPanel.GetComponent<BillboardToCamera>();
            if (bb != null) bb.targetCamera = xrCamera;
        }

        PositionPanelAboveCar(currentPanel.transform, car);
        currentPanel.SetActive(true);
    }

    private void PositionPanelAboveCar(Transform panelTr, CarInfo car)
    {
        Bounds b = car.GetWorldBounds();
        Vector3 pos = new Vector3(b.center.x, b.max.y, b.center.z);

        panelTr.position = pos + Vector3.up * car.heightOffset;
        panelTr.SetParent(car.transform, true);
    }
}
