using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Referenz zum CharacterController herstellen
    [Header("Character Controller")]
    public CharacterController controller;

    //Gravitation und Sprunghöhe festlegen
    [Header("Physics")]
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Geschwindigkeiten initialisieren
    public float speed;
    [Header("Speed values")]
    public float sprint = 18f;
    public float standard = 12f;
    public float transition = 0.5f;
    public float factor = 100f;
    public float maxEndurance = 5f;
    public float enduranceRegeneration = 2.5f;

    //Spieler und Boden Kontakt initialisieren
    [Header("Objects")]
    public Transform player;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //Grundsätzliche Sachen initialisieren
    Vector3 velocity;
    bool isGrounded;
    bool hasLanded;

    [System.NonSerialized]
    public float currentEndurance;

    GameManager gameManager;
    EnduranceBar enduranceBar;

    void Start()
    {
        speed = standard;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        enduranceBar = GameObject.FindGameObjectWithTag("Endurance").GetComponent<EnduranceBar>();
        enduranceBar.SetMaxEndurance(maxEndurance);
        currentEndurance = maxEndurance;
        hasLanded = true;
    }

	// Update is called once per frame
	void Update ()
    {
        
        if (gameManager.sceneHasInitialized)
        {
            //Überprüfung, ob Spieler am Boden ist
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            //Wenn am Boden und die Geschwindigkeit kleiner 0 soll der Spieler mit einer Velocity von -2 auf dem Boden gepresst werden
            if (isGrounded && velocity.y < 0)
            {
                if (!hasLanded)
                {
                    hasLanded = true;
                    //Play Landing Sound
                }

                velocity.y = -2f;
            }

            //Initialisierung der Input Achsen (W,A,S,D)
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            //Bewegungs Vektor für den Spieler erzeugen
            Vector3 move = transform.right * x + transform.forward * z;

            //Zugriff auf den Controller, um den Spieler mit dem aktuellen Wert von "speed" zu bewegen
            controller.Move(move * calcSpeed() * Time.deltaTime);

            //Falls der Spieler auf dem Boden steht und "space" drückt, springt er
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                hasLanded = false;
                //Berechnung der Sprunghöhe des Spielers
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            //Gravitationseinfluss auf die Velocity
            velocity.y += gravity * Time.deltaTime;

            //Endgültige bewegung des Controllers
            controller.Move(velocity * Time.deltaTime);

            //Spieler Senkrecht halten
            if (transform.rotation.x != 0 || transform.rotation.z != 0)
            {
                Vector3 eulerAngles = transform.rotation.eulerAngles;
                eulerAngles = new Vector3(0, eulerAngles.y, 0);
                transform.rotation = Quaternion.Euler(eulerAngles);
            }

            //Überprüfen, ob der Spieler unterhalb der Map ist == runtergefallen
            if ((transform.position.y < gameManager.spawnModule.transform.position.y - transform.localScale.y * 2 * 10) && !GameObject.Find("GameManager").transform.GetComponent<GameManager>().gameIsCurrentlyEnded)
            {
                gameManager.SetText("You fell from the world!");
                gameManager.EndGame();
            }

            //Ausdauer erhöhen
            if (Input.GetKey(KeyCode.LeftShift) & (Input.GetKey(KeyCode.W)))
            {
                currentEndurance -= Time.deltaTime;
                if (currentEndurance <= 0)
                {
                    currentEndurance = 0;
                }
                enduranceBar.SetEndurance(currentEndurance);
            }
            else
            {
                currentEndurance += Time.deltaTime * enduranceRegeneration;
                if (currentEndurance >= maxEndurance)
                {
                    currentEndurance = maxEndurance;
                }
                enduranceBar.SetEndurance(currentEndurance);
            }
        }
	}
    private float calcSpeed()
    {

        if(Input.GetKey(KeyCode.LeftShift) && speed != sprint && !Input.GetKey(KeyCode.S) && currentEndurance > 0)
        {
            speed += (transition * factor * Time.deltaTime);
            if(speed > sprint)
            {
                speed = sprint;
            }

            return speed;
        }
        else if((speed != standard && !Input.GetKey(KeyCode.LeftShift)) || (speed != standard && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S)) || Input.GetKey(KeyCode.S) || currentEndurance == 0)
        {
            if(speed > standard)
            {
                speed -= (transition * factor * Time.deltaTime);
                if(speed < standard)
                {
                    speed = standard;
                }
            }
            else
            {
                speed += (transition * factor * Time.deltaTime);
                if(speed > standard)
                {
                    speed = standard;
                }
            }

            return speed;
        }
        else
        {
            return speed;
        }
    }

    public void SetMaxEndurance(float value)
    {
        maxEndurance = value;
        enduranceBar.SetMaxEndurance(value);
    }
}
