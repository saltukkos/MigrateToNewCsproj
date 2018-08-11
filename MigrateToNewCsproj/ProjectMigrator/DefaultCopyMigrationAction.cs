using System.Xml.Linq;
using JetBrains.Annotations;
using MigrationItems;
using Saltuk.Utils.Validation;

namespace ProjectMigrator
{
    public class DefaultCopyMigrationAction : IMigrationAction
    {
        [NotNull]
        private readonly XElement _originalElement;

        public DefaultCopyMigrationAction([NotNull] XElement originalElement)
        {
            ThrowIf.Argument.IsNull(originalElement, nameof(originalElement));
            _originalElement = originalElement;
        }

        public Confidence Confidence => Confidence.SafeAssumption;
        
        public UserInputRequest RequiredUserInput { get; } = new UserInputRequest();
        
        public XElement GetElement(UserInput userInput)
        {
            return _originalElement;
        }
    }
}