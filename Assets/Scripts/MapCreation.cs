using UnityEngine;

/// <summary>
/// 地图生成工具
/// </summary>
public class MapCreation : MonoBehaviour
{
    // 初始化所需物体的数组
    // 0. 老家，3障碍，3. 出生效果,4. 河流，5. 草
    public GameObject[] maps;

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
}