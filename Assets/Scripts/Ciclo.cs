using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciclo : MonoBehaviour
{
     [Header("Ciclo de Día y Noche")]
    public float dayDuration = 60f; // Duración de un día completo en segundos
    public Light directionalLight; // La luz direccional que simula el sol
    public Gradient lightColor; // Gradiente para cambiar el color del sol
    public AnimationCurve lightIntensity; // Curva de la intensidad de la luz
    
    [Header("Opciones de Cielo")]
    public Material skyboxMaterial; // Material del Skybox
    public Gradient skyboxColor; // Gradiente para cambiar el color del Skybox

    private float timeOfDay = 0f; // Tiempo transcurrido en el ciclo (0.0 a 1.0)

    void Start()
    {
        if (directionalLight == null)
        {
            directionalLight = RenderSettings.sun;
        }
    }

    void Update()
    {
        // Avanza el tiempo del día
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f; // Reinicia el ciclo
        }

        // Rotación de la luz para simular el sol
        float sunAngle = timeOfDay * 360f - 90f;
        directionalLight.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);

        // Cambia el color de la luz basándote en el gradiente
        if (lightColor != null)
        {
            directionalLight.color = lightColor.Evaluate(timeOfDay);
        }

        // Cambia la intensidad de la luz basándote en la curva
        if (lightIntensity != null)
        {
            directionalLight.intensity = lightIntensity.Evaluate(timeOfDay);
        }

        // Cambia el color del skybox si está configurado
        if (skyboxMaterial != null && skyboxColor != null)
        {
            RenderSettings.skybox = skyboxMaterial;
            skyboxMaterial.SetColor("_Tint", skyboxColor.Evaluate(timeOfDay));
        }
    }
}
