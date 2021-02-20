using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AstroController : MonoBehaviour
{
    public int Lives = 3;
    public int Score = 0;
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;
    public Text livesText;
    public Text scoreText;
    public AudioClip pickSound;
    public AudioClip hitSound;
    public AudioSource musicSource;
    AudioSource audioSource;
    

    public bool Teleport = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
         audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        livesText.text = "Lives: " + Lives.ToString();
        scoreText.text = "Energy Boxes: " + Score.ToString();
        if (Score == 8)
			    {
				    SceneManager.LoadScene("Win");
			    }
        if (Lives == 0)
			    {
				    SceneManager.LoadScene("Lose");
			    }                 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        
        if(Score == 4 & !Teleport)
        {
           transform.position = new Vector3(0, -11, -1); 
           GameObject.Find("Main Camera").transform.position = new Vector3(0, -11, -10); 
           Teleport = true;
        } 
    }
    public void ChangeLives()
    {
	    Lives--;
        PlaySound(hitSound);
        if(Score < 4)
        {
            transform.position = new Vector3(0, 0, -1); 
        } 
        else
        {
            transform.position = new Vector3(0, -11, -1); 
        }
    }
    public void ChangeScore()
    {
	    Score++; 
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    public void Pick()
    {
        PlaySound(pickSound);
    }
}
