using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;

    public void SpawnCoins(Vector3 position, float groundWidth)
    {
        int random = Random.Range(1, 100);

        if (random < 50)
            return;


        int numberOfCoins = (int)Random.Range(3f, groundWidth);
        float y = Random.Range(2, 2);


        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject coin = coinPooler.GetPooledGameObject(); 

            if (coin != null)
            {

                

                coin.transform.position = new Vector3(
                    position.x -( groundWidth/2) + i,  
                    position.y + y,
                    0
                );

                coin.SetActive(true);
            }
        }
    }
}
