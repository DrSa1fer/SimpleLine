# Commands

---
## 1. Dependencies
---

### Namespaces
All the attributes required to register commands are in the namespace ``SimpleLineLibrary.Setup``.
### Types
- ``[CommandDefinitions]`` - is used to define groups of commands.
- ``[Command]`` - is needed to define the command. 
- ``[Description]`` - is needed to add a description to a command or parameter.
- ``[CustomKeys]`` - is needed to set your own parameter keys.
  
---
## 2. Naming
---

The command name can contains ``Letters``, ``Numbers``, "``-``", but must start with ``Letters``. 
Examples:
- ``make`` 
- ``t123``
- ``new-file``

---
## 3. Definition
---

### Preparation
We need to prepare the class and implement the methods in it. For example, let's create a ``MyCommand`` class and implement the ``Say`` method in it. 
It looks like this:
```csharp
public class MyCommand
{
    public void Say(string msg)
    {
        Console.WriteLine($"I say: {msg}");
    }
}
```

> [!WARNING]
> Classes and methods must have public access modifiers - ``public``, otherwise they will simply be inaccessible to SimpleLine

### Add attributes
In the class that we have defined, we will add a few new lines.

##### - Add namespace
It contains a definition of the attributes we need.
```csharp 
using SimpleLineLibrary.Setup;
```
##### - Marking the class with the ``[CommandDefinitions]`` attribute
This is necessary so that the system knows in the future that there may be command definitions in this class.
```csharp
[CommandDefinitions]
public class MyCommand { ... }
```
##### - Marking the method with the ``[Command]`` attribute
This is necessary so that the system can use the method as a command and give a name by which it will be accessible.
```csharp 
[Command("say")]
public void Say(string msg) { ... }
```

---
## 4. Additionally
---

##### Marking the method with the ``[Description]`` attribute
This is necessary so that the system receives a description of the command and displays it if necessary. 
If the attribute is not applied, the description will be empty.
```csharp 
[Command("say")]
[Description("Command print your message")]
public void Say(string msg) { ... }
```
##### Marking the parameter of method with the ``[Description]`` attribute
This is necessary so that the system receives a description of the command and displays it if necessary. 
If the attribute is not applied, the description will be empty.
```csharp 
[Command("say")]
[Description("Command print your message")]
public void Say([Description("Your message")] string msg) { ... }
```
##### Marking the parameter of method with the ``[CustomKeys("-m", "--msg")]`` attribute
This is necessary in order to specify your own parameter keys that will be used during the retrieval of values. 
In case the attribute is not applied, keys will be created automatically.
```csharp 
[Command("say")]
[Description("Command print your message")]
public void Say([Description("Your message")] [CustomKeys("-m", "--msg")] string msg) { ... }
```

---
## 5. Nested commands
---

Commands can be nested within another command, for example, let's take ``math``, we want to add a nested command to it to get ``math sum``. To do this, we need to pass the names of the commands separated by a space:
```csharp
[Command("math sum")]
public void Sum(int x, int y) { ... }
```
Or use the grouping. More details in the next paragraph

---
## 6. Grouping
---

To understand why this is necessary, we should consider an example.
Let's take the example of the ``math`` command and the ``sum`` nested command:
```csharp
public class MathCommands
{
    public void Math()
    {
        Console.WriteLine("Math is cool!");
    }

    public void Sum(int x, int y)
    {
        Console.WriteLine($"Result: {x + y}");
    }
}
```

The first option for solving the problem, most likely, that you would use:

```csharp
using SimpleLineLibrary.Setup;

[CommandDefinitions]
public class MathCommands
{
    [Command("math")]
    public void Math() { ... }

    [Command("math sum")]
    public void Sum(int x, int y) { ... }
}
```
In that case, everything is correct, but it can be simplified. Let's apply grouping. To do this, there is an overload in the ``[CommandDefinitions]`` attribute that takes the name of the command to be attached to. Here's the same code. works exactly the same as in the previous example, but this time using grouping:
```csharp
using SimpleLineLibrary.Setup;

[CommandDefinitions("math")]
public class MathCommands
{
    [Command("@")]
    public void Math() { ... }

    [Command("sum")]
    public void Sum(int x, int y) { ... }
}
```
> This becomes more relevant when the depth of nesting grows

The ``@`` symbol is a contextual function of the library that allows you to define the command to which the group is bound, in this case ``math``.