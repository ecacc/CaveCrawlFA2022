using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightMove : MonoBehaviour
{
    public float runSpeed = 8f;
    private Vector3 hMove;
    public GameObject CameraBossFight;
    public Animator anim;

    // Things for sound effects
    public AudioSource WalkSFX;
    public AudioSource JumpSFX;
    public AudioSource lavaSFX;
    public GameObject pauseMenu;
    public GameObject note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (Input.GetAxis("Horizontal") != 0)
        {
            if(FightLava.startBlinking) {
                if (!lavaSFX.isPlaying) {
                    lavaSFX.Play();
                }
            }
            if (!WalkSFX.isPlaying && !JumpSFX.isPlaying && !pauseMenu.activeSelf && !note.activeSelf){
                WalkSFX.Play();
            } else if(JumpSFX.isPlaying || pauseMenu.activeSelf || note.activeSelf) {
                WalkSFX.Stop();
            }
            anim.SetBool("Walking", true);
        }else
        {
            WalkSFX.Stop();
            if(FightLava.startBlinking) {
                if(!lavaSFX.isPlaying) {
                    lavaSFX.Play();
                }
            }
            anim.SetBool("Walking", false);
        }
        transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BossFightTrigger")
        {
            other.gameObject.SetActive(false);
            CameraBossFight.GetComponent<CameraBossFight>().FightCam();
        }
    }

    
}
