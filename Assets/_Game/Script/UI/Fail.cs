using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fail : UICanvas
{

    public void RetryButton()
    {
        LevelManager.Instance.OnRetry();
        Close();
    }

}
