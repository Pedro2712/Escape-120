using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PasswordJoystick : MonoBehaviour
{
    public XRJoystick joystick;
    public Animator animator;

    private List<string> movements = new List<string>();
    private bool isJoystickInExtremePosition = false;
    public List<string> Password = new List<string>();

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
        AudioManager.instance.Play("JoyStick");
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

    public void Validated()
    {
        if (AreListsEqual(movements, Password))
        {
            animator.SetBool("Open", true);
            AudioManager.instance.Play("Door");
            AudioManager.instance.Play("Welcome");
        }
        else
        {
            animator.SetBool("Open", false);
            AudioManager.instance.Play("IncorrectPassword");
        }

        // Zera a lista movements
        movements.Clear();
    }

    private bool AreListsEqual(List<string> list1, List<string> list2)
    {
        // Verifica se as listas têm o mesmo tamanho
        if (list1.Count != list2.Count)
            return false;

        // Verifica se os elementos nas posições correspondentes são iguais
        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }

        return true;
    }
}
