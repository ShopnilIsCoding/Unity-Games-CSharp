using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
