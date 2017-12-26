using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform Target ;

    private void Awake()
    {
        if (!Target) Target = FindObjectOfType<player>().transform;
    }

    private void Update()
    {
        Vector3 position = Target.position;
        position.z = -10.0F;
        position.y = -30;
        transform.position = Vector3.Lerp(transform.position,position, speed * Time.deltaTime);
    }

}
