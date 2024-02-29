using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{

    private void Start()
    {
        GetComponent<TrigerZone>().OnEnterEvent.AddListener(InsideTrash);
    }

    public void InsideTrash(GameObject go)
    {
        go.SetActive(false);
    }
}
