using UnityEngine;
using Alteruna;
using TMPro;

/// <summary>
/// Class <c>ExampleSynchronizable</c> is an example of how a <c>Synchronizable</c> can be defined.
/// </summary>
/// 
public class PlayerDataSynchronizable : Synchronizable
{
    
    public int Score;
    private int _oldScore;

    public TextMeshPro scoreText;

    public override void DisassembleData(Reader reader, byte LOD)
    {
        //base.DisassembleData(reader, LOD);
        Score = reader.ReadInt();
        scoreText.text = reader.ReadString();

        _oldScore = Score;
    }

    public override void AssembleData(Writer writer, byte LOD)
    {
        //base.AssembleData(writer, LOD);
        writer.Write(Score);
        writer.Write(scoreText.text);
    }

    private void Update()
    {
        //base.Update();
        
        if (Score != _oldScore)
        {
            
            _oldScore = Score;

            scoreText.text = Score.ToString();

            gameObject.GetComponentInParent<Transform>().localScale = new Vector3(1f + Score/1000f, 1f + Score/1000f, 1f);
            
            Commit();
        }
        
        
        base.SyncUpdate();
    }
}
