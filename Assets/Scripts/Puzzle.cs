using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;

    private int emptyLocation;
    private int size;
    //private bool shuffling = false;

    private int checkpoints;

    // Start is called before the first frame update

     private void CreateGamePieces(float gapThickness) {
    // This is the width of each tile.
    float width = 1 / (float)size;
    for (int row = 0; row < size; row++) {
      for (int col = 0; col < size; col++) {
        Transform piece = Instantiate(piecePrefab, gameTransform);
        //pieces.Add(piece);
        // Pieces will be in a game board going from -1 to +1.
        piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                          +1 - (2 * width * row) - width,
                                          0);
        piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
        piece.name = $"{(row * size) + col}";
        // We want an empty space in the bottom right.
        if ((row == size - 1) && (col == size - 1)) {
          emptyLocation = (size * size) - 1;
          piece.gameObject.SetActive(false);
        } else {
          // We want to map the UV coordinates appropriately, they are 0->1.
          float gap = gapThickness / 2;
          Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
          Vector2[] uv = new Vector2[4];
          // UV coord order: (0, 1), (1, 1), (0, 0), (1, 0)
          uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
          uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
          uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
          uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
          // Assign our new UVs to the mesh.
          mesh.uv = uv;
        }
      }
    }
  }
    void Start()
    {
        //pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);
    }

    // Update is called once per frame
    void Update()
    {
      /*if (!shuffling) 
      {
        shuffling = true;
        StartCoroutine(WaitShuffle(0.5f));
      }*/
    }

    /*private IEnumerator WaitShuffle(float duration) 
    {
      yield return new WaitForSeconds(duration);
      Shuffle();
      shuffling = false;
      }
      
      private void Shuffle() {
        int count = 0;
        int last = 0;
        while (count < (size * size * size)) {
          // Pick a random location.
          int rnd = Random.Range(0, size * size);
          // Only thing we forbid is undoing the last move.
          if (rnd == last) { continue; }
          last = emptyLocation;
          // Try surrounding spaces looking for valid move.
          if (SwapIfValid(rnd, -size, size)) {
            count++;
            } else if (SwapIfValid(rnd, +size, size)) {
              count++;
              } else if (SwapIfValid(rnd, -1, 0)) {
                count++;
                } else if (SwapIfValid(rnd, +1, size - 1)) {
                  count++;
                  }
        }
      }*/

    public void PuzzleComplete()
    {
        checkpoints ++;
        //authManager.GetLeaderDetails(quizpoints, checkpoints);

    }
}
