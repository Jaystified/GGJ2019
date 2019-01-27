using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    //歩いている速度
    [SerializeField]
    [Header("歩いている速度")]
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);

    //走っている間の速度
    [SerializeField]
    [Header("歩いている速度に加算")]
    public float SPPEDRUN = 0.03f;

    // 鍵を持っているか
    public bool hasKey = false;

    // Use this for initialization
    void Start()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().Player = gameObject;
        //this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {


        Vector2 Position = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow)) //左
        {
            Position.x -= SPEED.x;
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                Position.x -= SPEED.x + SPPEDRUN;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //右
        {
            Position.x += SPEED.x;
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                Position.x += SPEED.x + SPPEDRUN;
            }

        }
        else if (Input.GetKey(KeyCode.UpArrow)) //上
        {
            Position.y += SPEED.y;
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                Position.y += SPEED.y + SPPEDRUN;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //下
        {
            Position.y -= SPEED.y;
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                Position.y -= SPEED.y + SPPEDRUN;
            }
        }


        transform.position = Position;


        ////プレイヤーの速度に応じてアニメーションを変えていく
        //this.animator.speed = SPEED.x / 0.1f;
        //this.animator.speed = SPEED.y / 0.1f;
        //this.animator.speed = SPPEDRUN.x / 0.1f;
        //this.animator.speed = SPPEDRUN.y / 0.1f;
    }

    /// <summary>
    /// 状態が変わった場合のみアニメーションを変更する
    /// </summary>
    //void ChangeAnimation()
    //{
    //    if(prevState != state)
    //    {
    //        switch(state)
    //        {
    //            case "RUN":
    //                animator.SetBool("isRun", true);
    //                animator.SetBool("isFa")
    //                break;
    //        }
    //    }
    //}
}
