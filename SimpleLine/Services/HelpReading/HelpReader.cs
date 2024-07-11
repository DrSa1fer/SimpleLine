using SimpleLineLibrary.Models;
using System.Text;

namespace SimpleLineLibrary.Services.HelpReading
{
    internal class HelpReader
    {
        public string GetHelp(IEnumerable<HelpBlock> blocks)
        {
            var sb = new StringBuilder();
            var offset = "    ";

            var ordered = blocks.OrderBy(x => x.Order);

            foreach (var block in ordered)
            {
                sb.AppendLine(block.Header + ":");

                if (block.Body.Any())
                {
                    foreach (var line in block.Body)
                    {
                        sb.AppendLine(offset + line);
                    }
                }
                else
                {
                    sb.AppendLine(offset + "Nothing");
                }
            }

            return sb.ToString();
        }
    }
}
