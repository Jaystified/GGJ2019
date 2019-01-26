using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    public Vector2 SPEED = new Vector2(0.05f, 0.05f);

    void Start()
    {
        
        player = GameObject.Find("player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float diffX = player.position.x - transform.position.x ;
        float diffY = player.position.y - transform.position.y ;

        // 現在位置をPositionに代入
		Vector2 tmpPosition = transform.position;
		// 左キーを押し続けていたら
        float ratio = 0.5f;

        if (randomBoolean()) {
            if(diffX > 0){
                tmpPosition.x += SPEED.x * ratio;
            } else { 
                tmpPosition.x -= SPEED.x * ratio;
            }
        } else { 
            if(diffY > 0){ 
                tmpPosition.y += SPEED.y * ratio;
            } else {
                tmpPosition.y -= SPEED.y * ratio;
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
}
