using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class WeaponController : MonoBehaviour
{
    private Camera mainCamera;

    protected void Awake()
    {
        InitializeMainCamera();
    }

    private void InitializeMainCamera()
    {
        mainCamera = Camera.main;
    }

    public Vector2 CalculateMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}