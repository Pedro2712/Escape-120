using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ValidateCubeOnAnalyzer : MonoBehaviour
{
    public GameObject correctCube;
    public XRSocketInteractor socketInteractor;

    private bool lastCubeWasCorrect = false;

    public static event System.Action<bool> OnCubePlacementChanged;

    private void Start()
    {
        socketInteractor.selectEntered.AddListener(OnSelectEntered);
        socketInteractor.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactable.gameObject == correctCube)
        {
            lastCubeWasCorrect = true;
            OnCubePlacementChanged?.Invoke(true);
        }
        else
        {
            lastCubeWasCorrect = false;
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // If the removed cube was the correct one, notify the change
        if (lastCubeWasCorrect)
        {
            OnCubePlacementChanged?.Invoke(false);
            lastCubeWasCorrect = false; // Reset the flag
        }
    }
}
