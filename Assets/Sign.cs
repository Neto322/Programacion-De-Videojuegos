using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    [SerializeField]
    Warning msg;

    [SerializeField]
    TextMeshPro signtext;
    private void Awake()
    {
        signtext.text = msg.Message;
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Choque");
        signtext.gameObject.SetActive(true);
    }
}
