using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class VocabularyTestGenerator : MonoBehaviour
{
    public TextAsset vocabularyData; // CSV 파일을 Unity Inspector에서 할당해야 합니다.
    public GameObject questionPrefab; // 질문을 표시할 프리팹
    public Transform questionPanel; // 질문을 표시할 패널

    private List<(string, string)> vocabularyList = new List<(string, string)>();

    void Start()
    {
        LoadVocabularyData();
        GenerateTest();
    }

    void LoadVocabularyData()
    {
        if (vocabularyData != null)
        {
            string[] lines = vocabularyData.text.Split('\n');

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (values.Length == 2)
                {
                    string english = values[0].Trim();
                    string korean = values[1].Trim();
                    vocabularyList.Add((english, korean));
                }
            }
        }
    }

    void GenerateTest()
    {
        List<(string, string)> shuffledVocabulary = vocabularyList.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < shuffledVocabulary.Count; i++)
        {
            // 질문 프리팹을 생성하고 부모를 questionPanel로 설정합니다.
            GameObject questionObject = Instantiate(questionPrefab, questionPanel);
            QuestionItem questionItem = questionObject.GetComponent<QuestionItem>();

            // 빈칸을 랜덤하게 설정합니다.
            int emptyIndex = Random.Range(0, 2);

            // 영어와 한글 단어를 표시합니다.
            if (emptyIndex == 0)
            {
                questionItem.SetQuestion(i + 1, shuffledVocabulary[i].Item1, "");
                //questionItem.SetAnswer(shuffledVocabulary[i].Item2);
            }
            else
            {
                questionItem.SetQuestion(i + 1, "", shuffledVocabulary[i].Item2);
                //questionItem.SetAnswer(shuffledVocabulary[i].Item1);
            }
        }
    }
}
