using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int papers = 0;
    [SerializeField] private Text paperText;
    private string currentLevel;

    private void Start()
    {
        // Mendapatkan nama level saat ini
        currentLevel = SceneManager.GetActiveScene().name;

        // Reset skor ke 0 setiap kali permainan dimulai
        ResetScore();

        // Mengambil jumlah kertas dan level dari PlayerPrefs saat permainan dimulai
        papers = PlayerPrefs.GetInt(currentLevel + "_Paper", 0);
        UpdatePaperText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            Destroy(collision.gameObject);
            papers++;

            // Menyimpan jumlah kertas untuk level saat ini
            PlayerPrefs.SetInt(currentLevel + "_Paper", papers);
            PlayerPrefs.Save(); // Disarankan untuk memanggil Save setelah melakukan perubahan

            Debug.Log("Jumlah Kertas " + currentLevel + ": " + papers);

            UpdatePaperText();
        }
    }

    // Fungsi untuk memperbarui teks jumlah kertas
    private void UpdatePaperText()
    {
        if (paperText != null)
        {
            paperText.text = "Papers: " + papers.ToString();
        }
    }

    // Fungsi untuk mereset skor ke 0
    private void ResetScore()
    {
        papers = 0;
        PlayerPrefs.SetInt(currentLevel + "_Paper", papers);
        PlayerPrefs.Save();
        UpdatePaperText();
    }
}
