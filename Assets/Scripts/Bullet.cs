using System;
using UnityEngine;

/// <summary>
/// 子弹的移动
/// </summary>
public class Bullet : MonoBehaviour
{
    // 子弹的移动速度
    public float moveSpeed = 10;

    // 玩家的子弹
    public bool isPlayerBullet;

    private void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// 碰撞器
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullet)
                {
                    collision.SendMessageUpwards("TankDie");
                }

                break;
            case "Heart":
                collision.SendMessageUpwards("Die");
                break;
            case "Enemy":
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
        }
    }
}