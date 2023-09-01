using System;
using VContainer;
using VContainer.Unity;

namespace Runtime.DI.Core
{
    public static class VContainerExtensions
    {
        public static RegistrationBuilder AddScoped<T>(this IContainerBuilder containerBuilder)
        {
            if(typeof(T) is IStartable || typeof(T) is IDisposable)
                return containerBuilder.Register<T>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
            
            return containerBuilder.Register<T>(Lifetime.Scoped);
        }

        public static RegistrationBuilder AddScoped<TBase, TChild>(this IContainerBuilder containerBuilder)
            where TChild : TBase
        {
            return containerBuilder.Register<TChild>(Lifetime.Scoped).As<TBase>();
        }

        public static RegistrationBuilder AddSingleton<T>(this IContainerBuilder containerBuilder)
        {
            return containerBuilder.Register<T>(Lifetime.Singleton);
        }

        public static RegistrationBuilder AddSingleton<TBase, TChild>(this IContainerBuilder builder)
            where TChild : TBase
        {
            return builder.Register<TChild>(Lifetime.Singleton).As<TBase>();
        }

        public static RegistrationBuilder AddTransient<T>(this IContainerBuilder containerBuilder)
        {
            return containerBuilder.Register<T>(Lifetime.Transient);
        }

        public static RegistrationBuilder AddTransient<TBase, TChild>(this IContainerBuilder containerBuilder)
            where TChild : TBase
        {
            return containerBuilder.Register<TChild>(Lifetime.Transient).As<TBase>();
        }
    }
}