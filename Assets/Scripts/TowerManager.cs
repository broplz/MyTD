using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;
using UnityEngine;

public class TowerManager : Loader<TowerManager>
{
    private TowerBtn towerBtnPressed;

    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

            if (hit.collider.CompareTag("TowerSide"))
            {
                hit.collider.tag = "TowerSideFull";
                PlaceTower(hit);
            }
        }

        if (spriteRenderer.enabled)
        {
            FollowMouse();
        }
    }

    public void PlaceTower(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null)
        {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            DisableDrag();
        }
    }

    private void SelectedTower(TowerBtn towerSelected)
    {
        towerBtnPressed = towerSelected;
        EnableDrag(towerBtnPressed.DragSprite);
        Debug.Log($"Tower Button Pressed {towerBtnPressed.gameObject}");
    }

    private void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void EnableDrag(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }

    private void DisableDrag()
    {
        spriteRenderer.enabled = false;
    }
}
