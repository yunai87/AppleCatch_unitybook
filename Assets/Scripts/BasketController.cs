using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSe;
    public AudioClip bombSe;
    AudioSource audiosource;
    GameObject director;
    void Start()
    {
        Application.targetFrameRate = 60;
        this.audiosource = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            this.audiosource.PlayOneShot(this.appleSe);
            this.director.GetComponent<GameDirector>().GetApple();
        }
        else  if (other.gameObject.CompareTag("Bomb"))
        {
            this.audiosource.PlayOneShot(this.bombSe);
            this.director.GetComponent<GameDirector>().GetBomb();
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
