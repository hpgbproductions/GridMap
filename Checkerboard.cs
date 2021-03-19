using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerboard : MonoBehaviour
{
    public Material BaseMat;
    public Material UpMat;
    public Material GridMat;
    public MeshRenderer Overlay;

    private bool CheckersMode = false;

    private void Start()
    {
        ServiceProvider.Instance.DevConsole.RegisterCommand<float, float, float>("GridMap_BaseColor", CheckersBaseColor);
        ServiceProvider.Instance.DevConsole.RegisterCommand<float, float, float>("GridMap_ForeColor", CheckersUpColor);
        ServiceProvider.Instance.DevConsole.RegisterCommand<float>("GridMap_SquareSize", CheckersSize);
        ServiceProvider.Instance.DevConsole.RegisterCommand("GridMap_SwitchMode", SwitchMode);
    }

    // Set background color (default white)
    private void CheckersBaseColor(float r, float g, float b)
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

        BaseMat.color = new Color(r, g, b);
    }

    // Set foreground color (default black)
    private void CheckersUpColor(float r, float g, float b)
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

        UpMat.color = new Color(r, g, b);
        GridMat.color = new Color(r, g, b);
    }

    // Apply size on foreground materials
    private void CheckersSize(float size)
    {
        UpMat.SetTextureScale("_MainTex", new Vector2(5000f / size, 5000f / size));
        GridMat.SetTextureScale("_MainTex", new Vector2(10000f / size, 10000f / size));
    }

    private void SwitchMode()
    {
        CheckersMode = !CheckersMode;

        // Apply switch
        if (CheckersMode)
        {
            Overlay.material = UpMat;
            Debug.Log("Switched to checkerboard mode");
        }
        else
        {
            Overlay.material = GridMat;
            Debug.Log("Switched to grid mode");
        }
    }

    // Unregister the commands when the player leaves the map
    private void OnDestroy()
    {
        ServiceProvider.Instance.DevConsole.UnregisterCommand("GridMap_BaseColor");
        ServiceProvider.Instance.DevConsole.UnregisterCommand("GridMap_ForeColor");
        ServiceProvider.Instance.DevConsole.UnregisterCommand("GridMap_SquareSize");
        ServiceProvider.Instance.DevConsole.UnregisterCommand("GridMap_SwitchMode");
    }
}
