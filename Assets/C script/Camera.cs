using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Transform followTransform;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x + 0.4f, followTransform.position.y + 0.5f, this.transform.position.z);
    }
}
