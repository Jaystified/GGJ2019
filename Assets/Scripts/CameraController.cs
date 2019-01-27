using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public float gameAreaY = 0;
    public float gameAreaX = 0;
    float sizeY;
    float sizeX;
    // Start is called before the first frame update
    void Start()
    {
        Player = null;
        sizeY = Camera.main.orthographicSize;
        sizeX = sizeY * Screen.width / Screen.height;
    }
   
    // Update is called once per frame
    void Update()
    {
        //this.Player = GameObject.Find("Player");
        if ( Player != null ) {
            Vector3 Position = transform.position;
            Position.x = Mathf.Clamp(Player.transform.position.x, sizeX-0.32F, gameAreaX - sizeX-0.32F);
            Position.y = Mathf.Clamp(Player.transform.position.y, sizeY-0.32F, gameAreaY - sizeY-0.32F);
            transform.position = new Vector3(Position.x, Position.y, transform.position.z);
        }
    }
}
