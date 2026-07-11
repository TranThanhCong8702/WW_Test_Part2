using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string poolName;

    public string prefabItemPath;

    public GameObject prefab;

    public int startSize = 20;

    [HideInInspector]
    public Queue<GameObject> objects = new Queue<GameObject>();
}
public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;
    [SerializeField]
    private List<Pool> pools = new List<Pool>();

    private Dictionary<string, Pool> poolDictionary;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        poolDictionary = new Dictionary<string, Pool>();

        foreach (Pool pool in pools)
        {
            if(!string.IsNullOrEmpty(pool.poolName) && !string.IsNullOrEmpty(pool.prefabItemPath) && pool.prefab)
            {
                poolDictionary.Add(pool.poolName, pool);

                for (int i = 0; i < pool.startSize; i++)
                {
                    CreateObject(pool);
                }
            }
        }
    }

    private GameObject CreateObject(Pool pool)
    {
        GameObject obj = Instantiate(pool.prefab, transform);

        obj.SetActive(false);

        pool.objects.Enqueue(obj);

        return obj;
    }

    public GameObject Spawn(string poolName)
    {
        if (!poolDictionary.ContainsKey(poolName))
        {
            Debug.LogError($"Pool {poolName} not found");
            return null;
        }

        Pool pool = poolDictionary[poolName];

        if (pool.objects.Count == 0)
        {
            CreateObject(pool);
        }

        GameObject obj = pool.objects.Dequeue();
        obj.transform.localScale = Vector3.one;
        obj.transform.GetComponent<SpriteRenderer>().sprite = null;
        obj.SetActive(true);

        return obj;
    }

    public void Return(string poolName, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(poolName))
        {
            Destroy(obj);
            return;
        }
        obj.transform.GetComponent<SpriteRenderer>().sprite = null;
        obj.SetActive(false);

        obj.transform.SetParent(transform);

        poolDictionary[poolName].objects.Enqueue(obj);
    }
}
