
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public float AsteroidBadDamage;
    public Material UFOInvertColour;
    public float speed;
    public Text txtCounter;
    public Text txtWintext;

    public AudioSource PickupAudio;

    public AudioSource PortalActiveAudio;

    public AudioSource UFOMoveAudio;

  // public ParticleSystem AstroHit;
    public GameObject portal;
    bool isMoving= false;
    private Rigidbody2D rb2d;
    public float myValue = 1.0f;

    private int countScore;
    // Start is called before the first frame update
    void Start()
    {
       rb2d=GetComponent<Rigidbody2D>();
       countScore = 0;
       Health=0f;
       MaxHealth=100f;
       AsteroidBadDamage=0.25f;
       txtWintext.text="";
       CounterUpdate();
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


   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            PickupAudio.Play();
            Destroy(other.gameObject);
            countScore++;
            CounterUpdate();
           

        }
    }

    
     private void OnCollisionEnter2D(Collision2D other) 
     {
    
        if(other.gameObject.CompareTag("AsteroidBad"))
        {
          
          Debug.Log("can see AsteroidBad");
          UFOInvertColour.SetFloat("_Threshold",UFOLife());
          //AstroHit.Play();
        

        }
    }


float UFOLife()
{
    
   return Health=Health+AsteroidBadDamage;
}



    void CounterUpdate()
    {
      txtCounter.text="Score:"+countScore.ToString();
      if(countScore>=6&&GetCurrentActiveScene()==1){

          txtWintext.text = "Level Clear";
          portal.SetActive(true);
          PortalActiveAudio.Play();

      }
      else 
       if(countScore>=10&&GetCurrentActiveScene()==2)
       {
           txtWintext.text = "Level Clear Next Level in Dev";
          //portal.SetActive(true);
            PortalActiveAudio.Play();
            

       }
       else if(countScore>=6&&GetCurrentActiveScene()==3)
       {
            txtWintext.text = "You WIN";
       }
    }

     
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
