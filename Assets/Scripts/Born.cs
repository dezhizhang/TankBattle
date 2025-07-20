using UnityEngine;

/// <summary>
/// 玩家出生特效
/// </summary>
public class Born : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Start()
    {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
    }

    private void BornTank()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}