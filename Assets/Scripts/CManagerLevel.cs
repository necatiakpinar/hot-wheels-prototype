using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class CManagerLevel : MonoBehaviour
{
    public int LevelIndex = 0;

    public float WaitTimeForNextLevel;

    private void Reset()
    {
        this.WaitTimeForNextLevel = 3;
    }
    public void GenerateLevel()
    {
        // if(this.Levels.Length == 0) LoadLevelResources();

        // if(this.LevelIndex >= Levels.Length) return;
        
        // CLevel level = GameObject.Instantiate(this.Levels[this.LevelIndex]).GetComponent<CLevel>();
        // CWorld.Main.SetLevel(level);
    }
    public void LoadNextLevel()
    {
        this.LevelIndex++;
        StartCoroutine(Coroutine_LevelGeneration());
    }
    public void Restart()
    {
        StartCoroutine(Coroutine_LevelGeneration());
    }
    private IEnumerator Coroutine_LevelGeneration()
    {
        yield return new WaitForSeconds(this.WaitTimeForNextLevel);
        SceneManager.LoadScene(this.LevelIndex);
        // CWorld.Main.DestroyLastLevel();
        // GenerateLevel();
    }

    // [ContextMenu("Load Levels")]
    // public void LoadLevelResources() => Levels = Resources.LoadAll<GameObject>("Prefabs/Levels");
}
