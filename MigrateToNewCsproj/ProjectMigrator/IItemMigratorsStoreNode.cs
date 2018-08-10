using JetBrains.Annotations;
using MigrationItems;

namespace ProjectMigrator
{
    public interface IItemMigratorsStoreNode
    {
        [CanBeNull]
        IItemMigrator ItemMigrator { get; }

        [CanBeNull]
        IItemMigratorsStoreNode TryGetChildrenNode([NotNull] string name);
    }
}