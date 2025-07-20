using System;
using UnityEngine;

/// <summary>
/// 子弹的移动
/// </summary>
public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10;

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
                // 调用玩家死死亡
                collision.SendMessageUpwards("TankDie");
                break;
            case "Heart":
                break;
            case "Enemy":
                break;
            case "Wall":
                break;
            case "Barrier":
                break;
        }
    }
}