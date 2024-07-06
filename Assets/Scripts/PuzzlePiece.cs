using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public int pieceIndex; // Set this in the Unity Editor for each puzzle piece
    private Vector3 initialPosition;
    private bool isDragging = false;
    private bool placed = false;
    public SceneController sceneController;

    // Reference to the puzzle box
    public PuzzleBox puzzleBox;

    public Vector3 placementLocation;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            // Update puzzle piece position while dragging
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            // Check if the puzzle piece is over the puzzle box
            if (puzzleBox != null && puzzleBox.IsOverPuzzleBox(transform.position))
            {
                // Check if the piece is dropped on the correct slot
                if (puzzleBox.CheckPlacement(this))
                {
                    // Puzzle piece is placed correctly
                    //Debug.Log("Piece placed correctly!");
                    transform.position = placementLocation;
                    sceneController.AddScore();
                    placed = true;
                }
                else
                {
                    // Puzzle piece is not in the correct slot, return to the initial position
                    ReturnToInitialPosition();
                }
            }
            else
            {
                // Puzzle piece is not over the puzzle box, return to the initial position
                ReturnToInitialPosition();
            }
        }
    }

    void OnMouseDown()
    {
        if(!placed)
            isDragging = true;
    }

    void ReturnToInitialPosition()
    {
        transform.position = initialPosition;
    }
}
