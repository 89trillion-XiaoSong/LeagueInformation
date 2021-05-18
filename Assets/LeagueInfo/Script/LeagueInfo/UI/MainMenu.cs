using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private DanInfoDialog _danInfoDialog; 
    
    private int addScore;
    private int addSeason;
    private bool DanInfoIsInit;

    private PlayerDataController _playerDataController = new PlayerDataController();
    
    private void Start()
    {
        addScore = 100;
        addSeason = 1;
    }

    //增加分数
    public void AddScoreClick()
    {
        PlayerData.instance.Score += addScore;
    }

    //段位信息
    public void DanInformationClick()
    {
        _danInfoDialog.gameObject.SetActive(true);
        if (!DanInfoIsInit)
        {
            _danInfoDialog.Init();
            DanInfoIsInit = true;
        }
    }

    //赛季刷新
    public void NextSeasonClick()
    {
        PlayerData.instance.Season += addSeason;
       _playerDataController.seasonChange();
    }
}
