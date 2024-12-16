using simpleline.models;

namespace simpleline.services.registration;

public abstract class RegistrarBase
{
    public abstract Node Register(Context context);
}