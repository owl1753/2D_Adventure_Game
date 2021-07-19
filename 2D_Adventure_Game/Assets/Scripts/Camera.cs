using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 3f, -10f);
    }
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 3f, -10f);
    }
}
