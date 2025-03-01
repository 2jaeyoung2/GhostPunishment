using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Boss boss;

    [SerializeField]
    private Button titleButton;

    private void Start()
    {
        titleButton.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));

        titleButton.gameObject.SetActive(false);

        player.IsDead += ShowTitleButton;

        boss.IsDead += ShowTitleButton;
    }

    private void ShowTitleButton()
    {
        titleButton.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        player.IsDead -= ShowTitleButton;

        boss.IsDead -= ShowTitleButton;
    }
}
