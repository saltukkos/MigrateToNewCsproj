using System.Xml.Linq;
using JetBrains.Annotations;

namespace MigrationItems
{
    public interface IMigrationAction
    {
        Confidence Confidence { get; }

        [NotNull]
        UserInputRequest RequiredUserInput { get; } 

        [NotNull]
        XElement GetElement([NotNull] UserInput userInput);
    }
}