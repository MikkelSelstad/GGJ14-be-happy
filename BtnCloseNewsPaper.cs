using UnityEngine;
using System.Collections;

public class BtnCloseNewsPaper : MonoBehaviour {

    void OnClick()
    {
        DepressionManager.ResetPaper();
        this.gameObject.SetActive(false);
    }

}
