using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBlue : MonoBehaviour
{
    private void Start()
    {
        ServiceProvider.Instance.DevConsole.RegisterCommand("CheckSkybox", CheckSkybox);
    }

    private void CheckSkybox()
    {
        Material skyboxMaterial = new Material(RenderSettings.skybox);

        if (skyboxMaterial == null)
        {
            Debug.LogError("Skybox material not found");
        }
        else
        {
            Debug.Log("Skybox material found: " + skyboxMaterial.name);
            skyboxMaterial.color = Color.green;
            RenderSettings.skybox = skyboxMaterial;
        }
    }
}
