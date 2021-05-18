using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanInfoDialog : MonoBehaviour
{
    [SerializeField] private Text txtDan;
    [SerializeField] private RewardItemDialog itemPrefab;
    [SerializeField] private Transform content;
    
    private List<RewardItemDialog> _itemConfigs = new List<RewardItemDialog>();

    private int rewardInterval;
    private int maxScore;
    private int minScore;
    private int rewardGold;
    
    private void Start()
    {
        PlayerData.instance.scoreChangeEvent += SetDan;
        rewardInterval = 200;
        minScore = 4000;
        maxScore = 6000;
        rewardGold = 200;
    }

    public void Init()
    {
        for (int score = minScore, i = 0; score <= maxScore; score += rewardInterval, i++)
        {
            ItemConfig itemConfig = new ItemConfig();
            itemConfig.score = score;
            itemConfig.gold = rewardGold;
            itemConfig.id = i;

            RewardItemDialog item = Instantiate(itemPrefab, content);
            item.Init(itemConfig);
            _itemConfigs.Add(item);
        }
    }
    
    private void SetDan(int score)
    {
        switch (score/1000)
        {
            case 4:
                txtDan.text = "1段";
                break;
            case 5:
                txtDan.text = "2段";
                break;
            case 6:
                txtDan.text = "3段";
                break;
            default:
                txtDan.text = "无";
                break;
        }
    }
    
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
