using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 10; 
    
    protected override void OnCollect()
    {
        if (!_collected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _collected = true;
                GetComponent<SpriteRenderer>().sprite = emptyChest; 
                Debug.Log("Grant pesos: " + pesosAmount);
            }
        }
    }
}