// using UnityEngine;

// public class AnswerChecker : MonoBehaviour
// {
//     private GameManager gameManager;

//     void Start()
//     {
//         // نجيب الريفرنس بتاع GameManager من المشهد
//         gameManager = FindObjectOfType<GameManager>();
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         // لو خبطت في Box
//         Box box = other.GetComponent<Box>();
//         if (box != null)
//         {
//             if (box.IsCorrect()) // دالة نضيفها في Box
//             {
//                 gameManager.CorrectAnswerChosen();
//             }
//             else
//             {
//                 // استدعاء دالة الإجابة الخاطئة
//                 gameManager.WrongAnswerChosen();
//             }
//         }
//     }
// }
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Box box = other.GetComponent<Box>();
        if (box != null)
        {
            // --- السطر الجديد ---
            // إخفاء المكعب الذي تم الاصطدام به فورًا
            other.gameObject.SetActive(false);
            // --- نهاية السطر الجديد ---

            if (box.IsCorrect())
            {
                gameManager.CorrectAnswerChosen();
            }
            else
            {
                gameManager.WrongAnswerChosen();
            }
        }
    }
}