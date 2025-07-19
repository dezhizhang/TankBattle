using UnityEngine;

public class Player : MonoBehaviour
{
    // 移动的速度
    public float moveSpeed = 3;

    // 精灵对象
    private SpriteRenderer _sprite;

    // 精灵集合
    public Sprite[] sprites;

    // 子弹
    public GameObject bullectPrefab;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // 玩家移动
        PlayMove();
        Attack();
    }

    /// <summary>
    /// 坦克攻击方法
    /// </summary>
    private void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullectPrefab, transform.position, transform.rotation);
        }
    }

    /// <summary>
    /// 玩家移动
    /// </summary>
    private void PlayMove()
    {
        // 水平轴的输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal < 0)
        {
            //向左移动
            _sprite.sprite = sprites[3];
        }
        else if (horizontal > 0)
        {
            _sprite.sprite = sprites[1];
        }

        if (horizontal != 0)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime * horizontal, Space.World);
            return;
        }

        if (vertical < 0)
        {
            // 向下移动
            _sprite.sprite = sprites[2];
        }
        else if (vertical > 0)
        {
            _sprite.sprite = sprites[0];
        }

        // 玩家垂直移动
        transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime * vertical, Space.World);
    }
}