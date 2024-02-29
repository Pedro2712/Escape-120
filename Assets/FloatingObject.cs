using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatSpeed = 0.5f;    // Velocidade de flutua��o
    public float floatHeight = 0.1f;   // Altura m�xima da flutua��o
    public float rotationSpeed = 30f;  // Velocidade de rota��o em graus por segundo

    private float initialYPosition;

    void Start()
    {
        // Salva a posi��o inicial do objeto
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        // Calcula o deslocamento vertical com base no tempo
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Calcula a nova posi��o Y com base na flutua��o, mantendo-se acima da posi��o inicial
        float newYPosition = initialYPosition + yOffset;

        // Calcula o deslocamento angular com base no tempo
        float rotationOffset = Mathf.Sin(Time.time * floatSpeed) * rotationSpeed;

        // Aplica o movimento ao objeto
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        transform.rotation = Quaternion.Euler(0f, rotationOffset, 0f);
    }
}
