using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Object
{
    private float restartCoinX = -237.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    protected override void Update()
    {
        if (GameManager.instance.PlayerActive)
        {
            base.Update();
        }

    }

    public void resetPosition()
    {
        Vector3 newPos = new Vector3(-239.006f, transform.position.y, transform.position.z);
        transform.position = newPos;
    }

    public void RestartCoin()
    {
        Vector3 newPos = new Vector3(restartCoinX, transform.position.y, transform.position.z);
        transform.position = newPos;
    }
}
