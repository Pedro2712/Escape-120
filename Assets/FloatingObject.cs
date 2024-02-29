using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatSpeed = 0.5f;    // Velocidade de flutuação
    public float floatHeight = 0.1f;   // Altura máxima da flutuação
    public float rotationSpeed = 30f;  // Velocidade de rotação em graus por segundo

    private float initialYPosition;

    void Start()
    {
        // Salva a posição inicial do objeto
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        // Calcula o deslocamento vertical com base no tempo
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Calcula a nova posição Y com base na flutuação, mantendo-se acima da posição inicial
        float newYPosition = initialYPosition + yOffset;

        // Calcula o deslocamento angular com base no tempo
        float rotationOffset = Mathf.Sin(Time.time * floatSpeed) * rotationSpeed;

        // Aplica o movimento ao objeto
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        transform.rotation = Quaternion.Euler(0f, rotationOffset, 0f);
    }
}
