using simpleline.attributes;
using simpleline.models.commands;
using simpleline.services;
using simpleline.services.router;

namespace simpleline.unit.services.router;

[TestFixture]
public class RouterTest {
    private readonly Router _router = new Router();

    private readonly Command[] _commands = [
        new([new RouteAttribute("test")], [], []),
        new([new RouteAttribute("not test")], [], []),
        new([new RouteAttribute("test test")], [], []),
        new([new RouteAttribute("not test not test")], [], []),
    ];

    public void Test1() {
        var input = new Input([Symbol.CreateValue("test"), Symbol.CreateValue("test")]);

        var c = _router.Route(_commands, input);

        if (c != _commands[2]) {
            Assert.Fail();
        }
        else {
            Assert.Pass();
        }
    }
}