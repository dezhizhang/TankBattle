using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 地图生成工具
/// </summary>
public class MapCreation : MonoBehaviour
{
    // 初始化所需物体的数组
    // 0. 老家，3障碍，3. 出生效果,4. 河流，5. 草
    public GameObject[] maps;

    private List<Vector3> _mapPosList = new List<Vector3>();

    private void Awake()
    {
        // 实例化老家
        CreateGameObjectItem(maps[0], new Vector3(0, -8, 0), Quaternion.identity);
        // 转增的位置
        CreateGameObjectItem(maps[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateGameObjectItem(maps[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            CreateGameObjectItem(maps[1], new Vector3(i, -7, 0), Quaternion.identity);
        }

        // 空气外锁芯
        for (int i = -15; i < 16; i++)
        {
            CreateGameObjectItem(maps[6], new Vector3(i, 8, 0), Quaternion.identity);
        }

        // 空气外锁芯
        for (int i = -15; i < 16; i++)
        {
            CreateGameObjectItem(maps[6], new Vector3(i, -8, 0), Quaternion.identity);
        }

        // 空气外锁芯
        for (int i = -8; i < 9; i++)
        {
            CreateGameObjectItem(maps[6], new Vector3(-15, i, 0), Quaternion.identity);
        }

        // 空气外锁芯
        for (int i = -8; i < 9; i++)
        {
            CreateGameObjectItem(maps[6], new Vector3(15, i, 0), Quaternion.identity);
        }

        // 实例化地图
        for (int i = 0; i < 100; i++)
        {
            CreateGameObjectItem(maps[1], CreateRandomPosition(), Quaternion.identity);
        }

        for (int i = 0; i < 20; i++)
        {
            CreateGameObjectItem(maps[2], CreateRandomPosition(), Quaternion.identity);
        }

        for (int i = 0; i < 20; i++)
        {
            CreateGameObjectItem(maps[3], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateGameObjectItem(maps[4], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateGameObjectItem(maps[5], CreateRandomPosition(), Quaternion.identity);
        }
    }

    /// <summary>
    ///  封装生成公共预制体
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="pos"></param>
    /// <param name="rot"></param>
    private void CreateGameObjectItem(GameObject obj, Vector3 pos, Quaternion rot)
    {
        GameObject go = Instantiate(obj, pos, rot);
        // 设置父级游戏物体
        go.transform.SetParent(gameObject.transform);
    }

    /// <summary>
    /// 生成随机数位置
    /// </summary>
    /// <returns></returns>
    private Vector3 CreateRandomPosition()
    {
        while (true)
        {
            // 生成随机位置
            Vector3 pos = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!HashListPosition(pos))
            {
                return pos;
            }
        }
    }

    /// <summary>
    /// 判断点是否在集合中
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private bool HashListPosition(Vector3 pos)
    {
        int length = _mapPosList.Count;
        for (int i = 0; i < length; i++)
        {
            if (pos == _mapPosList[i])
            {
                return true;
            }
        }

        return false;
    }
}