using UnityEngine;

public class Player : MonoBehaviour
{
    // 移动的速度
    public float moveSpeed = 3;

    // 精灵对象
    private SpriteRenderer _sprite;

    // 子弹发送的时间时隔
    private float _timeValue;

    // 玩家处理保存状态
    private bool _isDefended = true;

    // 玩家处理保户的时间
    private float _defendTimeVal = 3;

    // 精灵集合
    public Sprite[] sprites;

    // 子弹
    public GameObject bulletPrefab;

    // 爆炸特效
    public GameObject explorerPrefab;

    // 受保护的的特效
    public GameObject defendEffectPrefab;

    // 子弹旋转角度
    private Vector3 _bulletEulerAngles;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 保护是否处理无敌状态
        if (_isDefended)
        {
            _defendTimeVal -= Time.deltaTime;
            defendEffectPrefab.SetActive(true);
            if (_defendTimeVal <= 0)
            {
                _isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }

        // 攻击的CD
        if (_timeValue >= 0.4)
        {
            Attack();
        }
        else
        {
            _timeValue += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        // 玩家移动
        PlayMove();
    }

    /// <summary>
    /// 坦克攻击方法
    /// </summary>
    private void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position,
                Quaternion.Euler(transform.eulerAngles + _bulletEulerAngles)
            );
            _timeValue = 0;
        }
    }


    /// <summary>
    /// 坦克的死亡
    /// </summary>
    private void TankDie()
    {
        if (!_isDefended)
        {
            // 爆炸特效
            Instantiate(explorerPrefab, transform.position, transform.rotation);
            // 死亡
            Destroy(gameObject);
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
            _bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (horizontal > 0)
        {
            _sprite.sprite = sprites[1];
            _bulletEulerAngles = new Vector3(0, 0, -90);
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
            _bulletEulerAngles = new Vector3(0, 0, -180);
        }
        else if (vertical > 0)
        {
            _sprite.sprite = sprites[0];
            _bulletEulerAngles = new Vector3(0, 0, 0);
        }

        // 玩家垂直移动
        transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime * vertical, Space.World);
    }
}