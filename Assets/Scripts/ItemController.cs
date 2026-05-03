using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
public class ItemController : MonoBehaviour
{
    public float dropspeed = -0.03f;
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(0, this.dropspeed, 0);
        if (transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
    }
}
