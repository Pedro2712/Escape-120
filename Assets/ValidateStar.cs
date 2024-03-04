using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ValidateStar : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;

    public static event System.Action<bool> OnSpherePlacementChanged;

    private void Start()
    {
        socketInteractor.selectEntered.AddListener(OnSelectEntered);
        socketInteractor.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        OnSpherePlacementChanged?.Invoke(true);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        OnSpherePlacementChanged?.Invoke(false);
    }
}