using System;
using UnityEngine;
using Random = System.Random;

public class SteakController : MonoBehaviour
{
    public PlayerData playerData;
    public int player = 0;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer borderSpriteRenderer;
    private AudioSource sound;
    float timeDT = 0f;
    float flipDT = 0f;
    float moveDT = 0f;
    public Sprite undercookedSteak;
    public Sprite perfectSteak;
    public Sprite overcookedSteak;
    public AudioClip cookingSound;
    public AudioClip upSound;
    public AudioClip burntSound;
    public SteakBorder border;
    float speed = 5f; 
    public float cookingTime;
    bool finished = false;
    bool up = false;
    private float upperLimit = 0.5f;
    private bool movingUp = true;
    private Vector3 originalPosition;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        borderSpriteRenderer = border.GetComponent<SpriteRenderer>(); //Get SpriteRenderer of border

        sound = gameObject.GetComponent<AudioSource>();
        sound.clip = cookingSound;

        spriteRenderer.sprite = undercookedSteak;   //Set starting sprite as undercooked

        originalPosition = transform.position;
        sound.loop = true;
        sound.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDT += Time.deltaTime;
        flipDT += Time.deltaTime;
        moveDT += Time.deltaTime;
    
        //------------------SPRITES----------------------

        // Lifting steak before time
        if(GrillInputManager.instance.RaisedSteak && up == false && spriteRenderer.sprite != perfectSteak){
            up = true;
            Vector3 position = transform.position;
            transform.position = new Vector3(position[0], (float)(position[1] + 0.8), position[2]);

            sound.loop = false;
            sound.clip = upSound;
            sound.Play();
        }

        if (timeDT >= cookingTime) {
            if(up == false){
                spriteRenderer.sprite = perfectSteak;   // Perfect steak sprite
            }
        } else if (flipDT >= 1 && up == false) {
            spriteRenderer.flipX = !spriteRenderer.flipX;   // Get steak moving
            borderSpriteRenderer.flipX = !borderSpriteRenderer.flipX;
            flipDT = 0;
        }

        // Lifting steak before it burns
        if (timeDT <= cookingTime+2 && spriteRenderer.sprite == perfectSteak) {
            if(GrillInputManager.instance.RaisedSteak && up == false){
                finished = true;
                up = true;
                Debug.Log("YIPPIE!");

                Vector3 position = transform.position;
                transform.position = new Vector3(position[0], (float)(position[1] + 0.8), position[2]);

                sound.loop = false;
                sound.clip = upSound;
                sound.Play();

                playerData.AddPoints(player, 1);
            }
        }

        // Steak burns sprite and lifts automatically
        if (timeDT >= cookingTime+2 && finished == false && up == false) {
            up = true;
            spriteRenderer.sprite = overcookedSteak;

            Vector3 position = transform.position;
            transform.position = new Vector3(position[0], (float)(position[1] + 0.8), position[2]);

            sound.loop = false;
            sound.clip = burntSound;
            sound.Play();
        }
        // -------------------------------------------------------


        // ---------------UP AND DOWN MOVEMENT--------------------
        float step = speed * Time.deltaTime;
        if(moveDT >= 2 && spriteRenderer.sprite != overcookedSteak && finished == false && up == false){

            if (movingUp) {
                // Move upwards
                if (transform.position.y < originalPosition.y + upperLimit) {
                    transform.position = new Vector3(transform.position.x, transform.position.y + step, transform.position.z);
                } else {
                    movingUp = false; // Switch to moving down
                }
            } else{
                // Move downwards
                if (transform.position.y > originalPosition.y ){
                    transform.position = new Vector3(transform.position.x, transform.position.y - step, transform.position.z);
                } else {
                    movingUp = true; // Switch to moving up
                    moveDT = 0;
                }
            }
        }
        // -------------------------------------------------------

    }
}
