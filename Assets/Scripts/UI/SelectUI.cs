using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void Start()
    {
        player.OnLevelChanged += ShowThreeCard;
    }

    private void ShowThreeCard()
    {

    }
}
