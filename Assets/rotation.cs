using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotationSpeed = 45f; // Velocidade de rotação em graus por segundo

    void Update()
    {
        // Verifica se alguma tecla é pressionada (pode ser alterado para outro evento)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Inicia a rotação gradual
            StartCoroutine(RotateOverTime());
        }
    }

    IEnumerator RotateOverTime()
    {
        float elapsedRotationTime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);

        while (elapsedRotationTime < 1f)
        {
            // Interpolação linear para suavizar a rotação ao longo do tempo
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedRotationTime);
            elapsedRotationTime += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        // Garante que a rotação final seja exatamente a desejada
        transform.rotation = targetRotation;
    }
}
