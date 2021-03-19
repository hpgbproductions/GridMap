using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamsMod : MonoBehaviour
{
    MaterialHolder materialHolder;

    private void Start()
    {
        ServiceProvider.Instance.DevConsole.RegisterCommand("AdamsModActivate", ActivateAdamsMod);

        materialHolder = gameObject.GetComponent<MaterialHolder>();
    }

    private void ActivateAdamsMod()
    {
        ServiceProvider.Instance.DevConsole.RegisterCommand<string>("AdamsModApplyMaterials", ApplyMaterials);
        ServiceProvider.Instance.DevConsole.RegisterCommand<float, float, float>("AdamsModCustomColor", CustomColor);
        ServiceProvider.Instance.DevConsole.RegisterCommand<float, float>("AdamsModCustomProperty", CustomProperty);

        ServiceProvider.Instance.DevConsole.UnregisterCommand("AdamsModActivate");
    }

    private void ApplyMaterials(string astr)
    {
        // Get the material to apply
        Material material = materialHolder.GetMaterial(astr);
        if (material == null)
        {
            Debug.LogError("No material corresponding to the alias '" + astr + "'");
            return;
        }

        MeshRenderer[] meshRenderers = Resources.FindObjectsOfTypeAll<MeshRenderer>();
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            Material[] currentMaterials = meshRenderers[i].materials;
            for (int j = 0; j < currentMaterials.Length; j++)
            {
                currentMaterials[j] = material;
            }
            meshRenderers[i].materials = currentMaterials;
        }
        Debug.Log(meshRenderers.Length + "  Mesh Renderer components modified");

        Terrain[] terrains = Resources.FindObjectsOfTypeAll<Terrain>();
        for (int i = 0; i < terrains.Length; i++)
        {
            terrains[i].materialTemplate = material;
        }
        Debug.Log(terrains.Length + "  Terrain components modified");
    }

    private void CustomColor(float r, float g, float b)
    {
        materialHolder.CustomMaterialColor(r, g, b);
    }

    private void CustomProperty(float m, float s)
    {
        materialHolder.CustomMaterialProperty(m, s);
    }
}
