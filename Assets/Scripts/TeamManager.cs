using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeamManager : MonoBehaviour
{
    public static int totalPlayerNum = 0;

    public static List<GameObject> team1, team2;
    public List<SpawnPoint> spawnPoints;

    [SerializeField] GameObject[] goats;
    PlayerInputManager manager;
    void Start()
    {
        team1 = new List<GameObject>();
        team2 = new List<GameObject>();

        manager = GetComponent<PlayerInputManager>();
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
        } else
        {
            team2.Add(player.gameObject);
        }
    }

    public void changeGoat(GameObject goat)
    {
        manager.playerPrefab = goat;
    }
}