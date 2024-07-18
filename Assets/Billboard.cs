using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera camera;
    void Update()
    {
        transform.LookAt(camera.transform);
    }
}
