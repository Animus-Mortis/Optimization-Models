using System.Collections;
using UnityEngine;

public enum TypeUpdate
{
    UpdateOnBot,
    FixedUpdateOnBot,
    OneUpdate,
    OneFixedUpdate,
    CoroutineOnBot,
    CoroutineOnBotFixedUpdate,
    OnCoroutineFixedUpdate,
    OnCoroutine
}

public class Setting : MonoBehaviour
{
    [SerializeField] private TypeUpdate typeUpdate;

    private BotSpawner botSpawner;
    private bool activeUpdate;
    private bool activeFixedUpdate;

    private void Start()
    {
        botSpawner = GetComponent<BotSpawner>();

        switch (typeUpdate)
        {
            case TypeUpdate.UpdateOnBot:
                for (int i = 0; i < botSpawner.Bots.Count; i++)
                {
                    botSpawner.Bots[i].ActiveUpdate(true);
                }
                break;
            case TypeUpdate.FixedUpdateOnBot:
                for (int i = 0; i < botSpawner.Bots.Count; i++)
                {
                    botSpawner.Bots[i].ActiveFixedUpdate(true);
                }
                break;
            case TypeUpdate.OneUpdate:
                activeUpdate = true;
                break;
            case TypeUpdate.OneFixedUpdate:
                activeFixedUpdate = true;
                break;
            case TypeUpdate.CoroutineOnBot:
                for (int i = 0; i < botSpawner.Bots.Count; i++)
                {
                    botSpawner.Bots[i].StartCoroutineMoving(false);
                }
                break;
            case TypeUpdate.CoroutineOnBotFixedUpdate:
                for (int i = 0; i < botSpawner.Bots.Count; i++)
                {
                    botSpawner.Bots[i].StartCoroutineMoving(true);
                }
                break;
            case TypeUpdate.OnCoroutineFixedUpdate:
                StartCoroutine(MoveAllBotFixed());
                break;
            case TypeUpdate.OnCoroutine:
                StartCoroutine(MoveAllBot());
                break;
        }
    }

    private void Update()
    {
        if (!activeUpdate) return;
        for (int i = 0; i < botSpawner.Bots.Count; i++)
        {
            botSpawner.Bots[i].Moving();
        }
    }

    private void FixedUpdate()
    {
        if (!activeFixedUpdate) return;
        for (int i = 0; i < botSpawner.Bots.Count; i++)
        {
            botSpawner.Bots[i].Moving();
        }
    }

    private IEnumerator MoveAllBot()
    {
        while (true)
        {
            for (int i = 0; i < botSpawner.Bots.Count; i++)
            {
                botSpawner.Bots[i].Moving();
            }
            yield return null;
        }
    }

    private IEnumerator MoveAllBotFixed()
    {
        while (true)
        {
            for (int i = 0; i < botSpawner.Bots.Count; i++)
            {
                botSpawner.Bots[i].Moving();
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
