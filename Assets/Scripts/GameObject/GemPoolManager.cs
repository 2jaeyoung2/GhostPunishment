using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPoolManager : MonoBehaviour
{
    public static GemPoolManager Instance;

    [SerializeField]
    private GameObject gem;

    private Queue<EXP> gemQueue = new Queue<EXP>();

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

        Initialize(150);
    }

    private void Initialize(int size)
    {
        for (int i = 0; i < size; i++)
        {
            gemQueue.Enqueue(CreateNewGem());
        }
    }

    private EXP CreateNewGem()
    {
        var newGem = Instantiate(gem).GetComponent<EXP>();

        newGem.gameObject.SetActive(false);

        newGem.transform.SetParent(transform);

        return newGem;
    }

    public EXP GetGem()
    {
        if (Instance.gemQueue.Count > 0)
        {
            var gem = Instance.gemQueue.Dequeue();

            gem.transform.SetParent(null);

            gem.gameObject.SetActive(true);

            return gem;
        }
        else
        {
            var newGem = Instance.CreateNewGem();

            newGem.gameObject.SetActive(true);

            newGem.transform.SetParent(null);

            return newGem;
        }
    }

    public void ReturnGem(EXP gem)
    {
        gem.gameObject.SetActive(false);

        gem.transform.SetParent(Instance.transform);

        Instance.gemQueue.Enqueue(gem);
    }
}
