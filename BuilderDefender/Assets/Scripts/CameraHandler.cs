using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float orthographicSize;
    private float targetOrthographicSize;
    private float zoomAmount;
    private float zoomSpeed;
    private float moveSpeed;
    private float minOrthographicSize;
    private float maxOrthographicSize;
    private void Start()
    {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
        zoomAmount = 2f;
        zoomSpeed = 5f;
        moveSpeed = 30f;
        minOrthographicSize = 10f;
        maxOrthographicSize = 30f;

    }
    private void Update()
    {
        HandleMovement();
        HandleZoom();
    }
    private void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y, 0f).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
    private void HandleZoom()
    {
        targetOrthographicSize -= Input.mouseScrollDelta.y * zoomAmount;
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);

        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);

        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
