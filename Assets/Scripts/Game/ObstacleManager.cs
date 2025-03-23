using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
public class ObstacleManager : MonoBehaviour
{
    public GameObject rockTilemap;
    public GameObject fireTilemap;
    private float timePassed = 0f; 
    private float timeToShowRock = 10f;
    private float timeToShowFire = 20f;
    void Start()
    {
        rockTilemap.SetActive(false);
        fireTilemap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= timeToShowRock)
        {
            rockTilemap.SetActive(true);
        }
        if(timePassed >= timeToShowFire)
        {
            fireTilemap.SetActive(true);
        }
    }

}
