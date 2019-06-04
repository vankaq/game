using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemyController : MonoBehaviour
{	
	public Transform player;
	public NavMeshAgent agent;

     public Text scoreText;
     static int score;
    // Start is called before the first frame update
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(player.transform.position);
       
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "bullet"){   
            Destroy(gameObject);
            score = score + 1; 
            scoreText.text = "score: " +score;

        if(score == 4){
               SceneManager.LoadScene(0);
                score = 0;
            }
        }
    }   
}