void HandleInput() 
{
    if (Input.GetKeyDown(KeyCode.H) || (Input.GetKeyDown(KeyCode.Escape) && helpPanelCloseButton.activeSelf)) 
    {
        Switch();
    }


    if (mode == "selecting") 
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            Pencil_On_Board = false; 
        }
        
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mousePosition);
            if (clickedCollider != null && clickedCollider.CompareTag("Cell"))
            {
                Pencil_On_Board = true;
                markedCell1 = clickedCollider.gameObject;
                cell1Script = markedCell1.GetComponent<Cell>();
                cell1Script.spriteRenderer.color = Color.yellow;
            }
        }
        if (Input.GetMouseButton(0) && Pencil_On_Board) 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mousePosition);
            if (clickedCollider != null && clickedCollider.CompareTag("Cell"))
            {
                markedCell2 = clickedCollider.gameObject;
                cell2Script = markedCell2.GetComponent<Cell>();
                cell2Script.spriteRenderer.color = Color.yellow;
            }
        }

        HighlightSelectedCells(); 
    }
    else if (mode == "pasting") 
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) 
        {
            PasteCells();
        }
        else if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            PivotStructure();
        }
        else if (Input.GetKeyDown(KeyCode.E)) 
        {
            RotateStructure();
        }
        else if (Input.GetKeyDown(KeyCode.X)) 
        {
            pastingIgnoreEmpty = !pastingIgnoreEmpty;
        }
        else if (Input.GetKeyDown(KeyCode.I)) 
        {
            pastingInverted = !pastingInverted;
        }
        else if (Input.GetKeyDown(KeyCode.T)) 
        {
            pastingTransposed = !pastingTransposed;
        }

        PasteCells(true); 
    }
    else 
    {

        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !EventSystem.current.IsPointerOverGameObject()) 
        {
            if(!simulationRunning) 
            {
                SaveUndoStates();
                redoStack.Clear();
            }
            Pencil_On_Board = true;
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) 
        {
            Pencil_On_Board = false;
        }

        if(Input.GetMouseButton(0) && Pencil_On_Board) 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mousePosition);
            if (clickedCollider != null)
            {
                clickedCollider.GetComponent<Cell>().HandleLeftClick();
            }
        }            
        else if(Input.GetMouseButton(1) && Pencil_On_Board) 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mousePosition);
            if (clickedCollider != null)
            {
                clickedCollider.GetComponent<Cell>().HandleRightClick();
            }
        }
    }
}