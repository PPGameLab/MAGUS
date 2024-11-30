using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject[] panels; // Массив панелей

    // Метод для загрузки сцены по имени
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Метод для выхода из игры
    public void ExitGame()
    {
        Application.Quit();
    }

    // Метод для паузы игры
    public void PauseGame()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    // Метод для переключения панелей
    public void ShowPanel(int panelIndex)
    {
        if (panels == null || panels.Length == 0)
        {
            Debug.LogWarning("Панели не настроены в инспекторе!");
            return;
        }

        if (panelIndex < 0 || panelIndex >= panels.Length)
        {
            Debug.LogWarning($"Индекс панели {panelIndex} вне диапазона! Доступно: 0-{panels.Length - 1}");
            return;
        }

        // Деактивируем все панели
        foreach (var panel in panels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }

        // Активируем выбранную панель
        if (panels[panelIndex] != null)
        {
            panels[panelIndex].SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Панель с индексом {panelIndex} отсутствует!");
        }
    }
}
