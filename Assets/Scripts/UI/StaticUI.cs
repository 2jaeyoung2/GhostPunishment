using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.XR.TrackedPoseDriver;

public class StaticUI : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Slider timeBar;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private Slider expBar;

    [SerializeField]
    private TextMeshProUGUI expText;

    [SerializeField]
    private BombDrop bomb;

    [SerializeField]
    private Image qCoolTimeIcon;

    [SerializeField]
    private TextMeshProUGUI coolTimeText;

    [SerializeField]
    private Boss boss;

    [SerializeField]
    private Slider bossHPBar;

    [SerializeField]
    private TextMeshProUGUI bossHPText;

    private void Start()
    {
        healthBar.value = 1;

        timer.OnTimeChanged += UpdateTime;

        player.OnHealthChanged += UpdateHealthBar;

        player.OnEXPChanged += UpdateExpBar;

        bomb.OnSkillUsed += UpdateCoolTime;

        boss.OnHealthChanged += UpdateBossHealthBar;
    }

    private void UpdateTime(float currentTime, float totalTime)
    {
        if (timeBar != null)
        {
            timeBar.value = currentTime / totalTime;
        }
    }

    private void UpdateHealthBar(float currentHP, float maxHP)
    {
        if (healthBar != null)
        {
            healthBar.value = currentHP / maxHP;
        }

        if (healthText != null)
        {
            healthText.text = $"{currentHP} / {maxHP}";
        }
    }

    private void UpdateExpBar(float currentPlayerExp, float maxExp)
    {
        if (expBar != null)
        {
            expBar.value = currentPlayerExp / maxExp;
        }

        if (expText != null)
        {
            expText.text = $"{currentPlayerExp} / {maxExp}";
        }
    }

    private void UpdateCoolTime(float leftTime, float coolTime)
    {
        qCoolTimeIcon.fillAmount = leftTime / coolTime;

        if (Mathf.Abs(qCoolTimeIcon.fillAmount) < 0.99f)
        {
            coolTimeText.text = $"{(int)coolTime - (int)leftTime}";
        }
        else
        {
            coolTimeText.text = null;
        }
    }

    private void UpdateBossHealthBar(float bossCurrentHP, float totalHP)
    {
        if (bossHPBar != null)
        {
            bossHPBar.value = bossCurrentHP / totalHP;
        }

        if (bossHPText != null)
        {
            bossHPText.text = $"{bossCurrentHP} / {totalHP}";
        }
    }

    private void OnDestroy()
    {
        timer.OnTimeChanged -= UpdateTime;

        player.OnHealthChanged -= UpdateHealthBar;

        player.OnEXPChanged -= UpdateExpBar;

        bomb.OnSkillUsed -= UpdateCoolTime;

        boss.OnHealthChanged -= UpdateBossHealthBar;
    }
}
