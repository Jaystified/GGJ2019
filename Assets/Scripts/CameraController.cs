using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの名前にしてください
        //this.Player = GameObject.Find("cat");
        //this.Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.Player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);

    }
}
