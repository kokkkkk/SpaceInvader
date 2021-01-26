using UnityEngine;
using System.Collections;

public class invader : MonoBehaviour {
    public GameObject explo;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.position += new Vector3(0, (Random.Range(-0.01f,-0.2f)), 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ship" || col.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explo, transform.position, transform.rotation);
            gameFunction.Instance.AddScore(10);
            gameFunction.Instance.addtime(1);
            if (col.tag == "Ship")
            {
                Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);
                gameFunction.Instance.GameOver();
            }
        }
    }
}
