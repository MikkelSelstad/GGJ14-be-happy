using UnityEngine;
using System.Collections;

public interface IThing  
{
    IThing Pickup();

    void Drop();

    void Use();
	
}
