using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;

    private Vector3 carCameraVector3;
    void Start()
    {
        carCameraVector3 = car.transform.position - transform.position;
    }
    void LateUpdate()
    {
        transform.position = car.transform.position - car.transform.rotation * carCameraVector3;
        transform.LookAt(car);
    }
}
