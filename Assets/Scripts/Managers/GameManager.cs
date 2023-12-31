using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
            Singleton = this;
        else
            Destroy(gameObject);


        OnGameWin += Win;
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

    /// <summary>
    /// Dummy Win Function
    /// </summary>
    void Win()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
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
