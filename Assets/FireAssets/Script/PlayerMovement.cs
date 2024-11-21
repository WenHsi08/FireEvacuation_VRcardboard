using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.Cardboard;

public class PlayerMovement : MonoBehaviour{
[SerializeField]
private Transform view;
[SerializeField]
private CharacterController controller;
[SerializeField]
private float speed=5;

public bool HasPointer{set; private get; }   //HasPointer可以用來控制是否能移動

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Google.XR.Cardboard.Api.IsTriggerPressed && !this.HasPointer){
            this.controller.SimpleMove(this.view.forward*this.speed);
        }
    }
}
