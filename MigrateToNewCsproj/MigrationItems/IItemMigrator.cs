using System.Collections.Generic;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace MigrationItems
{
    public interface IItemMigrator
    {
        [NotNull]
        [ItemNotNull]
        IReadOnlyList<string> SupportedItemPath { get; }

        [NotNull]
        [ItemNotNull]
        IReadOnlyCollection<IMigrationAction> GetPossibleMigrations([NotNull] XElement element);
    }
}