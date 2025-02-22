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
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(new Vector3(0,0,-45)*Time.deltaTime);
    }
    // When the player enters the portal, the next level will load
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //animator.SetTrigger("ActivatePortal"); // Optionally trigger animation

            // Play sound or show effects before transitioning to next level
            StartCoroutine(PortalDelay(2f)); // Wait 2 seconds before loading the next scene
        }
    }

    IEnumerator PortalDelay(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next level
    }
}
