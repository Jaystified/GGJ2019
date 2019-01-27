﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;

    public float RATIO = 0.1f;

    public Vector2 SPEED = new Vector2(0.05f, 0.05f);

    Animator anim;

    // GameController gameController;

    void Start()
    {
        // gameController = unitychan.GetComponent<GameController>();

        // player = GameObject.Find("Player").transform;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        float diffX = player.position.x - transform.position.x;
        float diffY = player.position.y - transform.position.y;

        // // 現在位置をPositionに代入
        // Vector2 tmpPosition = transform.position;
        // // 左キーを押し続けていたら
        // float ratio = 0.1f;

        // float moveX = SPEED.x * ratio;
        // if(diffX < 0){
        //     moveX = - moveX;
        // }
        // float moveY = SPEED.y * ratio;
        // if(diffY < 0){ 
        //     moveY = - moveY;
        // }

        // Debug.Log("moveX, moveY=" + moveX + "," + moveY);
        // transform.Translate(moveX, moveY, 0f);

        Vector2 tmpPosition = transform.position;
        if (randomBoolean())
        {
            if (diffX > 0)
            {
                tmpPosition.x += SPEED.x * RATIO;
            }
            else
            {
                tmpPosition.x -= SPEED.x * RATIO;
            }
        }
        else
        {
            if (diffY > 0)
            {
                tmpPosition.y += SPEED.y * RATIO;
            }
            else
            {
                tmpPosition.y -= SPEED.y * RATIO;
            }
        }
        // スピードによってアニメーションの方向を変更
        if (diffX * diffX > diffY * diffY)
        {
            if (diffX > 0)
            {
                anim.SetInteger("Dir", 2);
            }
            else
            {
                anim.SetInteger("Dir", 1);
            }
        }
        else
        {
            if (diffY > 0)
            {
                anim.SetInteger("Dir", 3);
            }
            else
            {
                anim.SetInteger("Dir", 0);
            }
        }
        transform.position = tmpPosition;
    }

    // 不要かもしれない
    bool randomBoolean()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
}
