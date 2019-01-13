using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text pointsText;
    public Text winText;

    private Rigidbody rb;
    private int points;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;
        setPointuationText();
        winText.text = ""; 
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            points++;
            setPointuationText();
        }
    }

    void setPointuationText()
    {
        pointsText.text = "Points: " + points.ToString();
        if (points >= 8)
        {
            winText.text = "You win!";
        }
    }
}