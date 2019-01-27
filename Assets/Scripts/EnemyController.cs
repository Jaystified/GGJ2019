using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;

    public float RATIO = 0.1f;
        
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);

    void Start()
    {

    }

    void Update()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        float diffX = player.position.x - transform.position.x ;
        float diffY = player.position.y - transform.position.y ;
        
        Vector2 tmpPosition = transform.position;
        if (randomBoolean()) {
            if(diffX > 0){
                tmpPosition.x += SPEED.x * RATIO;
            } else { 
                tmpPosition.x -= SPEED.x * RATIO;
            }
        } else { 
            if(diffY > 0){ 
                tmpPosition.y += SPEED.y * RATIO;
            } else {
                tmpPosition.y -= SPEED.y * RATIO;
            }
        }
        transform.position = tmpPosition;
    }

    // 不要かもしれない
    bool randomBoolean (){
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D (Collider2D hit)
    {
        if (hit.CompareTag ("Player")) {
            Debug.Log("PlayerはEnemyに接触した。 OnTriggerEnter2D.");
            //TODO 敵に当たったらGame Overのシーンに移動する
        }
    }

}
