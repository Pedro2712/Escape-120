using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.Events;

public class ButtonPuzzles : MonoBehaviour
{
    public List<XRPushButton> PushButtons = new List<XRPushButton>();
    public List<int> PressedNumbers = new List<int>();
    private List<bool> IsCorrectButton = new List<bool>(new bool[6]);
    private List<int> countIntern = new List<int>(new int[6]);
    public float novaAltura = -0.035f;

    private void Start()
    {
        // Verifica se todas as listas têm o mesmo tamanho
        if (PushButtons.Count != PressedNumbers.Count || PushButtons.Count != IsCorrectButton.Count)
        {
            Debug.LogWarning("As listas estão com tamanhos diferentes.");
        }
    }

    void Update()
    {
        HoldButton();
    }

    public void CountPressed(XRPushButton callingButton)
    {
        if (PushButtons.Contains(callingButton))
        {
            int buttonIndex = PushButtons.IndexOf(callingButton);

            if (AreAllElementsTrueUntilIndex(buttonIndex))
            {
                countIntern[buttonIndex]++;
                ValideNumbers(buttonIndex);
                HoldButton();
            }
            else
            {
                IncorrectPassword();
            }
        }
    }

    private void ValideNumbers(int index)
    {

        if (countIntern[index] == PressedNumbers[index])
        {
            IsCorrectButton[index] = true;
            HoldButton();
        }
        else if (countIntern[index] > PressedNumbers[index]) {
            IncorrectPassword();
        }
    }

    private void HoldButton()
    {
        for (int i = 0; i < IsCorrectButton.Count; i++)
        {
            if (IsCorrectButton[i])
            {
                PushButtons[i].SetButtonHeight(novaAltura);
            }
        }
    }

    private void IncorrectPassword()
    {
        for (int i = 0; i < IsCorrectButton.Count; i++)
        {
            PushButtons[i].SetButtonHeight(0.0f);
            IsCorrectButton[i] = false;
            countIntern[i] = 0;
        }
    }

    private bool AreAllElementsTrueUntilIndex(int endIndex)
    {
        if (IsCorrectButton == null || IsCorrectButton.Count == 0 || endIndex >= IsCorrectButton.Count)
        {
            Debug.LogWarning("Lista de booleanos inválida ou índice fora dos limites.");
            return false;
        }

        for (int i = 0; i < endIndex; i++)
        {
            if (!IsCorrectButton[i])
            {
                return false;
            }
        }

        return true;
    }
}