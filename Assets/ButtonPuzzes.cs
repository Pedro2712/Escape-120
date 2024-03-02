using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ButtonPuzzes : MonoBehaviour
{
    public List<XRPushButton> PushButtons = new List<XRPushButton>();
    public float novaAltura = -0.035f;

    // Update is called once per frame
    void Update()
    {
        if (PushButtons != null && PushButtons.Count > 0)
        {
            // Verifica se a tecla de espaço foi pressionada
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Define a altura desejada para a subida do botão
                float alturaInicial = 0.0f;  // Defina a altura inicial aqui
                PushButtons[0].SetButtonHeight(alturaInicial);
            }
            else
            {
                // Define a altura desejada para manter o botão pressionado
                PushButtons[0].SetButtonHeight(novaAltura);
            }
        }
    }
}
