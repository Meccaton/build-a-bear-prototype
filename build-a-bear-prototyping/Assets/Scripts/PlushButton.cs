using UnityEngine;
using UnityEngine.UI;

public class PlushButton : MonoBehaviour
{
    public int row;
    public int col;
    public CrossController crossInput; 

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    
    public void Init(int r, int c, string type)
    {
        row = r;
        col = c;
    }

    public void OnClick()
    {
        SwapManager.Instance.SelectPlush((Tile)this);
        crossInput.SetSelectedLine(true, row);
    }
    
}
