using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelCustom : MonoBehaviour
{
    public GameObject square;

    public void ChangeConf() {
        PlayerManager.isCustom = false;
        PlayerManager.isCustom2 = false;
    }
}

