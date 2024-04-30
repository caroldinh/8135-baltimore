using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressImage : MonoBehaviour
{

    public scrapBook scrapbook;
    public List<Sprite> progressImages;
    private Image myImage;
    private int numComplete = 0;
    private int numTotal = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        myImage.sprite = progressImages[0];
        foreach (scrapBookPage page in scrapbook.pages)
        {
            if (page != null)
            {
                numTotal += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void updateProgress()
    {
        numComplete += 1;
        myImage.sprite = progressImages[numComplete];
    }
}
