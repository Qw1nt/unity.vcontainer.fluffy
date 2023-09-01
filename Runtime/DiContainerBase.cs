using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SnailBee.VContainer.LiteTemplate
{
    public abstract class DiContainerBase : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            FindAutoInjectObject();
            AddDependencies(builder);
        }

        protected abstract void AddDependencies(IContainerBuilder builder);

        private void FindAutoInjectObject()
        {
            var objects = FindObjectsByType<AutoInject>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .Select(x => x.gameObject).ToList();
            autoInjectGameObjects = objects;
        }
    }
}