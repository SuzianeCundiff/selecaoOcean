﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Player>() != null){
            GameController.instance.BirdScored();
        }
    }
}
