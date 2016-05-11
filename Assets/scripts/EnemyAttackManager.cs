﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttackManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public GameManager gameManager;
    private UtilityValue m_lowAttackValue;
    private UtilityValue m_mediumAttackValue;
    private UtilityValue m_highAttackValue;
    public Dictionary<string, UtilityScore> m_utilityScoreMap = new Dictionary<string, UtilityScore>();
    // Use this for initialization
    void Start ()
    {
        InitValues();
        SetScores();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //checks to see if it is the enemy turn
	    if(gameManager.enemyTurn == true)
        {
            SelectAction();
        }
	}
    void InitValues()
    {
        m_lowAttackValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, 15);
        m_lowAttackValue.SetValue(enemy.m_closenessToWinGoal);

        m_mediumAttackValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_mediumAttackValue.SetValue(player.m_health);

        m_highAttackValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_highAttackValue.SetValue(enemy.m_closenessToWinGoal);
    }

    void SetValues()
    {
        m_lowAttackValue.SetValue(enemy.m_closenessToWinGoal);
        m_mediumAttackValue.SetValue(player.m_health);
        m_highAttackValue.SetValue(enemy.m_closenessToWinGoal);
    }

    void SetScores()
    {
        UtilityScore lowAttackScore = new UtilityScore();
        lowAttackScore.AddUtilityValue(m_lowAttackValue, 1.0f);
        m_utilityScoreMap.Add("lowAttack", lowAttackScore);

        UtilityScore mediumAttackScore = new UtilityScore();
        mediumAttackScore.AddUtilityValue(m_mediumAttackValue, 1.0f);
        m_utilityScoreMap.Add("mediumAttack", mediumAttackScore);

        UtilityScore highAttackScore = new UtilityScore();
        highAttackScore.AddUtilityValue(m_highAttackValue,1.0f);
        m_utilityScoreMap.Add("highAttack",highAttackScore);
    }

    public void SelectAction()
    {
        SetValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach(KeyValuePair<string,UtilityScore> score in m_utilityScoreMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if(thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if(strBestAction == "lowAttack")
        {
            LowAttack();
        }

        if(strBestAction == "mediumAttack")
        {
            MediumAttack();
        }

        if(strBestAction == "highAttack")
        {
            HighAttack();
        }
    }

    void LowAttack()
    {

    }

    void MediumAttack()
    {

    }

    void HighAttack()
    {

    }
}
