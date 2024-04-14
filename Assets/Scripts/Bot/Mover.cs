using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed;

    private bool activateUpdate;
    private bool activateFixedUpdate;

    public void Moving()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (!activateUpdate) return;

        Moving();
    }
    private void FixedUpdate()
    {
        if (!activateFixedUpdate) return;

        Moving();
    }

    public void ActiveUpdate(bool active)
    {
        activateUpdate = active;
    }
    
    public void ActiveFixedUpdate(bool active)
    {
        activateFixedUpdate = active;
    }

    public void StartCoroutineMoving(bool fixedUpdate)
    {
        StartCoroutine(MovingCoroutine(fixedUpdate));
    }

    private IEnumerator MovingCoroutine(bool fixedUpdate)
    {
        while (fixedUpdate)
        {
            Moving();
            yield return new WaitForFixedUpdate();
        } 
        
        while (!fixedUpdate)
        {
            Moving();
            yield return null;
        }
    }
}
