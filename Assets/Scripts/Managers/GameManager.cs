using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    public Transform Submarine;

    public float currentDepth { get; private set; } = 0;
    public float DiveSpeed;
    public float[] TierDepth = new float[5];

    public Difficulty CurrentTier { get; private set; } = Difficulty.Tier1;
    public UnityAction<Difficulty> OnNewTier;
    public UnityAction OnGameWin;


    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        OnNewTier?.Invoke(CurrentTier);
    }

    // Update is called once per frame
    void Update()
    {
        currentDepth += DiveSpeed * Time.deltaTime;

        if (currentDepth > TierDepth[(int)CurrentTier])
        {
            if (CurrentTier == Difficulty.Tier5)
            {
                OnGameWin?.Invoke();
                return;
            }

            CurrentTier++;
            OnNewTier?.Invoke(CurrentTier);
        }
    }
}

public enum Difficulty
{
    Tier1,
    Tier2,
    Tier3,
    Tier4,
    Tier5
}
