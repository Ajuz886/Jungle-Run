using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform groundPoint;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;


    public ObjectPooler[] groundPoolers;



    private float[] groundWidths;
    private CoinsGenerator coinsGenerator;


    private float minY;
    private float maxY;

    public float minGap;
    public float maxGap;

    void Start()
    {
        
        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;



        groundWidths = new float[groundPoolers.Length];
        
        for (int i = 0; i < groundPoolers.Length; i++)
        {
            GameObject pooledObj = groundPoolers[i].pooledObject;
            BoxCollider2D collider = pooledObj.GetComponent<BoxCollider2D>();
            
            if (collider != null)
            {
                groundWidths[i] = collider.size.x;
            }
            else
            {
                Debug.LogError($"Ground object {pooledObj.name} does not have a BoxCollider2D!");
                groundWidths[i] = 1f;
            }

            

        }
        coinsGenerator =FindObjectOfType <CoinsGenerator>();
    }

    void Update()


    {
        if (transform.position.x < groundPoint.position.x)
        {
            int random = Random.Range(0, groundPoolers.Length);
            float distance = groundWidths[random] / 2;


            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minY, maxY);

            transform.position = new Vector3(
                transform.position.x + distance + gap,
                height,
                transform.position.z
            );

            GameObject ground = groundPoolers[random].GetPooledGameObject();
            ground.transform.position = transform.position;
            ground.SetActive(true);

            coinsGenerator.SpawnCoins(
                transform.position,
                groundWidths[random]);

            transform.position = new Vector3(
                transform.position.x + distance,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
