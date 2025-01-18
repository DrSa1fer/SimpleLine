using Microsoft.Extensions.DependencyInjection;

namespace simpleline;

public class SimpleLineBuilder {
    public IServiceCollection Services { get; } = new ServiceCollection();
    
    public ICollection<string> HelpAliases { get; } = new List<string>();
    public ICollection<string> VersionAliases { get; } = new List<string>();
    
    
    
    public SimpleLine Build() {
        return new SimpleLine();
    }
}