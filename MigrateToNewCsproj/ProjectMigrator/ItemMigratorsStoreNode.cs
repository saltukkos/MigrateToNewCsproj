using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MigrationItems;
using Saltuk.Utils.Validation;

namespace ProjectMigrator
{
    public class ItemMigratorsStoreNode : IItemMigratorsStoreNode
    {
        [CanBeNull]
        private IItemMigrator _itemMigrator;

        public IItemMigrator ItemMigrator
        {
            [CanBeNull]
            get { return _itemMigrator; }

            [NotNull]
            private set
            {
                if (_itemMigrator != null)
                {
                    throw new InvalidOperationException($"{_itemMigrator}'s path is equal to {value}'s path");
                }

                if (_children.Count != 0)
                {
                    throw new InvalidOperationException($"{value} hides other resolvers");
                }

                _itemMigrator = value;
            }
        }

        [NotNull]
        private readonly Dictionary<string, ItemMigratorsStoreNode> _children =
            new Dictionary<string, ItemMigratorsStoreNode>();

        private void AddItemMigrator([NotNull] IItemMigrator itemMigrator, int depthLevel)
        {
            if (depthLevel == itemMigrator.SupportedItemPath.Count)
            {
                ItemMigrator = itemMigrator;
                return;
            }

            if (ItemMigrator != null)
            {
                throw new InvalidOperationException($"{ItemMigrator} hides {itemMigrator}");
            }

            var itemName = itemMigrator.SupportedItemPath[depthLevel];
            if (!_children.TryGetValue(itemName, out var child))
            {
                child = new ItemMigratorsStoreNode();
                _children.Add(itemName, child);
            }

            child.AddItemMigrator(itemMigrator, depthLevel + 1);
        }

        public void AddItemMigrator([NotNull] IItemMigrator itemMigrator)
        {
            ThrowIf.Argument.IsNull(itemMigrator, nameof(itemMigrator));
            AddItemMigrator(itemMigrator, 0);
        }

        public IItemMigratorsStoreNode TryGetChildrenNode(string name)
        {
            ThrowIf.Argument.IsNull(name, nameof(name));

            _children.TryGetValue(name, out var child);
            return child;
        }
    }
}