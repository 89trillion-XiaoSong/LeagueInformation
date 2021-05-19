using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanInfoDialog : MonoBehaviour
{
    [SerializeField] private Text txtDan;
    [SerializeField] private RewardItem itemPrefab;
    [SerializeField] private Transform content;

    public Scrollbar scrollbar;
    
    private List<RewardItem> itemConfigsList = new List<RewardItem>();      //item数据列表

    private int rewardInterval;     //奖励分数间隔
    private int maxScore;           //最高分数
    private int minScore;           //奖励起始分数
    private int rewardGold;         //奖励金币
    
    private void Awake()
    {
        PlayerData.instance.scoreChangeEvent += SetDan;             //刷新段位
        PlayerData.instance.scoreChangeEvent += RewardRefresh;      //奖励刷新事件
        PlayerData.instance.seasonChangeEvent += SeasonRefresh;     //赛季刷新事件
        
        rewardInterval = 200;       //奖励间隔
        minScore = 4000;            //最小奖励分数
        maxScore = 6000;            //最大奖励分数
        rewardGold = 200;           //奖励金币数
    }
    
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        for (int score = minScore, i = 0; score <= maxScore; score += rewardInterval, i++)
        {
            ItemConfig itemConfig = new ItemConfig();
            itemConfig.score = score;
            itemConfig.gold = rewardGold;

            RewardItem item = Instantiate(itemPrefab, content);
            item.Init(itemConfig);
            itemConfigsList.Add(item);
        }
    }
    
    //设置段位显示
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

    /// <summary>
    /// 分数改变时奖励刷新
    /// </summary>
    /// <param name="score"></param>
    private void RewardRefresh(int score)
    {
        if (score >= 4000)
        {
            foreach (RewardItem item in itemConfigsList)
            {
                item.SetRewardButton(item.itemConfig.isAwarded);
            }
        }
    }

    /// <summary>
    /// 赛季刷新时更新奖励
    /// </summary>
    /// <param name="season"></param>
    private void SeasonRefresh(int season)
    {
        foreach (RewardItem item in itemConfigsList)
        {
            item.itemConfig.isAwarded = false;
        }
    }
    
    /// <summary>
    /// 关闭界面
    /// </summary>
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
