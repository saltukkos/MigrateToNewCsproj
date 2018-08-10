using System.Collections.Generic;
using JetBrains.Annotations;
using MigrationItems;
using Saltuk.Utils.Validation;

namespace ProjectMigrator
{
    public class ItemMigratorsStore
    {
        public ItemMigratorsStore([ItemNotNull] [NotNull] IReadOnlyCollection<IItemMigrator> itemMigrators)
        {
            ThrowIf.Argument.IsNull(itemMigrators, nameof(itemMigrators));

            var roorNode = new ItemMigratorsStoreNode();
            foreach (var itemMigrator in itemMigrators.WithNullChecking())
            {
                roorNode.AddItemMigrator(itemMigrator);
            }

            RootNode = roorNode;
        }

        public IItemMigratorsStoreNode RootNode { get; }
    }
}