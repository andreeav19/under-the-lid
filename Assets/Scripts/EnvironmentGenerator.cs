using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnvironmentType
{
    Desert,
    Graveyard,
    Snow,
    Woods
}

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> desertEnvironments = new List<GameObject>();
    [SerializeField] private List<GameObject> graveyardEnvironments = new List<GameObject>();
    [SerializeField] private List<GameObject> snowEnvironments = new List<GameObject>();
    [SerializeField] private List<GameObject> woodsEnvironments = new List<GameObject>();
    [SerializeField] private float speed = 4.5f;
    [SerializeField] private float distanceRange = 24.35f;
    [SerializeField] private int maxEnvironments = 4;
    
    private GameObject firstEnvironment;
    private GameObject secondEnvironment;
    [HideInInspector] public EnvironmentType currentEnvironmentType;
    private int remainingEnvironments;
    
    // Start is called before the first frame update
    void Start()
    {
        firstEnvironment = GameObject.Instantiate(woodsEnvironments[0]);
        secondEnvironment = GameObject.Instantiate(woodsEnvironments[0], new Vector3(distanceRange, 0f, 0f),
            Quaternion.identity);
        currentEnvironmentType = EnvironmentType.Woods;
        remainingEnvironments = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToLeft();
    }
    
    void MoveToLeft()
    {
        firstEnvironment.transform.position += Vector3.left * (speed * Time.deltaTime);
        secondEnvironment.transform.position += Vector3.left * (speed * Time.deltaTime);
        
        if (firstEnvironment.transform.position.x <= -distanceRange)
        {
            Destroy(firstEnvironment);
            firstEnvironment = secondEnvironment;
            HandleEnvironmentCreation();
        }
    }

    void HandleEnvironmentCreation()
    {
        if (remainingEnvironments == 0)
        {
            remainingEnvironments = maxEnvironments;
            EnvironmentType environmentType = 
                (EnvironmentType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(EnvironmentType)).Length);
            currentEnvironmentType = environmentType;
        }

        CreateEnvironmentLayer(currentEnvironmentType);
        remainingEnvironments--;
    }
    
    void CreateEnvironmentLayer(EnvironmentType environmentType)
    {
        switch (environmentType)
        {
            case EnvironmentType.Desert:
                secondEnvironment = InstantiateLayer(desertEnvironments);
                break;
            case EnvironmentType.Graveyard:
                secondEnvironment = InstantiateLayer(graveyardEnvironments);
                break;
            case EnvironmentType.Snow:
                secondEnvironment = InstantiateLayer(snowEnvironments);
                break;
            case EnvironmentType.Woods:
                secondEnvironment = InstantiateLayer(woodsEnvironments);
                break;
        }
    }

    GameObject InstantiateLayer(List<GameObject> environmentList)
    {
        int randomIndex = UnityEngine.Random.Range(0, environmentList.Count);
        return GameObject.Instantiate(environmentList[randomIndex], new Vector3(distanceRange, 0f, 0f),
            Quaternion.identity);
    }
}
