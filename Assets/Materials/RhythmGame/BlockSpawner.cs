using UnityEngine;
using System.Collections.Generic;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs; // Префабы блоков (стрелок)
    public KeyCode[] keys; // Массив клавиш для блоков
    public Transform[] spawnPoints; // Массив точек появления блоков
    public float spawnRate = 2f; // Частота генерации блоков
    public float destroyHeight = -10f; // Высота для уничтожения блоков
    private float spawnTimer; // Таймер для генерации блоков
    private Dictionary<int, GameObject> spawnedBlocks;
    // Словарь для отслеживания созданных блоков

    void Start()
    {
        spawnedBlocks = new Dictionary<int, GameObject>();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // Генерация блоков с заданной частотой
        if (spawnTimer >= spawnRate)
        {
            SpawnBlock();
            spawnTimer = 0f;
        }

        // Проверка координат Y и уничтожение блоков, достигших высоты destroyHeight
        CheckBlockPositions();
    }

    void SpawnBlock()
    {
        // Выбор случайной точки появления блока
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Выбор случайного префаба блока
        GameObject blockPrefab = blockPrefabs[Random.Range(0, blockPrefabs.Length)];

        // Создание блока
        GameObject newBlock = Instantiate(blockPrefab, spawnPoint.position, Quaternion.identity);

        // Устанавливаем клавишу для нового блока
        int blockIndex = System.Array.IndexOf(blockPrefabs, blockPrefab);
        newBlock.GetComponent<BlockController>().keyToPress = keys[blockIndex];

        // Добавляем блок в словарь, используя его instanceID в качестве ключа
        spawnedBlocks.Add(newBlock.GetInstanceID(), newBlock);
    }

    void CheckBlockPositions()
    {
        List<int> blocksToRemove = new List<int>();

        // Проверяем координаты Y каждого блока
        foreach (KeyValuePair<int, GameObject> pair in spawnedBlocks)
        {
            GameObject block = pair.Value;
            if (block == null || block.transform.position.y <= destroyHeight)
            {
                // Добавляем блок для удаления из словаря
                blocksToRemove.Add(pair.Key);

                // Уничтожаем блок, если он достиг высоты destroyHeight или если он был уничтожен
                if (block != null)
                {
                    Destroy(block);
                }
            }
        }

        // Удаляем блоки из словаря
        foreach (int blockID in blocksToRemove)
        {
            spawnedBlocks.Remove(blockID);
        }
    }
}