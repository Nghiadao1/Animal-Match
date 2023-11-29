using UnityEngine;

/// <summary>
/// Represents a temporary MonoBehaviour singleton class.
/// </summary>
/// <typeparam name="T">The type of the MonoBehaviour.</typeparam>
public class TemporaryMonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    var singletonObject = new GameObject(SingletonName);
                    instance = singletonObject.AddComponent<T>();
                    // DontDestroyOnLoad(singletonObject);
                }
            }

            return instance;
        }
    }

    private static string SingletonName => typeof(T).Name;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (!name.Equals(SingletonName))
                name = SingletonName;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}