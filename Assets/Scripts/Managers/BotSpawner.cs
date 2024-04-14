using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private Mover botPrefab;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private uint botCount = 1;
    [SerializeField] private uint rowLength = 10;
    [SerializeField] private float step = 1.5f;

    private List<Mover> bots = new List<Mover>();
    public List<Mover> Bots { get { return bots; } }

    private void Awake()
    {
        Spawning();
    }

    private void Spawning()
    {
        float countInRow = 0;
        float xPos = startPosition.x;

        for (int i = 0; i < botCount; i++)
        {
            var newBot = Instantiate(botPrefab);
            if (countInRow >= rowLength)
            {
                countInRow = 0;
                xPos = startPosition.x;
                startPosition = new Vector3(xPos, startPosition.y, startPosition.z - step);
            }

            countInRow++;
            newBot.transform.position = new Vector3(xPos, startPosition.y, startPosition.z);
            bots.Add(newBot);
            xPos -= step;
        }
    }
}
