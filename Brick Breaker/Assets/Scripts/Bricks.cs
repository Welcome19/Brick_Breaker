using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;
    public GameObject smoke;
    private LevelManager levelmanager;
    private int timesHit;
    private bool isBreakable;
    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            breakableCount++;
            //print(breakableCount);
        }
        timesHit = 0;
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
        //SimulateWin();
    }
    void HandleHits()
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            //print(breakableCount);
            levelmanager.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke,transform.position,Quaternion.identity) as GameObject;
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
    // TODO destroy this level once we can actually win!
    void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }
}
