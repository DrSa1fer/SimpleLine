using simpleline.user.models;

namespace simpleline.user.views;

public class TestView(TestModel testModel)
{
    public override string ToString()
    {
        return "TestView";
    }
}