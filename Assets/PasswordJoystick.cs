using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PasswordJoystick : MonoBehaviour
{
    public XRJoystick joystick;

    private List<string> movements = new List<string>();
    private bool isJoystickInExtremePosition = false;

    // Update is called once per frame
    void Update()
    {
        float horizontalValue = joystick.value.x;
        float verticalValue = joystick.value.y;

        // Verifica se o joystick está em uma posição extrema
        bool isJoystickExtreme = Mathf.Abs(horizontalValue) >= 0.9f || Mathf.Abs(verticalValue) >= 0.9f;

        // Se houve uma transição para uma posição extrema
        if (isJoystickExtreme && !isJoystickInExtremePosition)
        {
            string movementDirection = GetMovementDirection(horizontalValue, verticalValue);
            movements.Add(movementDirection);

            // Exibe a lista no console (apenas para fins de teste)
            //Debug.Log("Movements: " + string.Join(", ", movements));
        }

        // Atualiza o estado do joystick
        isJoystickInExtremePosition = isJoystickExtreme;
    }

    private string GetMovementDirection(float horizontal, float vertical)
    {
        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            // Movimento horizontal mais significativo
            return horizontal > 0 ? "Direita" : "Esquerda";
        }
        else
        {
            // Movimento vertical mais significativo
            return vertical > 0 ? "Cima" : "Baixo";
        }
    }

    public void Validated() {
        print("Entrou");
    }
}
