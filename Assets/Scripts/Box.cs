using UnityEngine;
using TMPro;

public class Box : MonoBehaviour
{
    private int number;
    private bool isCorrect;
    private GameManager manager;
    public TextMeshPro textMesh;

    public void SetNumber(int num, bool correct, GameManager gm)
    {
        number = num;
        isCorrect = correct;
        manager = gm;
        textMesh.text = num.ToString();
    }

    public bool IsCorrect()
    {
        return isCorrect;
    }
}
