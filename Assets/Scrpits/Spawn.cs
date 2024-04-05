using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject[] Coin;
    [SerializeField] float maxLeft, maxRight;
    [SerializeField] float b1, b2, b3;
    [SerializeField] int Count;
    Vector2 pos;
    
    void Start()
    {
        pos = this.transform.position;
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (Count > 0)
        {
            pos = new Vector2(Random.Range(maxLeft, maxRight), this.transform.position.y);

            Instantiate(Balls[Random.Range(0, Balls.Length)], pos, Quaternion.identity);
            
            yield return new WaitForSeconds(0.05f);
            Count--;
        }

        Count = 30;

        while (Count > 0)
        {
            pos = new Vector2(Random.Range(maxLeft, maxRight), this.transform.position.y);

            Instantiate(Coin[Random.Range(0, Coin.Length)], pos, Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
            Count--;
        }
    }
}


//[System.Serializable]
//public class BallInfo
//{
//    public Ball gO;
//    public Sprite spr
//    public float rate;
//}