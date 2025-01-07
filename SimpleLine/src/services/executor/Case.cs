namespace simpleline.services.executor;

internal abstract class Case
{
    public abstract bool Is(Context context);
    public abstract void Invoke(Context context);
}