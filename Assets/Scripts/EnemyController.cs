using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;

    public float DEFAULT_SPEED = 0.1f;

    // Playerが鍵を持ったらSpeed Up
    public float CAUSION_SPEED_RATIO = 3f;

    public Vector2 SPEED = new Vector2(0.05f, 0.05f);

    Animator anim;

    // GameController gameController;

    void Start()
    {

        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        float diffX = player.position.x - transform.position.x;
        float diffY = player.position.y - transform.position.y;
        
        Vector2 tmpPosition = transform.position;

        float speedRatio = DEFAULT_SPEED;
        // PlayerController playerController = gameObject.GetComponent<PlayerController>();
        // if (playerController.hasKey) {
        //     speedRatio *= CAUSION_SPEED_RATIO;
        // }
        
        if (randomBoolean())
        {
            if (diffX > 0)
            {
                tmpPosition.x += SPEED.x * speedRatio;
            }
            else
            {
                tmpPosition.x -= SPEED.x * speedRatio;
            }
        }
        else
        {
            if (diffY > 0)
            {
                tmpPosition.y += SPEED.y * speedRatio;
            }
            else
            {
                tmpPosition.y -= SPEED.y * speedRatio;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag ("Player")) {
            Debug.Log("PlayerはEnemyに接触した。 OnTriggerEnter2D.");
            //TODO 敵に当たったらGame Overのシーンに移動する
            SceneManager.LoadScene("GameOver");
        }
        
    }

}
