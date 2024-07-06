using UnityEngine;

public class PuzzleBox : MonoBehaviour
{
    public BoxCollider2D[] puzzleSlots; // Set this array in the Unity Editor with the puzzle slot colliders

    public bool IsOverPuzzleBox(Vector3 position)
    {
        position.z = transform.position.z;
        // Check if the given position is inside the puzzle box collider
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        return boxCollider.bounds.Contains(position);
    }

    public bool CheckPlacement(PuzzlePiece puzzlePiece)
    {
        Vector3 position = puzzlePiece.transform.position;
        
        // Check if the puzzle piece is dropped in the correct slot
        for (int i = 0; i < puzzleSlots.Length; i++)
        {
            position.z = puzzleSlots[i].transform.position.z;
            if (puzzleSlots[i].bounds.Contains(position))
            {
                // Check if the index matches
                return i == puzzlePiece.pieceIndex;
            }
        }
        return false;
    }
}
