using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Animator animator;
    public Rigidbody rd;
    public AudioSource hitAudioSource;
    private float ballLifeTime = 1.5f;
    int counter = 0;


    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Monster"))
        {
            return;
        }
        hitAudioSource.Play();
        animator.SetTrigger("Capturing");
        enabled = false;

        rd.useGravity = false;
        rd.velocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;

        transform.LookAt(collision.transform);
        countball();
    }

    public void countball()
    {
        counter += 1;

        if (counter >= 4)
        {

        }
    }

    private void DestroyBall()
    {
        FindObjectOfType<GameManager>().BallDestroyed();
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        ballLifeTime -= Time.deltaTime;
        if(ballLifeTime <= 0)
        {
            DestroyBall();
        }
    }

    public void OnCapturedAnimationFinished()
    {
        DestroyBall();
    }

}
