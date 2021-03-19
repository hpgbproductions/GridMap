using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHolder : MonoBehaviour
{
    public string[] alias;
    public string[] ashort;
    public Material[] materials;

    private void Start()
    {
        if (alias.Length != materials.Length || ashort.Length != materials.Length)
        {
            Debug.LogError("Material list array lengths are unequal!");
        }
    }

    public Material GetMaterial(string astr)
    {
        for (int m = 0; m < materials.Length; m++)
        {
            if (astr == alias[m] || astr == ashort[m])
            {
                return materials[m];
            }
        }

        // No matches
        return null;
    }

    public void CustomMaterialColor(float r, float g, float b)
    {
        if (r < 0 || r > 1)
        {
            Debug.LogWarning("Value of R should be between 0 and 1!");
        }
        if (g < 0 || g > 1)
        {
            Debug.LogWarning("Value of G should be between 0 and 1!");
        }
        if (b < 0 || b > 1)
        {
            Debug.LogWarning("Value of B should be between 0 and 1!");
        }

        materials[0].color = new Color(r, g, b);
    }

    public void CustomMaterialProperty(float m, float s)
    {
        if (m < 0 || m > 1)
        {
            Debug.LogWarning("Value of M should be between 0 and 1!");
        }
        if (s < 0 || s > 1)
        {
            Debug.LogWarning("Value of S should be between 0 and 1!");
        }

        materials[0].SetFloat("_Metallic", m);
        materials[0].SetFloat("_Glossiness", s);
    }
}
