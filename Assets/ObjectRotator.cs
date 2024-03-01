using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour
{
    private int correctPlacements = 0;
    public float rotationSpeed = 45f;
    public int numberOfCubesToCheck = 3;

    public AudioSource audioSource;
    public AudioClip rotationSound;

    public Camera rotationCamera;

    private void Awake()
    {
        if (rotationCamera != null)
        {
            rotationCamera.depth = -1; // Ative a câmera quando a rotação começar
        }
    }

    private void OnEnable()
    {
        ValidateCubeOnAnalyzer.OnCubePlacementChanged += HandleCubePlacementChange;
    }

    private void OnDisable()
    {
        ValidateCubeOnAnalyzer.OnCubePlacementChanged -= HandleCubePlacementChange;
    }

    private void HandleCubePlacementChange(bool placedCorrectly)
    {
        if (placedCorrectly)
        {
            correctPlacements++;
        }
        else
        {
            correctPlacements--;
            correctPlacements = Mathf.Max(0, correctPlacements);
        }

        if (correctPlacements == numberOfCubesToCheck)
        {
            StartCoroutine(RotateOverTime());
        }
     
    }

    IEnumerator RotateOverTime()
    {
        if (rotationCamera != null)
        {
            rotationCamera.depth = 100; // Ative a câmera quando a rotação começar
            yield return new WaitForSeconds(0.5f);
        }
        PlayRotationSound();
        float elapsedRotationTime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);

        while (elapsedRotationTime < 1f)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedRotationTime);
            elapsedRotationTime += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        transform.rotation = targetRotation;

        if (rotationCamera != null)
        {
            yield return new WaitForSeconds(1.0f);
            rotationCamera.depth = -1; // Ative a câmera quando a rotação começar
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RotateOverTime());
        }
    }

    private void PlayRotationSound()
    {
        if (audioSource != null && rotationSound != null)
        {
            audioSource.PlayOneShot(rotationSound);
        }
    }

}
