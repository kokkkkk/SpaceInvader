using UnityEngine;
using System.Collections;

public class boss : MonoBehaviour {
    int count;
    public GameObject explo;
	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ship" || col.tag == "Bullet")
        {
            count++;
            Destroy(col.gameObject);
            gameFunction.Instance.AddScore(10);
            if (col.tag == "Ship")
            {
                count++;
                Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);
                Destroy(col.gameObject);
                Destroy(gameObject);
                gameFunction.Instance.GameOver();
            }
        }
        if (count == 20)
        {
            Destroy(gameObject);
            Instantiate(explo, transform.position, transform.rotation);
            gameFunction.Instance.addtime(50);
            count = 0;
            gameFunction.Instance.bossWin();
        }
    }
}

