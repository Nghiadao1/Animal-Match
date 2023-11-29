using UnityEngine;

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObjectSingleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var instances = Resources.FindObjectsOfTypeAll<T>();
                if (instances.Length == 0)
                    Debug.LogError("Singleton instance of type " + typeof(T) + " is missing.");
                else if (instances.Length > 1)
                    Debug.LogError("Multiple instances of type " + typeof(T) + " found. Using the first one.");
                instance = instances.Length > 0 ? instances[0] : CreateInstance<T>();
            }

            return instance;
        }
    }
}