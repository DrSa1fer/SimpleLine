# Registration

---
## Command

#### Definition
Command is set of actions and options that work together that are declared
as class.

#### Example
```csharp
[Command]
public class YourClass; 
```

---
## Action

#### Definition
Action is the command action that needs to be performed that are declared
as method method.

#### Example

```csharp
[Command]
public class YourClass {   
    [Action]
    public void Action() {
        //CODE
    }
}
```

---
## Options

#### Definition

An option is a data that a command requests from 
the input for its execution.

#### Kinds

``[Parameter]`` - Gets data from input by key.

``[Argument]`` - Gets data from input by index.

``[Flag]`` - Gets a true value if it was passed in the input,
else false.

### Command`s option
Command options are options that are declared
as class fields or properties.

#### Example
```csharp
[Command]
public class YourClass {
    [Parameter(["n", "number"])] 
    public int Number { get; set; }
    
    [Flag(["v", "verbose"])]
    public bool Verbose { get; set; }
        
    [Argument(0)]
    public string Name { get; set; }
}
```
### Action`s option
Action options are options that are declared 
as method parameters.

#### Example
```csharp
[Command]
public class YourClass
{   
    [Action]
    public void Action(
        [Parameter(["n", "number"])] int number,
        [Flag(["v", "verbose"])] bool verbose,
        [Argument(0)] string name) {
        //CODE
    }
}
```