using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    [Header("Held Scripts")]
    [SerializeField] private GridDetector gridDetector;

    [Header("Positions")]
    [SerializeField] private Vector2Int position;


    private bool canCharacterMove = true;

    private CharacterMovement eMovement;
    private MovementDisplay eDisplay;
    private CharacterSheet eSheet;

    private void Awake()
    {
        eMovement = GetComponent<CharacterMovement>();
        eDisplay = GetComponent<MovementDisplay>();
        eSheet = GetComponent<CharacterSheet>();
    }


    public Vector2Int ReturnPosition() { return position; }

    private void OnEnable() {
        if (!Application.isPlaying) {
            SetPosition(position);
        }
    }

    private void OnValidate() {
        if (!Application.isPlaying) {
            SetPosition(position);
        }
    }

    public void SetPosition(Vector2Int pos)
    {
        position = pos;
        transform.position = new Vector3(pos.x + 0.5f, 0, pos.y + 0.5f);
    }
    
    public bool GetIfMove()
    {
        return canCharacterMove;
    }
    public void ToggleMove()
    {
        if (canCharacterMove)
        {
            canCharacterMove = false;
        }
        else if (!canCharacterMove)
        {
            canCharacterMove = true;
        }
    }
    
    public void AutoMoveCharacter(Dictionary<Vector2Int, int> moveLocations)
    {
        // Retrieve movement range from the player's character
        int movement = eSheet.GetMovement();
        int range = eSheet.GetRange();

        if (moveLocations.Count <= movement + range)
        {
            foreach (var entry in moveLocations)
            {
                if(entry.Value == moveLocations.Count - range)
                {
                    SetPosition(entry.Key);
                }
            }
        }
        else if (moveLocations.Count > movement)
        {
            foreach (var entry in moveLocations)
            {
                if (entry.Value == movement)
                {
                    print("Biggus dickus");
                    SetPosition(entry.Key);
                }
            }
        }
    }
}