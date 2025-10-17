using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private bool goLeft;
    private bool goRight;
    private bool goUp;
    private bool goDown;
    private int dottens;
    private Rigidbody rb;
    Vector3 WarpPointA = new Vector3(25, 1, 0);
    Vector3 WarpPointB = new Vector3(-25, 1, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dottens = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            goUp = true;
            goLeft = false;
            goRight = false;
            goDown = false;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            goUp = false;
            goLeft = true;
            goRight = false;
            goDown = false;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            goUp = false;
            goLeft = false;
            goRight = false;
            goDown = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            goUp = false;
            goLeft = false;
            goRight = true;
            goDown = false;
        }
        if(goUp)
        {
            rb.linearVelocity = new Vector3(0, 0, 5);
        }
        if (goLeft)
        {
            rb.linearVelocity = new Vector3(-5, 0, 0);
        }
        if (goDown)
        {
            rb.linearVelocity = new Vector3(0, 0, -5);
        }
        if (goRight)
        {
            rb.linearVelocity = new Vector3(5, 0, 0);
        }
        if(dottens == 228)
        {
            SceneManager.LoadScene(3);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "warp1")
        {
            rb.MovePosition(WarpPointB);
        }
        if(collision.gameObject.tag == "warp2")
        {
            rb.MovePosition(WarpPointA);
        }
        if(collision.gameObject.tag == "dotten")
        {
            Destroy(collision.gameObject);
            dottens++;
        }
        if(collision.gameObject.tag == "Spook")
        {
            SceneManager.LoadScene(2);
        }
    }
}
