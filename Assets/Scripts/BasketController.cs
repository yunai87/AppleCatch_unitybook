using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource audiosource;
    void Start()
    {
        Application.targetFrameRate = 60;
        this.audiosource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            this.audiosource.PlayOneShot(this.appleSE);
        }
        else  if (other.gameObject.CompareTag("Bomb"))
        {
            this.audiosource.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,Mathf.Infinity))
            {
                float x = Mathf.RoundToInt (hit.point.x);
                float z = Mathf.RoundToInt (hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
