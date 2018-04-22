using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    //private Quaternion rotation;

    void Start()
    {
        offset = transform.position - player.transform.position;
        //rotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        //transform.rotation = player.transform.rotation + rotation;
    }
}
