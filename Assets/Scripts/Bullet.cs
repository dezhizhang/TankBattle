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
}