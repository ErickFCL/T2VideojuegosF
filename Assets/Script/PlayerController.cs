using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private int score = 0;
     private bool estaTocandoElSuelo = false;
    private float speed = 10;
    
    public GameObject rightBullet;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    public Text scoreText;
    private bool morir=false;
    private bool escalera=false;

    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
      //  Debug.Log("hola mundo este es un metodo que se ejecuta una vez");
        //sr.flipX = true;
        animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
            rb2d.gravityScale = 25;
        
        //escalera
        if(escalera){
            rb2d.gravityScale = 0;
        
            if(Input.GetKey(KeyCode.UpArrow))
            {
                sr.flipX = false;
            // run();
                
                //rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
                rb2d.velocity = new Vector2(rb2d.velocity.x,speed);

            }else if(Input.GetKey(KeyCode.DownArrow))//camina hacia -X
            {
                
                sr.flipX = true;
                //run();
            // rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
                rb2d.velocity = new Vector2(rb2d.velocity.x,-speed);

            }

            
        }
        //


        //score
     scoreText.text = "Puntaje: "+score;
        //

        //
        if(Input.GetKeyDown(KeyCode.X))
        {
           
            if(!sr.flipX)
            {
            var position = new Vector2(transform.position.x+0.5f,transform.position.y-0.5f);
                Instantiate(rightBullet,position,rightBullet.transform.rotation);
            }
            /*else{
             var position = new Vector2(transform.position.x-2f,transform.position.y-0.5f);
                Instantiate(leftBullet,position,rightBullet.transform.rotation);
            }
            audioSource.PlayOneShot(audioClips[1]);*/
        }
        //
        if(!morir){
         if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            run();
            
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.A))
        {
            SetSlideAnimation();
        }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            run();
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.A))
        {
            SetSlideAnimation();
        }
        }
        else
        {
            SetIdleAnimation();
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        }
        

        //cuando presiono la flecha a la derecha cambio la animacion
        //Input .GetKey(); //mientras presiono
        //Input .GetKeyUp(); //cuando suelto la tecla
        //Input .GetKeyDown();//cuando presiono por primera vez
        //sr.flipX = !sr.flipX;
        //run();
         Debug.Log("hola");
         
         if(Input.GetKeyDown(KeyCode.Space) && estaTocandoElSuelo){
             
             
            saltar();
            estaTocandoElSuelo = false;
            
        
           
             


            // rb2d.velocity = new Vector2(rb2d.velocity.x,10);
            
            //rb2d.AddForce(new Vector2(0,1000));

         }
        }else{
            
            
             Dead();
         
        }
         
    }
    void OnCollisionEnter2D(Collision2D other){
       // Debug.Log("Collision");
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.layer == 6)
            estaTocandoElSuelo = true;
       
        if(other.gameObject.layer ==11){
             escalera = true;
        }
        if(other.gameObject.layer ==8){
             morir = true;
        }
           
    }
        void OnTriggerEnter2D ( Collider2D other)//para morir
    {
        if(other.gameObject.layer == 7){
        Debug.Log("entre");
            morir = true;
        
            }
    }
     public void saltar(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        
    }
     public void run(){
        animator.SetInteger("Estado", 2);
    }
    public void Climb(){
       animator.SetInteger("Estado", 1);
    }
    public void SetIdleAnimation(){
        animator.SetInteger("Estado", 0);        
    }
    public void SetSlideAnimation(){
        animator.SetInteger("Estado", 6);        
    }
     public void Throw(){
        animator.SetInteger("Estado", 5);
    }
    public void Glide(){
       animator.SetInteger("Estado", 3);
    }
    public void Dead(){
        animator.SetInteger("Estado", 4);        
    }
    public void AumentaScore10(){
        score += 10;      
    }
    
}
