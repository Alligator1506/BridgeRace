using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public GameObject[] brickPrefabs; 
    public int mapWidth = 20; // Số lượng viên gạch theo chiều ngang
    public int mapHeight = 10; // Số lượng viên gạch theo chiều dọc
    private void Start()
    {
        SpawnBricks();
    }

    private void SpawnBricks()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // Tạo một ngẫu nhiên viên gạch và lấy một màu sắc ngẫu nhiên
                GameObject randomBrickPrefab = brickPrefabs[0];

                // Tạo viên gạch tại vị trí (x, y) với màu sắc ngẫu nhiên
                GameObject brick = Instantiate(randomBrickPrefab, new Vector3(-2 + x, 0.65f, 2 + y), Quaternion.identity);

                // Gắn viên gạch vào map (để dễ quản lý)
                brick.transform.parent = transform;
            }
        }
    }
}
