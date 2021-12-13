using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour {

    public float captureChance = 0.8f;
    public Sprite portraitSprite;
    public Animator animator;
    public AudioSource captureAudioSource;

    private Transform cameraTransform;


    void Awake()
    {
        cameraTransform = FindObjectOfType<Camera>().transform;
    }

    
    void Update()
    {
        var position = cameraTransform.position;
        position.y = transform.position.y;
        transform.LookAt(position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }

        if(Random.value > captureChance)
        {
            return;
            animator.SetTrigger("Captured");
        }

        animator.SetTrigger("Captured");
        captureAudioSource.Play();
    }

    public void OnCaptureAnimationFinished()
    {
        CapturedMonster();
    }

    private void CapturedMonster()
    {
        FindObjectOfType<GameManager>().MonsterCaptured(this);
        Destroy(gameObject);
    }

}
