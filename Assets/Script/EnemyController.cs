using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
        private Rigidbody2D rb;

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         rb.velocity = Vector2.left * 2;
    }
    void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.tag == "f"){
            Destroy(this.gameObject);
             Debug.Log("pasef");
            }
    }
}
