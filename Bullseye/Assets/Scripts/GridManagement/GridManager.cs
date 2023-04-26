using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public GameObject gridSpacePrefab;//Need input
    public Transform gridParent;//The parent board which grids will be instantiated on

    private GridSpace[,] gridSpaces;

    private void Start()
    {
        CreateGrid();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateGrid()
    {
        int width = GameManager.Instance.gridWidth;
        int height = GameManager.Instance.gridHeight;
        gridSpaces = new GridSpace[width, height];//width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject gridSpaceObj = Instantiate(gridSpacePrefab, new Vector3(x, y, 0), Quaternion.identity, gridParent);
                GridSpace gridSpace = gridSpaceObj.GetComponent<GridSpace>();//Instantiate grid space
                gridSpace.Initialize(x, y);
                gridSpaces[x, y] = gridSpace;
            }
        }
    }

    public GridSpace GetGridSpace(int x, int y)
    {
        if (x >= 0 && x < GameManager.Instance.gridWidth && y >= 0 && y < GameManager.Instance.gridHeight)
        {
            return gridSpaces[x, y];
        }
        return null;
    }

    public bool IsGridSpaceAvailable(int x, int y)
    {
        GridSpace gridSpace = GetGridSpace(x, y);
        return gridSpace != null && !gridSpace.IsOccupied;
    }

    public bool PlaceCardOnGridSpace(Card card, int x, int y)
    {
        GridSpace gridSpace = GetGridSpace(x, y);
        if (gridSpace != null && !gridSpace.IsOccupied)
        {
            gridSpace.PlaceCard(card);
            return true;
        }
        return false;
    }

    public void ClearGrid()
    {
        //implement the clear logic**************need modify
    }

    public bool AllGridSpacesFilled()//************* need modify
    {
        return false;
    }

    public void RemoveSequenceFromGrid(Sequence sequence)//********* need modify
    {

    }
}