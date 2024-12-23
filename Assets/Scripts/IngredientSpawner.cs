using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> goodIngredients;
    [SerializeField] private List<GameObject> badIngredients;
    
    [Range(0f, 100f)]
    [SerializeField] private float goodIngredientProbability = 75f;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateIngredient();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateIngredient()
    {
        bool isGoodIngredient = GenerateIngredientType();

        if (isGoodIngredient && goodIngredients.Count != 0)
        {
            GameObject ingredient = InstantiateIngredient(goodIngredients);
            ingredient.tag = "Good Ingredient";
        }
        else if (!isGoodIngredient && badIngredients.Count != 0)
        {
            GameObject ingredient = InstantiateIngredient(badIngredients);
            ingredient.tag = "Bad Ingredient";
        }
    }
    
    // Returns true for good ingredients and false for bad ingredients
    bool GenerateIngredientType()
    {
        return UnityEngine.Random.Range(0, 101) < goodIngredientProbability;
    }

    GameObject InstantiateIngredient(List<GameObject> ingredients)
    {
        var randomIndex = UnityEngine.Random.Range(0, ingredients.Count);
        return GameObject.Instantiate(ingredients[randomIndex],
            gameObject.transform.position,
            Quaternion.identity,
            gameObject.transform
        );
    }
}
