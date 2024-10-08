using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GrillSpawnManager : MonoBehaviour{
    public PlayerData playerData;
    public LevelLoader levelLoader;
    private int numPlayers;
    public Sprite player1Border;
    public Sprite player2Border;
    public Sprite player3Border;
    public Sprite player4Border;
    public SteakController playerPrefab;
    private Sprite[] borderSprites;
    private SpriteRenderer borderSpriteRenderer;
    private Component[] borderSpriteRenderers;
    private Vector3[] spawnPositions;
    private float timeDT = 0f;
    private float cookingTime;

    void Start(){
        numPlayers = playerData.GetPlayerCount();

        borderSprites = new Sprite[4] {player1Border, player2Border, player3Border, player4Border};
        spawnPositions = new Vector3[4] {new Vector3(-2.35f, 2.4f, 0.0f), new Vector3(1.2f, 1.4f, 0.0f), new Vector3(-1.6f, 0.35f, 0.0f), new Vector3(1.8f, -0.8f, 0.0f)};

        for(int i=0; i<numPlayers; i++){
            SteakController player = Instantiate(playerPrefab, spawnPositions[i], Quaternion.identity);
            player.name = "Player" + (i+1);

            borderSpriteRenderers = player.GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer spriteInList in borderSpriteRenderers){
                if(spriteInList != player.GetComponent<SpriteRenderer>()){
                    borderSpriteRenderer = spriteInList;
                }
            }

            borderSpriteRenderer.sprite = borderSprites[i];
            player.playerData = playerData;
            player.player = i;

            Random rnd1 = new Random(DateTime.Now.TimeOfDay.Seconds + i);
            cookingTime = rnd1.Next(2, 5);
            player.cookingTime = cookingTime;
            Debug.Log("Cooking time: " + cookingTime);
        }

        Debug.Log(playerData.GetPlayerCount());
    }

    void Update(){
        timeDT += Time.deltaTime;

        if(timeDT >= 7.0){
            levelLoader.LoadNextLevel(1);
        }
    }
}
