using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    public string targetTag;
    private bool isObjectSelected = false;
    public float moveSpeed = 0.5f;
    public float moveDistance = 0.2f;
    private Vector3 initialObjectPosition;

    public float floatSpeed = 0.5f;    // Velocidade de flutuação
    public float floatHeight = 0.1f;   // Altura máxima da flutuação
    public float rotationSpeed = 30f;  // Velocidade de rotação em graus por segundo

    private float initialYPosition;

    private bool isCorrect = false;

    void Start()
    {
        // Salva a posição inicial do objeto
        initialObjectPosition = transform.position;
        initialYPosition = transform.position.y;
        isCorrect= false;
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && interactable.transform.tag == targetTag;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.tag == targetTag;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Verifica se o objeto selecionado possui a tag desejada
        if (args.interactableObject.transform.tag == targetTag)
        {
            isObjectSelected = true;
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        // Reseta a flag quando o objeto é desselecionado
        isObjectSelected = false;
    }

    void Update()
    {
        // Move o objeto para cima e para baixo se estiver selecionado
        if (isObjectSelected)
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

    private void OnTriggerEnter(Collider other)
    {
        
    }

    //public bool get_isCorrect() { 
    //    
    //}
}
