using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour {

    public List<Transform> pickupsStage1 = new List<Transform>();
    public List<Transform> pickupsStage2 = new List<Transform>();
    public List<Transform> pickupsStage3 = new List<Transform>();

    // Use this for initialization
    void Start () {
        //Stage1 PickUps
        distributePickups();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void distributePickups()
    {
        int borderLeftX = 15;
        int borderRightX = 1;
        int borderTopY = 22;
        int borderBottomY = 3;
     
        foreach (Transform item in pickupsStage1)
        {
            createItem(item, Random.Range(borderRightX, borderLeftX), Random.Range(borderBottomY, borderTopY));
        }

        borderBottomY += 24;
        borderTopY += 24;

        foreach (Transform item in pickupsStage2)
        {
            createItem(item, Random.Range(borderRightX, borderLeftX), Random.Range(borderBottomY, borderTopY));
        }

        borderBottomY += 24;
        borderTopY += 24;

        foreach (Transform item in pickupsStage3)
        {
            createItem(item, Random.Range(borderRightX, borderLeftX), Random.Range(borderBottomY, borderTopY));
        }

    }

    void createItem(Transform pickup, float positionX, float positionY)
    {
        Instantiate(pickup, new Vector3(positionX, positionY, 0), Quaternion.identity);
    }


}
