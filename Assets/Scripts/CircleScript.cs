using UnityEngine;
using System.Collections;

public class CircleScript : MonoBehaviour
{
    public GameObject Circle;
    public CircleCollider2D collider;
    public int nOfIterations;
    public float growthScalar;
    public int sortingOrder;
    public int moneyValue;
    [Header("Customisable Values")]
    public float growthSpeed = 0.025f;
    public int iterationMax = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnCircle", 0f, growthSpeed);
        growthScalar = 0f;

        collider = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        moneyValue = nOfIterations * 2;
    }


    public void SpawnCircle()
    {
        Color lerpedColour = Color.white;
        nOfIterations++;
        sortingOrder--;
        if (nOfIterations < iterationMax)
        {
            growthScalar += Random.Range(0.00025f, (0.125f / 2));
            GameObject CircleInstance = Instantiate(Circle);
            CircleInstance.transform.parent = this.gameObject.transform;
            CircleInstance.transform.position = transform.position;
            CircleInstance.transform.localScale = new Vector2(1f, 1f) * growthScalar;
            lerpedColour = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));
            CircleInstance.GetComponent<SpriteRenderer>().color = lerpedColour;
            CircleInstance.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        }
        else
        {
            CancelInvoke("SpawnCircle");
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("We get money!");
    }
}
