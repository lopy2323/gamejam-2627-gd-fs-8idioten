using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    static public DontDestroy Instance { get; private set; }

    void Awake()
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

    }
}