using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform objetivo;

    public Vector3 offset;

    private float zoom = 10f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;                  //ajustes de la camara
    public float maxZoom = 15f;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float currentYaw = 0f;



    void Update()
    {
       zoom -=Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;               //da mas o menos zoom con la rueda del raton
        zoom = Mathf.Clamp(zoom, minZoom,maxZoom);              

        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;          //gira la camara con A y D

    }

    private void LateUpdate()
    {
        transform.position = objetivo.position - offset * zoom;
        transform.LookAt(objetivo.position + Vector3.up * pitch);

        transform.RotateAround(objetivo.position, Vector3.up, currentYaw);
    }


}
