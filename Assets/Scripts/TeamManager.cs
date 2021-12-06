using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeamManager : MonoBehaviour
{
    public static int totalPlayerNum = 0;

    public static List<GameObject> team1, team2;
    public static List<SpawnPoint> spawnPoints;
    public List<SpawnPoint> localSpawnPoints;

    [SerializeField] GameObject[] goats;
    PlayerInputManager manager;
    void Start()
    {
        team1 = new List<GameObject>();
        team2 = new List<GameObject>();

        manager = GetComponent<PlayerInputManager>();

        spawnPoints = localSpawnPoints;
        Debug.Log("spawn points have " + spawnPoints.Count);
    }

    
    void Update()
    {
        changeGoat(goats[totalPlayerNum]);
    }

    public static void addPlayer(PlayerInput player)
    {
        totalPlayerNum++;
        if (totalPlayerNum%2 == 0)
        {
            team1.Add(player.gameObject);
            if (player.gameObject.GetComponentInChildren<Athelete>() != null) {
                player.gameObject.GetComponentInChildren<Athelete>().spawnPos = spawnPoints[totalPlayerNum].transform.position;
            } else
            {
                Debug.LogWarning("trying to add a non-athelete goat into team 1");
            }
        } else
        {
            team2.Add(player.gameObject);
            if (player.gameObject.GetComponentInChildren<Athelete>() != null)
            {
                player.gameObject.GetComponentInChildren<Athelete>().spawnPos = spawnPoints[totalPlayerNum].transform.position;
            }
            else
            {
                Debug.LogWarning("trying to add a non-athelete goat into team 2");
            }
        }
    }

    public void changeGoat(GameObject goat)
    {
        manager.playerPrefab = goat;
    }
}