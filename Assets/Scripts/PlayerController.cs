using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // UI Elements
    [SerializeField] private Text txtCollect;
    [SerializeField] private Text txtWinText;
    [SerializeField] private Text txtDamage;

    // Health-related
    public float Health = 0f;
    public float MaxHealth = 100f;
    private float asteroidDamage;

    // Movement
    public float speed = 5f;
    private Rigidbody2D rb2d;

    // Audio
    public AudioSource PickupAudio;
    public AudioSource UFOMoveAudio;

    // Visual effects
    public Material UFOInvertColour;
    public GameObject portal;

    // Health Bar
    public HeathBarController healthBar;

    private int collectedScore = 0;
    private bool isMoving = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        asteroidDamage = Random.Range(0.20f, 0.25f);

        // Initialize UI
        txtWinText.text = "";
        txtDamage.text = "";
        txtCollect.text = "Collect: 0";

        // Set max health and current health
       healthBar.SetMaxHealth(1f);
       healthBar.setHealth(0f);

        // healthBar.SetMaxHealth(MaxHealth); // Set the max health of the health bar
        // healthBar.setHealth(Health);        // Set initial health

        UFOInvertColour.SetFloat("_Threshold", 0);
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void Update()
    {
        HandleMovementAudio();
    }

    // Handles player's movement based on input
    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    // Handles UFO movement sound
    private void HandleMovementAudio()
    {
        if (rb2d.linearVelocity.magnitude > 8 && !isMoving)
        {
            isMoving = true;
            if (!UFOMoveAudio.isPlaying)
                UFOMoveAudio.Play();
        }
        else if (rb2d.linearVelocity.magnitude <= 8 && isMoving)
        {
            isMoving = false;
            UFOMoveAudio.Stop();
        }

        if (isMoving && PauseMenuController.isGamePaused)
            UFOMoveAudio.Stop();
    }

    // Trigger collision with pickups
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            HandlePickup(other);
        }
    }

    // Handles pickup logic
    private void HandlePickup(Collider2D pickup)
    {
        pickup.gameObject.SetActive(false);
        PickupAudio.Play();
        collectedScore++;
        UpdateScore();
    }

    // Updates the score and checks for level completion
    private void UpdateScore()
    {
        txtCollect.text = "Collect: " + collectedScore;

        if (collectedScore >= 6 && GetCurrentActiveScene() == 1)
        {
            txtWinText.text = "Level Clear";
            portal.SetActive(true); // Assuming the portal is set active elsewhere, like when level is completed
        }
        else if (collectedScore >= 10 && GetCurrentActiveScene() == 2)
        {
            txtWinText.text = "Level Clear";
            portal.SetActive(true); // Same here, after 10 collectibles
        }
        else if (collectedScore >= 14 && GetCurrentActiveScene() == 3)
        {
            txtWinText.text = "You WIN: Next Level in Dev";
        }
    }

    // Calculates UFO health after collision with asteroid
    private float UFOLife()
    {
        // Apply damage
        Health += asteroidDamage;

        // Update health bar and display current health
        healthBar.setHealth(Health);
        txtDamage.text = (Health * 100).ToString("F1");

        if (Health >= 1f)
        {
            Debug.Log("UFO Crashed");
            Application.Quit();  // This might be replaced with scene reload or end screen logic
        }

        return Health;
    }

    // Collision with asteroid handling (damage)
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("AsteroidBad"))
        {
            UFOInvertColour.SetFloat("_Threshold", UFOLife());
        }
    }

    // Returns the current active scene index
    public static int GetCurrentActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
