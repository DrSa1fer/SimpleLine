using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions("test")]
    public class TestCommand
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test test")]
    public class TestCommand1
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test test test")]
    public class TestCommand2
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test test test test")]
    public class TestCommand3
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test4")]
    public class TestCommand4
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test5")]
    public class TestCommand5
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test6")]
    public class TestCommand6
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("testq")]
    public class TestCommandq
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test1q")]
    public class TestCommand1q
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test2q")]
    public class TestCommand2q
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test3q")]
    public class TestCommand3q
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test4q")]
    public class TestCommand4q
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test5q")]
    public class TestCommand5q
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test6q")]
    public class TestCommand6q
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }
}