using System.Xml.Linq;
using MigrationItems;

namespace ProjectMigrator
{
    public class DefaultDeleteMigrationAction : IMigrationAction
    {
        public Confidence Confidence => Confidence.DangerAssumption;
        
        public UserInputRequest RequiredUserInput { get; } = new UserInputRequest();

        public XElement GetElement(UserInput userInput)
        {
            return null;
        }
    }
}