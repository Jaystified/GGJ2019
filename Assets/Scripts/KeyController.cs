using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private AudioSource pick;
    public AudioClip picksound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter2D (Collider2D hit)
    {
        if (hit.CompareTag ("Player")) {
            PlayerController playerController = hit.gameObject.GetComponent<PlayerController>();

            // Flag設定            
            playerController.hasKey = true;
            pick.PlayOneShot(picksound);
            Debug.Log("Player has key. playerController.hasKey=" + playerController.hasKey);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }  

}
