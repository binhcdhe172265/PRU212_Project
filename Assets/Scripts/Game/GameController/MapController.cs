using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    public List<GameObject> maps;
    public GameObject player;
    public float checkRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainLayer;
    PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }
    void ChunkChecker()
    {
        if (playerMovement._movementInput.x > 0 && playerMovement._movementInput.y == 0)
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 0, 0), checkRadius, terrainLayer))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
            else if (playerMovement._movementInput.x < 0 && playerMovement._movementInput.y == 0)
            {
                if (Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 0, 0), checkRadius, terrainLayer))
                {
                    noTerrainPosition = player.transform.position + new Vector3(-20, 0, 0);
                    SpawnChunk();
                }
            }
            else if (playerMovement._movementInput.x == 0 && playerMovement._movementInput.y > 0)
            {
                if (Physics2D.OverlapCircle(player.transform.position + new Vector3(0, 20, 0), checkRadius, terrainLayer))
                {
                    noTerrainPosition = player.transform.position + new Vector3(0, 20, 0);
                    SpawnChunk();
                }
            }
            else if (playerMovement._movementInput.x == 0 && playerMovement._movementInput.y < 0)
            {
                if (Physics2D.OverlapCircle(player.transform.position + new Vector3(0, -20, 0), checkRadius, terrainLayer))
                {
                    noTerrainPosition = player.transform.position + new Vector3(0, -20, 0);
                    SpawnChunk();
                }
            }
            else if (playerMovement._movementInput.x > 0 && playerMovement._movementInput.y > 0)
            {
                if (Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 20, 0), checkRadius, terrainLayer))
                {
                    noTerrainPosition = player.transform.position + new Vector3(20, 20, 0);
                    SpawnChunk();
                }
            }
            else if (playerMovement._movementInput.x > 0 && playerMovement._movementInput.y < 0)
            {
                if (Physics2D.OverlapCircle(player.transform.position + new Vector3(20, -20, 0), checkRadius, terrainLayer))
                {
                    noTerrainPosition = player.transform.position + new Vector3(20, -20, 0);
                    SpawnChunk();
                }
            }
            else if (playerMovement._movementInput.x < 0 && playerMovement._movementInput.y < 0)
            {
                if (Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, -20, 0), checkRadius, terrainLayer))
                {
                    noTerrainPosition = player.transform.position + new Vector3(-20, -20, 0);
                    SpawnChunk();
                }
            }
            else if (playerMovement._movementInput.x < 0 && playerMovement._movementInput.y > 0)
            {
                if (Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 20, 0), checkRadius, terrainLayer))
                {
                    noTerrainPosition = player.transform.position + new Vector3(-20, 20, 0);
                    SpawnChunk();
                }
            }
        }
    }

    void SpawnChunk() { 
        int rand = Random.Range(0, maps.Count);
        Instantiate(maps[rand], noTerrainPosition, Quaternion.identity);
    }
}
