using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    [SerializeField]
    Message msg;

    [SerializeField]
    TextMeshPro signtext;
    private void Awake()
    {
        signtext.text = msg.message;
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider other)
    {
        Debug.Log("Choque");
        signtext.gameObject.SetActive(true);
    }
}
