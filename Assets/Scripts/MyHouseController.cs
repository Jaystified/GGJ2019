using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyHouseController : MonoBehaviour
{
    private AudioSource door;
    public AudioClip dooropen;
    public AudioClip doorlocked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag ("Player")) {
            PlayerController playerController = collision.collider.gameObject.GetComponent<PlayerController>();
            Debug.Log("Playerが家に入った。playerController.hasKey=" + playerController.hasKey);
            if (playerController.hasKey)
            {
                door.PlayOneShot(dooropen);
                SceneManager.LoadScene("Clear");

            } else
            {
                door.PlayOneShot(doorlocked);
            }
            
        }


    }
   
}
