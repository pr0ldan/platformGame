using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCustom : MonoBehaviour
{
    public GameObject square1;
    public void ChangeConf() {
        PlayerManager.isCustom = true;
        PlayerManager.isCustom2 = false;
    }
}
