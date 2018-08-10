using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MigrationItems;
using Saltuk.Utils.Validation;

namespace ProjectMigrator
{
    public class ProjectMigrator
    {
        [NotNull]
        [ItemNotNull]
        private readonly IReadOnlyList<IItemMigrator> _itemMigrators;

        public ProjectMigrator([NotNull] Project project, [ItemNotNull] [NotNull] IReadOnlyCollection<IItemMigrator> itemMigrators)
        {
            ThrowIf.Argument.IsNull(itemMigrators, nameof(itemMigrators));
            ThrowIf.Argument.IsNull(project, nameof(project));

            _itemMigrators = itemMigrators.WithNullChecking().ToList();
        }
    }
}