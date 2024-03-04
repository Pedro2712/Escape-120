using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmScript : MonoBehaviour
{
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAlarmActive = !isAlarmActive;
            StartCoroutine(AudioStart());
            StartCoroutine(BlinkLights());
        }
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
