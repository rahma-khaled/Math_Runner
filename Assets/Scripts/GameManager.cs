using UnityEngine;
using TMPro;

// هذا السطر يضمن وجود مكون AudioSource على الكائن
[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public GameObject[] answerBoxes; // 3 Boxes
    public float boxSpacing = 3.0f;

    // --- المتغيرات الجديدة الخاصة بالأصوات ---
    public AudioClip correctSound; // ملف صوت الإجابة الصحيحة
    public AudioClip wrongSound;   // ملف صوت الإجابة الخاطئة
    private AudioSource audioSource; // المتغير الذي سيقوم بتشغيل الأصوات
    // ------------------------------------

    private int correctAnswer;
    private int score = 0;

    void Start()
    {
        // نحصل على مكون AudioSource المرفق بهذا الكائن لتشغيل الأصوات من خلاله
        audioSource = GetComponent<AudioSource>();
        GenerateQuestion();
    }

    public void GenerateQuestion()
    {
        // إعادة المكعبات إلى مواقع بداية ثابتة ومنظمة
        for (int i = 0; i < answerBoxes.Length; i++)
        {
            // إعادة تفعيل المكعب إذا كان مخفيًا
            answerBoxes[i].SetActive(true);

            // حساب الموقع الجديد لكل مكعب (يسار، وسط، يمين)
            float xPos = (i - 1) * boxSpacing;

            // نستخدم نفس إعدادات الـ Y والـ Z من سكريبت MoveBackward
            Vector3 startPos = new Vector3(xPos, answerBoxes[i].transform.position.y, 50f); // 50f هو startZ
            answerBoxes[i].transform.position = startPos;
        }

        int a = Random.Range(1, 20);
        int b = Random.Range(1, 20);
        correctAnswer = a + b;

        questionText.text = a + " + " + b + " = ?";

        int correctIndex = Random.Range(0, answerBoxes.Length);

        for (int i = 0; i < answerBoxes.Length; i++)
        {
            int answerValue;

            if (i == correctIndex)
                answerValue = correctAnswer;
            else
            {
                do
                {
                    answerValue = correctAnswer + Random.Range(-5, 5);
                } while (answerValue == correctAnswer);
            }

            Box boxScript = answerBoxes[i].GetComponent<Box>();
            boxScript.SetNumber(answerValue, i == correctIndex, this);
        }
    }

    public void CorrectAnswerChosen()
    {
        score += 1;
        scoreText.text = "Score: " + score;

        // تشغيل صوت الإجابة الصحيحة
        if (correctSound != null)
        {
            audioSource.PlayOneShot(correctSound);
        }

        GenerateQuestion();
    }

    public void WrongAnswerChosen()
    {
        score -= 1;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;

        // تشغيل صوت الإجابة الخاطئة
        if (wrongSound != null)
        {
            audioSource.PlayOneShot(wrongSound);
        }

        GenerateQuestion();
    }
}