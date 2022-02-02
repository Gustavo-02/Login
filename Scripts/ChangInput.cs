﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ChangInput : MonoBehaviour
{
    EventSystem system;
    public Selectable firstInput;
    public Button enviar;

    void Start()
    {
        system = EventSystem.current;
        firstInput.Select();
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift)){
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if(previous != null){
                previous.Select();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Tab)){
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if(next != null){
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return)){
            enviar.onClick.Invoke();
            Debug.Log("logar");
        }
    }
}