using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecOpCust : MonoBehaviour
{
    public GameObject square2;
    public void ChangeConf() {
        PlayerManager.isCustom2 = true;
        PlayerManager.isCustom = false;
    }
}

