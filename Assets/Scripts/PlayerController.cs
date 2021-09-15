using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
     private Transform pfDamagePopUp;//prefab
    
    public float Health;
    public float MaxHealth;
    private float AsteroidBadDamage;
    public Material UFOInvertColour;
    public float speed;
    public Text txtCollect;
    public Text txtWintext;
    public Text txtDamage;
    public AudioSource PickupAudio;

    public AudioSource PortalActiveAudio;

    public AudioSource UFOMoveAudio;
    
    public HeathBarController healthBar;//this is a script
    //public DamagePopUpController damagePopUpC;//this is a script


  // public ParticleSystem AstroHit;
    public GameObject portal;
    bool isMoving= false;
    private Rigidbody2D rb2d;
    private int countScore;
    // Start is called before the first frame update
    
    void Start()
    {
       rb2d=GetComponent<Rigidbody2D>();
       countScore = 0;
       Health=0f;
      
       MaxHealth=100f;
       healthBar.SetMaxHealth(1f);
       healthBar.setHealth(0f);
       AsteroidBadDamage=UnityEngine.Random.Range (0.20f,0.25f);
       txtWintext.text="";
       txtDamage.text="";
       txtCollect.text="Collect:";

        
        
             
             
       //CounterUpdate();
        /*Set the UFO Shader*/
       UFOInvertColour.SetFloat("_Threshold",0);
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       //Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce(movement*speed);

      
       //resetScene();
    }


private void Update() {
   IsUFOMoving();
  
}



/*
*Plays UFOMoveAudio when UFO is Moving
*/
void IsUFOMoving()
{
    if(rb2d.velocity.magnitude > 8)
      {      
          isMoving= true; 
      }else 
      {
          isMoving=false;
      }

      if(isMoving)
      {
          if(!UFOMoveAudio.isPlaying)
          {
            
             UFOMoveAudio.Play();
          }
      }
      else 
      {
        
          UFOMoveAudio.Stop();
      }
}

/*
*Updates Score,after DataPickUp
*/
   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            
            other.gameObject.SetActive(false);
            PickupAudio.Play();
            countScore++;
            CounterUpdate();
            Destroy(other.gameObject);
           

        }
    }

    
     private void OnCollisionEnter2D(Collision2D other) 
     {
    
        if(other.gameObject.CompareTag("AsteroidBad"))
        {
          
          UnityEngine.Debug.Log("can see AsteroidBad");
          UFOInvertColour.SetFloat("_Threshold",UFOLife());
 
          //AstroHit.Play();
           if(Health>=1f)
           {
             UnityEngine.Debug.Log("UFO Crashed");
             Application.Quit();  
           }

        }
    }

/*
*Bug:player Still takes damage after level Clear
*/
float UFOLife()
{
     Transform damagePopUpTransform = Instantiate(pfDamagePopUp,rb2d.position,Quaternion.identity);
     DamagePopUpController   damagePopUpC = damagePopUpTransform.GetComponent<DamagePopUpController>();
    var CurrHealth = (Health+=AsteroidBadDamage);
    UnityEngine.Debug.Log("CurrHealth"+CurrHealth);
    healthBar.setHealth(CurrHealth);
    damagePopUpC.SetDamageText( Mathf.Round(AsteroidBadDamage * 100f));
    txtDamage.text=CurrHealth.ToString();
   return CurrHealth;
}


   /*
   *Tracks Score for different Levels
   */
    void CounterUpdate()
    {
      txtCollect.text="Collect:"+countScore.ToString();
      
      if(countScore>=6&&GetCurrentActiveScene()==1){

          txtWintext.text = "Level Clear";
        
          portal.SetActive(true);
          PortalActiveAudio.Play();

      }
      else 
       if(countScore>=10 && GetCurrentActiveScene()==2)
       {
           txtWintext.text = "Level Clear";
          
            portal.SetActive(true);
            PortalActiveAudio.Play();
            

       }
       else if(countScore>=14&&GetCurrentActiveScene()==3)
       {
            txtWintext.text = "You WIN:Next Level in Dev";
            
            //Time.timeScale= 0f;//pause or freeze all objects within a scene *BUG Song still plays
           // UFOMoveAudio.Stop();
       }
    }

     /*
     Get The Current ActiveScene 
     */
    public int  GetCurrentActiveScene()
    {
      return    SceneManager.GetActiveScene().buildIndex;
    }

//void resetScene()
    // {

    //     if (Input.GetKeyDown("R")) 
    //     { //If you press R
    //     Debug.Log("Work?");
    //      SceneManager.LoadScene(SceneManager.GetActiveScene().ToString()); //Load scene called Game  

    //     }
    // }




}
