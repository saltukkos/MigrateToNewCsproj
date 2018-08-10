using System.Xml.Linq;
using JetBrains.Annotations;
using Saltuk.Utils.Validation;

namespace ProjectMigrator
{
    public class Project
    {
        public Project([NotNull] XDocument document)
        {
            ThrowIf.Argument.IsNull(document, nameof(document));
            Document = document;
        }

        [NotNull]
        public XDocument Document { get; }
    }
}