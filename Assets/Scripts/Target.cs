using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float forceMultiplier = 10f;
    private float torqueLimit = .05f;

    private float spawnPos = 1.7f;

    private GameManager gameManager;

    public int pointValue;
    public ParticleSystem explosionPS; 

    // private float zPos = 0.3f; 
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPosition();

        // Get the XRGrabInteractable component and subscribe to the select event
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float RandomTorque()
    {
        return Random.Range(-torqueLimit, torqueLimit); 
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * forceMultiplier;
    }

    private Vector3 RandomPosition()
    { 
        return new Vector3 (Random.Range(-spawnPos, spawnPos), 1,  Random.Range(-spawnPos, spawnPos));
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.DecreaseScore(pointValue);
        }

        if (gameManager.GetScore() < 0)
        {
            gameManager.GameOver();
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        DestroySelf(); // This will be called when the object is "selected" by the XR Ray Interactor
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
        Instantiate(explosionPS, transform.position, transform.rotation);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.IncreaseScore(pointValue);
        }
        else
        { 
            gameManager.DecreaseScore(pointValue);
        }
    }
}
