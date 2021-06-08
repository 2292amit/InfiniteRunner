using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slide : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    public void OnPointerDown(PointerEventData eventData) {
    	Debug.Log("PointerDown");
    	playerScript.isRotatePressed = true;
    }
    public void OnPointerUp(PointerEventData eventData) {
    	Debug.Log("PointerUp");
    	playerScript.isRotatePressed = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
