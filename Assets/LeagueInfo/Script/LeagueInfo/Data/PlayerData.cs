using UnityEngine;

public  class PlayerData : MonoBehaviour
{
    private int score;      //分数
    private int gold;       //金币
    private int season;     //赛季

    public delegate void MenuRefreshEventHanlder(int i);

    public event MenuRefreshEventHanlder scoreChangeEvent;        //分数改变事件
    public event MenuRefreshEventHanlder goldChangeEvent;         //金币改变事件
    public event MenuRefreshEventHanlder seasonChangeEvent;       //赛季改变事件

    public static PlayerData instance;
    
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    //分数
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value < 6000 ? value : 6000;
            
            if (scoreChangeEvent != null)
            {
               scoreChangeEvent(score);
            }
        }
    }

    //金币
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            if (goldChangeEvent != null)
            {
                goldChangeEvent(gold);
            }
        }
    }

    //赛季
    public int Season
    {
        get
        {
            return season;
        }
        set
        {
            season = value;
            if (seasonChangeEvent != null)
            {
                seasonChangeEvent(season);
            }
        }
    }
}
