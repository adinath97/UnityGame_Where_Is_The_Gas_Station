using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = .5f;
    Material myMaterial;
    Vector2 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f,scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.miles % 5 == 0) {
            scrollSpeed += .01f;
        }
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
