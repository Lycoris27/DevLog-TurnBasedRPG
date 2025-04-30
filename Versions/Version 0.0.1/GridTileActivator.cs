using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTileActivator : MonoBehaviour
{
    public GameObject atkZoneTile;
    public GameObject movementTile;


    public void ActivateMoveTile()
    {
        movementTile.SetActive(true);
    }
    public void DeactivateMoveTile()
    {
        movementTile.SetActive(false);
    }

    public void ActivateAttackTile()
    {
        atkZoneTile.SetActive(true);
    }
    public void DeactivateAttackTile()
    {
        atkZoneTile.SetActive(false);
    }
}
