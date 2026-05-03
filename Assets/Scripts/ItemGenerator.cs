using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem;
public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;
   
    public void SetParameter(float span, int ratio, float speed)
    {
        this.span = span;
        this.ratio = ratio;
        this.speed = speed;
    }
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            
            if (dice <= this.ratio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropspeed = this.speed;
        }
    }
}