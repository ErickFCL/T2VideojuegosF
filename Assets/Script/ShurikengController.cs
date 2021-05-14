using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikengController : MonoBehaviour
{
    public float velocityX=10f;
    private Rigidbody2D rigidbody;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
         rigidbody = GetComponent<Rigidbody2D>();
         playerController = FindObjectOfType<PlayerController>(); 
         Destroy(gameObject,4);
    }

    // Update is called once per frame
    void Update()
    {
         rigidbody.velocity = Vector2.right * velocityX;
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Enemy" ){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            playerController.AumentaScore10();
        }
    }
}
