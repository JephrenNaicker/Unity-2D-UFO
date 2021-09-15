using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField]
    // private float gravitationalForce = 5;
    public Rigidbody2D player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(new Vector3(0,0,-45)*Time.deltaTime);
    }


     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

        }
    }
}
