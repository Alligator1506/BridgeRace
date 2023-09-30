using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : UICanvas
{
    [SerializeField] private TextMeshProUGUI levelText;

    public override void Setup()
    {
        base.Setup();
        levelText.text = "Level " + LevelManager.Instance.CurrentLevelIndex;
    }

    public void PlayButton()
    {
        LevelManager.Instance.OnStartGame();

        UIManager.Instance.OpenUI<Gameplay>();
        Close();
    }
}
