using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public struct SpawnArea
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public SpawnArea(float _minX, float _maxX, float _minY, float _maxY)
    {
        minX = _minX;
        maxX = _maxX;
        minY = _minY;
        maxY = _maxY;
    }
}

public class Spawnner : MonoBehaviour
{
    [SerializeField] private bool spawnOnStart;
    [SerializeField] private float minSpawnTime = 1f;

    [SerializeField] private float maxSpawnTime = 3f;

    [SerializeField] private float minScale = 0.8f;
    [SerializeField] private float maxScale = 1.5f;
    
    [SerializeField] private float gravityScale = 0.5f;
    [SerializeField] private SpawnArea spawnArea;

    [SerializeField] private NextItemDisplayer nextItemDisplayer;
    [SerializeField] private GameObject[] objectList;

    [SerializeField] private bool isMenu = false;

    private Queue<GameObject> objectToSpawn = new Queue<GameObject>();
    private bool canSpawn = true;
    private float spawnTime;
    private GameManager gameManager;
    
    private void OnValidate()
    {
        var _bound = gameObject.GetComponent<BoxCollider2D>().bounds;
        spawnArea = new SpawnArea(_bound.min.x, _bound.max.x, _bound.min.y, _bound.max.y);
    }

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        objectToSpawn.Enqueue(objectList[Random.Range(0, objectList.Length)]);
        
        if (!spawnOnStart) return;
        
        gameManager.OnStart += SpawnItem;
        
        //SpawnItem();
        
    }

    private void SpawnItem()
    {
        if(!gameManager.isGameStart) return;
        
        
        if (canSpawn)
        {
            var _bound = gameObject.GetComponent<BoxCollider2D>().bounds;
            spawnArea = new SpawnArea(_bound.min.x, _bound.max.x, _bound.min.y, _bound.max.y);
        
            var _nextObj = objectList[Random.Range(0, objectList.Length)];
            //nextItemDisplayer.ShowNextItem(_nextObj.GetComponent<SpriteRenderer>().sprite);
            objectToSpawn.Enqueue(_nextObj);
        
            var _spawnPos = new Vector3(Random.Range(spawnArea.minX, spawnArea.maxX),
                Random.Range(spawnArea.minY, spawnArea.maxY));
            var _rotation = Random.Range(0f, 360f);
            var _obj = objectToSpawn.Dequeue();
        
            var _spawnObj = Instantiate(_obj, _spawnPos, Quaternion.Euler(0f, 0f, _rotation));

            _spawnObj.GetComponent<ObjectBase>().OnStick += SpawnItem;
        
            var _scale = Random.Range(minScale, maxScale);
            _spawnObj.transform.localScale = new Vector3(_scale, _scale);

            var _rb = _spawnObj.GetComponent<Rigidbody2D>();
            _rb.gravityScale = gravityScale;

            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            canSpawn = false;
            StartCoroutine(SpawnTime());
        }
        else
        {
            StartCoroutine(WaitToSpawn());
        }
        
    }

    private IEnumerator WaitToSpawn()
    {
        yield return new WaitUntil(() => canSpawn);
        SpawnItem();
    }
    
    

    private IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }
}
