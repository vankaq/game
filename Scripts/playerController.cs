using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{	
	Rigidbody rb;
    public Text hpText;
   
    int hp;
    
    public GameObject bullet;
    GameObject bulletClone;
    Rigidbody rbClone;
    // Start is called before the first frame update



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = 100;
        //x = transform.position.x;
        //y = transform.position.y;
        //z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * moveVertical * 50f);

        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(transform.right * moveHorizontal * 20f);

        if (Input.GetKey("space"))
       {
            bulletClone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y,
            transform.position.z), Quaternion.identity);
            rbClone = bulletClone.GetComponent<Rigidbody>();
            rbClone.AddForce(transform.forward * 1000);
       }
    }
    

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Enemy")
        {   
            hp = hp - 11;
            hpText.text = "HP: " +hp;
            if(hp <= 0)
            {
            SceneManager.LoadScene(1);
            hp = 100;
            }
        }
     }

      


}