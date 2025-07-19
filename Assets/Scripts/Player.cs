using UnityEngine;

public class Player : MonoBehaviour
{
    // 移动的速度
    public float moveSpeed = 3;

    // 精灵对象
    private SpriteRenderer _sprite;

    public Sprite[] sprites;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 水平轴的输入
        float horizontal = Input.GetAxis("Horizontal");


        if (horizontal < 0)
        {
            // 向左移动
            _sprite.sprite = sprites[3];
        }
        else if (horizontal > 0)
        {
            // 向右移动
            _sprite.sprite = sprites[1];
        }

        // 玩家水平方向
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * horizontal, Space.World);

        // 垂直轴的输入
        float vertical = Input.GetAxis("Vertical");
        if (vertical < 0)
        {
            // 向下移动
            _sprite.sprite = sprites[2];
        }
        else if (vertical > 0)
        {
            // 向上移动
            _sprite.sprite = sprites[0];
        }

        // 玩家垂直移动
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * vertical, Space.World);
    }
}