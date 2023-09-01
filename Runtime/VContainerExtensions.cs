using System;
using System.Linq;
using VContainer;
using VContainer.Unity;

namespace Runtime.DI.Core.Runtime
{
    public static class VContainerExtensions
    {
        public static RegistrationBuilder AddTransient<T>(this IContainerBuilder builder)
        {
            return IsEntry<T>()
                ? builder.RegisterEntryPoint<T>(Lifetime.Transient).AsSelf()
                : builder.Register<T>(Lifetime.Transient);
        }

        public static RegistrationBuilder AddTransient<TBase, TChild>(this IContainerBuilder builder)
            where TChild : TBase
        {
            return IsEntry<TChild>()
                ? builder.RegisterEntryPoint<TChild>(Lifetime.Transient).As<TBase>()
                : builder.Register<TChild>(Lifetime.Transient).As<TBase>();
        }

        public static RegistrationBuilder AddScoped<T>(this IContainerBuilder builder)
        {
            return IsEntry<T>()
                ? builder.RegisterEntryPoint<T>(Lifetime.Scoped).AsSelf()
                : builder.Register<T>(Lifetime.Scoped);
        }

        public static RegistrationBuilder AddScoped<TBase, TChild>(this IContainerBuilder builder) where TChild : TBase
        {
            return IsEntry<TChild>()
                ? builder.RegisterEntryPoint<TChild>(Lifetime.Scoped).AsImplementedInterfaces().As<TBase>()
                : builder.Register<TChild>(Lifetime.Scoped).As<TBase>();
        }

        public static RegistrationBuilder AddSingleton<T>(this IContainerBuilder containerBuilder)
        {
            return IsEntry<T>()
                ? containerBuilder.RegisterEntryPoint<T>(Lifetime.Singleton).AsSelf()
                : containerBuilder.Register<T>(Lifetime.Singleton);
        }

        public static RegistrationBuilder AddSingleton<TBase, TChild>(this IContainerBuilder builder) where TChild : TBase
        {
            return builder.Register<TChild>(Lifetime.Singleton).As<TBase>();
        }

        private static bool IsEntry<T>()
        {
            return typeof(T).GetInterfaces().Any(x => x == typeof(IStartable) || x == typeof(IDisposable));
        }
    }
}