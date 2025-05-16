using System;
using UnityEngine;


public class InputController : MonoBehaviour
{
    public static event Action<Vector3> OnInput;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        var inputPos = Vector3.zero;
#if UNITY_ANDROID
        if (Input.touchCount == 0) return;
        inputPos = Input.GetTouch(0).position;
#elif UNITY_EDITOR
        if (!Input.GetMouseButtonDown(0)) return;
        inputPos = Input.mousePosition;
#endif

        var ray = _cam.ScreenPointToRay(inputPos);
        if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
            OnInput?.Invoke(hitInfo.point);
    }
}