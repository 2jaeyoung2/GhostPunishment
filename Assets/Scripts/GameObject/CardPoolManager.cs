using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPoolManager : MonoBehaviour
{
    public static CardPoolManager Instance;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject card;

    Queue<Card> cardQueue = new Queue<Card>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Initialize(10);
    }

    private void Update()
    {
        transform.rotation = player.rotation;
    }

    private void Initialize(int size)
    {
        for (int i = 0; i < size; i++)
        {
            cardQueue.Enqueue(CreateNewCard());
        }
    }

    private Card CreateNewCard()
    {
        var newCard = Instantiate(card).GetComponent<Card>();

        newCard.gameObject.SetActive(false);

        newCard.transform.SetParent(transform);

        return newCard;
    }

    public Card GetCard()
    {
        if (Instance.cardQueue.Count > 0)
        {
            var card = Instance.cardQueue.Dequeue();

            card.transform.SetParent(null);

            card.transform.rotation = player.rotation;

            card.gameObject.SetActive(true);

            return card;
        }
        else
        {
            var newCard = Instance.CreateNewCard();

            newCard.transform.rotation = player.rotation;

            newCard.gameObject.SetActive(true);

            newCard.transform.SetParent(null);

            return newCard;
        }
    }

    public void ReturnCard(Card card)
    {
        card.gameObject.SetActive(false);

        card.transform.SetParent(Instance.transform);

        Instance.cardQueue.Enqueue(card);
    }
}
