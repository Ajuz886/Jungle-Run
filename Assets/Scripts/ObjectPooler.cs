using System.Collections.Generic; 
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int numberOfObject;
   


    private List<GameObject> gameObjects;

    void Start()
    {
        gameObjects = new List<GameObject>();

        for (int i = 0; i < numberOfObject; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            gameObjects.Add(obj);
        }
    }

    public GameObject GetPooledGameObject()
    {
        foreach (GameObject obj in gameObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

      
        GameObject newObj = Instantiate(pooledObject);
        newObj.SetActive(false);
        gameObjects.Add(newObj);
        return newObj;
    }
}
