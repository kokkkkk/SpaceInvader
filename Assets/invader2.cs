using UnityEngine;
using System.Collections;

public class invader2 : MonoBehaviour
{
    int count;
    public GameObject explo;
    // Use this for initialization
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, (Random.Range(-0.01f, -0.015f)), 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ship" || col.tag == "Bullet")
        {
            count++;
            Destroy(col.gameObject);
            if (col.tag == "Ship")
            {
                count++;
                Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);
                Destroy(col.gameObject);
                gameFunction.Instance.AddScore(40);
                Destroy(gameObject);
                gameFunction.Instance.GameOver();
            }
        }
        if (count == 3)
        {
            Destroy(gameObject);
            Instantiate(explo, transform.position, transform.rotation);
            gameFunction.Instance.AddScore(40);
            gameFunction.Instance.addtime(5);
            count = 0;
        }
    }
}
