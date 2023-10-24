 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.5f;
    public GameObject Key;
    public GameObject Door;
    public GameObject NPCText;
    public GameObject Chest;
    public bool chestOpen = false; 
    public GameObject keyDisplay;
    public bool hasKey = false;
    public Animator animator;
    public Rigidbody2D rb;
    public static PlayerController instance; //creating an object of the class to be findable 
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        //Door.SetActive(false);
        NPCText.SetActive(false);
        keyDisplay.SetActive(false);

        if (instance != null) //!= means not, we are checking if the instance is in the scene
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        //ctrl+k+c crtl+k+u 

    }

    IEnumerator text()
    {
        yield return new WaitForSeconds(3);
        NPCText.SetActive(false);
        Debug.Log("bye bye text");
    }
    IEnumerator key()
    {
        keyDisplay.SetActive(true);
        yield return new WaitForSeconds(2);
        Debug.Log("bye bye key");
        Destroy(keyDisplay);
    }

    // Update is called once per frame
    void Update()
    {

        //    Vector3 newPosition = transform.position;
        //    if(Input.GetKey("w"))
        //    {
        //        player moves up 
        //        newPosition.y += speed;

        //    }

        //    if (Input.GetKey("s"))
        //    {
        //        player moves down
        //        newPosition.y -= speed;
        //    }
        //    if (Input.GetKey("d"))
        //    {
        //        player moves right 
        //        newPosition.x += speed;
        //    }
        //    if (Input.GetKey("a"))
        //    {
        //        player moves left 
        //        newPosition.x -= speed;
        

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }

    //    transform.position = newPosition; 

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Door") && hasKey == true)
        {
            SceneManager.LoadScene("indoor");
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
        if (collision.gameObject.tag.Equals("Door") && hasKey == false)
        {
            NPCText.SetActive(true);
            StartCoroutine(text());
        }
        
        if (collision.gameObject.tag.Equals("Key"))
        {
            Debug.Log("obtained key");
            //key disappears
            //Key.SetActive(false);

            //activate door

            //Door.SetActive(true);

            //player has the key
            hasKey = true;

        }
        if (collision.gameObject.tag.Equals("Exit"))
        {
            Debug.Log("exit");
            SceneManager.LoadScene("Start");
            hasKey = false;
            Destroy(gameObject);
        }
        if (hasKey == true)
        {
           // keyDisplay.SetActive(true);
            StartCoroutine(key());
            
        } 
    }

}






   