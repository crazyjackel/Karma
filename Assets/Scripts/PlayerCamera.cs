﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataManager.INSTANCE.MainPlayerCamera = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
