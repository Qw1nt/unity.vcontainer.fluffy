using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Qw1nt.VContainer.Fluffy.Runtime
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
            var objects = Object.FindObjectsOfType<AutoInject>(true)
                .Select(x => x.gameObject).ToList();
            autoInjectGameObjects = objects;
        }
    }
}