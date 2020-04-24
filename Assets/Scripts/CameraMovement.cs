using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject target;
    public float speed = 1f;
    
    void Start()
    {
        
    }

    void Update()
    {
        this.gameObject.transform.position = new Vector3(target.transform.position.x, 0, -5);
    }

}
