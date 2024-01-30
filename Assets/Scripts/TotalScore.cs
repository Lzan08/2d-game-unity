using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private Text totalPaperText;

    void Start()
    {
        // Mengambil total kertas dari PlayerPrefs
        int totalPapers = 0;

        // Iterasi melalui semua level
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string levelName = SceneUtility.GetScenePathByBuildIndex(i);
            levelName = System.IO.Path.GetFileNameWithoutExtension(levelName);

            // Mengambil jumlah kertas dari setiap level
            int papersInLevel = PlayerPrefs.GetInt(levelName + "_Paper", 0);

            // Menambahkannya ke total kertas
            totalPapers += papersInLevel;
        }

        // Menampilkan total kertas pada layar akhir
        if (totalPaperText != null)
        {
            totalPaperText.text = "Total Papers: " + totalPapers.ToString();
        }
    }
}
