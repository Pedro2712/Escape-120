using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class PasswordLever : MonoBehaviour
{
    public Animator animator;
    public List<XRLever> lever = new List<XRLever>();
    private List<bool> booleanList = new List<bool>();

    // Start is called before the first frame update
    void Start()
    {
        // Adiciona valores booleanos à lista
        booleanList.Add(true);
        booleanList.Add(true);
        booleanList.Add(false);

        booleanList.Add(false);
        booleanList.Add(true);
        booleanList.Add(false);
    }

    // Método para verificar se a lista de alavancas é igual à lista de booleanos
    public void CheckPassword()
    {
        // Verifica se o tamanho das listas é o mesmo
        if (lever.Count == booleanList.Count)
        {
            bool passwordsMatch = true;

            // Loop para comparar os valores das alavancas com os valores booleanos
            for (int i = 0; i < lever.Count; i++)
            {
                bool leverValue = lever[i].value; // Suponha que existe um método IsLeverActivated() em XRLever para obter o valor da alavanca.
                bool booleanValue = booleanList[i];

                if (leverValue != booleanValue)
                {
                    passwordsMatch = false;
                    break; // Se encontrar uma diferença, não é necessário continuar o loop
                }
            }

            // Verifica se as senhas coincidem
            if (passwordsMatch)
            {
                animator.SetBool("Open", true);
            }
            else
            {
                animator.SetBool("Open", false);
            }
        }
        else
        {
            Debug.LogWarning("As listas têm tamanhos diferentes.");
        }
    }
}
