using SimpleLineLibrary.Models;
using SimpleLineLibrary.Utils;

namespace SimpleLineLibrary.Services.InfoReading
{
    internal class InfoReader
    {   
        public string GetInfo(Command command)
        {
            var mb = new MessageBuilder();
            
            var orderedBlocks = command.GetHelpBlocks()
                .OrderBy(x => x.Order);
            foreach(var b in orderedBlocks)
            {
                mb
                .StartBlock(b.Header + ":")
                    .WriteLine(b.Body)
                .CloseBlock();
            }

            return mb.ToString();
        }
    }
}
