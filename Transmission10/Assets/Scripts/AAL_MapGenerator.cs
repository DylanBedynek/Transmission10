using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAL_MapGenerator : MonoBehaviour {

    public Texture2D mapToBeAdded;

    public AAL_ColorPrefab[] colorMapping;
	// Use this for initialization
	void Start () {
        GenerateLevel();

	}

    void GenerateLevel()
    {
        for(int x =0; x<mapToBeAdded.width;x++)
        {
            for (int y=0; y<mapToBeAdded.height; y++)
            {
                GenerateTile(x,y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color colorOfPixel =  mapToBeAdded.GetPixel(x, y);

        if(colorOfPixel.a == 0)
        {
            //transparent pixels
            return;
        }

        Debug.Log(colorOfPixel);

        foreach (AAL_ColorPrefab pixelMapping in colorMapping)
        {
            if (pixelMapping.color == Color.red)
            {
                Vector3 position = new Vector3(x, 0f, y);
                Instantiate(pixelMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
