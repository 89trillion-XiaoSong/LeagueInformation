﻿using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private DanInfoDialog danInfoDialog; 
    
    private int addScore;           //分数增加数值
    private int addSeason;          //赛季增加数值
    private bool DanInfoIsInit;     //判断段位页面是否初始化

    private PlayerDataController playerDataController = new PlayerDataController();
    private DanInfoDialog infoDialog;
    
    private Scrollbar scrollbar;
    
    private void Start()
    {
        addScore = 100;
        addSeason = 1;
    }

    //增加分数按钮
    public void AddScoreClick()
    {
        PlayerData.instance.Score += addScore;
    }

    //段位信息按钮
    public void DanInformationClick()
    {
        if (!DanInfoIsInit)
        {
            infoDialog = Instantiate(danInfoDialog,transform.parent);
            infoDialog.Init();
            scrollbar = infoDialog.scrollbar;
            DanInfoIsInit = true;
        }
        infoDialog.gameObject.SetActive(true);
        if (PlayerData.instance.Score > 4000)
        {
            float f = PlayerData.instance.Score - 4000;
            scrollbar.value = 1 - f / 2000f;
        }
        
    }

    //赛季刷新按钮
    public void NextSeasonClick()
    {
        PlayerData.instance.Season += addSeason;
        playerDataController.seasonChange();
    }
}
