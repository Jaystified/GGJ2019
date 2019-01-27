using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyHouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D hit)
    {
        if (hit.CompareTag ("Player")) {
            PlayerController playerController = hit.gameObject.GetComponent<PlayerController>();
            Debug.Log("Playerが家に入った。playerController.hasKey=" + playerController.hasKey);
            if (playerController.hasKey) {
                SceneManager.LoadScene("Clear");

            } else {
                // TODO 何か吹き出しを出す？
            }
            
        }
    }      
}
