using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    private int x;
    private int y;

    public int X { get { return x; } set { if (isMovable()) { x = value; } } }
    public int Y { get { return y; } set { if (isMovable()) { y = value; } } }

    private Grid.PieceType type;
    public Grid.PieceType Type { get { return type; } }
    
    private Grid grid;
    public Grid GridRef { get { return grid; } }
    private MovablePiece movableComponent;
    public MovablePiece MovableComponent { get { return movableComponent; } }

    private ColorPiece colorComponent;
    public ColorPiece ColorComponent { get { return colorComponent; } }

    private void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        grid.EnterPiece(this);
    }

    private void OnMouseDown()
    {
        grid.PressPiece(this);
    }

    private void OnMouseUp()
    {
        grid.ReleasePiece();
        print("Released");
    }


    public void Init(int _x, int _y, Grid _grid, Grid.PieceType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }

    public bool isMovable()
    {
        return movableComponent != null;
    }
    public bool isColored()
    {
        return colorComponent != null;
    }
}
