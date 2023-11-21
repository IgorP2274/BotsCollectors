using UnityEngine;

public class CreateFlag : MonoBehaviour
{
    [SerializeField] private Flag _flag;

    public Flag Flag => _flag;

    private Flag _flagForBild = null;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (_flagForBild == null)
                    _flagForBild = Instantiate(_flag, hit.transform.position, Quaternion.identity);
                else 
                    _flagForBild.transform.position = hit.point;
            }
        }

    }

    public void Switch() 
    {
        enabled = !enabled;
    }
}
