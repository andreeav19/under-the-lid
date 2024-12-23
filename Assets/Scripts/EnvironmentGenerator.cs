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
    [SerializeField] private GameObject cityPrefab;
    [SerializeField] private float speed = 4.5f;
    [SerializeField] private float distanceRange = 24.35f;
    [SerializeField] private int maxEnvironments = 4;
    [SerializeField] private int cityFrequency = 8;
    
    private GameObject firstEnvironment;
    private GameObject secondEnvironment;
    [HideInInspector] public EnvironmentType currentEnvironmentType;
    private int remainingEnvironments;
    private int totalEnvironments;
    
    // Start is called before the first frame update
    void Start()
    {
        firstEnvironment = GameObject.Instantiate(woodsEnvironments[0]);
        secondEnvironment = GameObject.Instantiate(woodsEnvironments[1], new Vector3(distanceRange, 0f, 0f),
            Quaternion.identity);
        currentEnvironmentType = EnvironmentType.Woods;
        remainingEnvironments = 1;
        totalEnvironments = 2;
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
        bool isCity = totalEnvironments % cityFrequency == 0;
        switch (environmentType)
        {
            case EnvironmentType.Desert:
                secondEnvironment = InstantiateLayer(desertEnvironments, isCity);
                break;
            case EnvironmentType.Graveyard:
                secondEnvironment = InstantiateLayer(graveyardEnvironments, isCity);
                break;
            case EnvironmentType.Snow:
                secondEnvironment = InstantiateLayer(snowEnvironments, isCity);
                break;
            case EnvironmentType.Woods:
                secondEnvironment = InstantiateLayer(woodsEnvironments, isCity);
                break;
        }
    }

    GameObject InstantiateLayer(List<GameObject> environmentList, bool isCity=false)
    {
        totalEnvironments++;
        if (isCity)
        {
            GameObject returnObject = GameObject.Instantiate(environmentList[0], new Vector3(distanceRange, 0f, 0f),
                Quaternion.identity);
            GameObject.Instantiate(cityPrefab, new Vector3(distanceRange, 0f, 0f), Quaternion.identity, 
                returnObject.transform);
            return returnObject;
        }
        int randomIndex = UnityEngine.Random.Range(0, environmentList.Count);
        return GameObject.Instantiate(environmentList[randomIndex], new Vector3(distanceRange, 0f, 0f),
            Quaternion.identity);
    }
}
