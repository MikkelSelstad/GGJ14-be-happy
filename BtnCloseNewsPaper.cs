using UnityEngine;
using System.Collections;

public class BtnCloseNewsPaper : MonoBehaviour {

    public GameObject NewsPaper;

    void OnClick()
    {
        DepressionManager.ResetPaper();
        NewsPaper.SetActive(false);
    }

}
