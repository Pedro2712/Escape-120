using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brakable : MonoBehaviour
{
    public List<GameObject> breakablePieces;
    public float timeToBreak = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in breakablePieces)
        {
            item.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if(timer >= timeToBreak)
        {
            foreach (var item in breakablePieces)
            {
                item.SetActive(true);
                item.transform.parent = null;
            }

            gameObject.SetActive(false);
        }
    }

   
}
