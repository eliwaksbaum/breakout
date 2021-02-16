
public class LevelLoad : Callable
{
    public bool Next;
    public int levelIndex;
    public GameEvent serve;

    public override void Call()
    {
        if (Next)
        {
            LevelLoader.LoadNext();
        }
        else
        {
            LevelLoader.Load(levelIndex);
        }
        serve.Call();
    }
}