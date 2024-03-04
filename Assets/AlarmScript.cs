using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmScript : MonoBehaviour
{
    private int correctPlacements = 0;
    public int numberOfSpheresToCheck = 2;
    private List<Light> alarmLights = new List<Light>();
    public float blinkInterval = 0.5f;
    private bool isAlarmActive = false;

    void Start()
    {
        // Encontrar automaticamente todas as luzes na cena
        Light[] lightsInScene = FindObjectsOfType<Light>();

        foreach (Light light in lightsInScene)
        {
            alarmLights.Add(light);
        }
    }

    private void OnEnable()
    {
        ValidateStar.OnSpherePlacementChanged += StartAlarm;
    }

    private void OnDisable()
    {
        ValidateStar.OnSpherePlacementChanged -= StartAlarm;
    }

    private void StartAlarm(bool placedCorrectly)
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

        if (correctPlacements == numberOfSpheresToCheck)
        {
            isAlarmActive = true;
        }

        StartCoroutine(AudioStart());
        StartCoroutine(BlinkLights());
    }

    IEnumerator AudioStart() {
        if (isAlarmActive)
        {
            AudioManager.instance.Stop("backgroundmusic");
            AudioManager.instance.Play("Destruction");
            AudioManager.instance.Play("Alarm");
            yield return new WaitForSeconds(3);
            AudioManager.instance.Play("minuteDestruction");
        }
        else
        {
            AudioManager.instance.Stop("Alarm");
            AudioManager.instance.Play("backgroundmusic");
        }
    }

    IEnumerator BlinkLights()
    {
        while (isAlarmActive)
        {
            // Ative todas as luzes e defina a cor para vermelho
            foreach (Light light in alarmLights)
            {
                light.color = Color.red;
            }

            yield return new WaitForSeconds(blinkInterval);

            // Desative todas as luzes e defina a cor para branco
            foreach (Light light in alarmLights)
            {
                light.color = Color.white;
            }

            yield return new WaitForSeconds(blinkInterval);
        }

        // Certifique-se de definir a cor para branco ao finalizar
        foreach (Light light in alarmLights)
        {
            light.color = Color.white;
        }
    }
}
