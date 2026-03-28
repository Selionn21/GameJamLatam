using UnityEngine;
using TMPro;

public class CanvasControl : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private PlayerRecollection playerCo;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = playerCo.playercoins.ToString();
    }
}
