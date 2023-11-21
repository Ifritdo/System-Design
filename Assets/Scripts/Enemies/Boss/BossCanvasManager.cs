// BossCanvasManager.cs
using UnityEngine;

public class BossCanvasManager : MonoBehaviour
{
    public GameObject bossCanvas;

    void Start()
    {
        // Desactivar el objeto del Canvas al inicio
        DeactivateBossCanvas();
    }

    public void ActivateBossCanvas()
    {
        // Activar el objeto del Canvas
        bossCanvas.SetActive(true);
    }

    public void DeactivateBossCanvas()
    {
        // Desactivar el objeto del Canvas
        bossCanvas.SetActive(false);
    }
}
