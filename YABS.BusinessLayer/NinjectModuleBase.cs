using System;
using System.Linq;
using JetBrains.Annotations;
using Ninject.Modules;


namespace YABS.BusinessLayer {
    public abstract class NinjectModuleBase : NinjectModule {

        /// <summary>
        /// Types of other <see cref="NinjectModule"/>s, that is required to be loaded for using this module.
        /// </summary>
        [NotNull]
        protected abstract Type[] DependsOnModules { get; }


        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        /// <exception cref="InvalidOperationException">The some of <see cref="DependsOnModules"/> is not loaded.</exception>
        public sealed override void Load() {
            var missingModules = DependsOnModules.Where(x => Kernel?.HasModule(x.FullName) != true).ToList();
            if (missingModules.Any())
                throw new InvalidOperationException($"Ninject module {GetType().FullName} requires following modules: {string.Join(", ", missingModules.Select(x => x.FullName))}");

            LoadConfiguration();
        }

        /// <summary>
        /// Actually loads module into the kernel.
        /// </summary>
        protected abstract void LoadConfiguration();
    }
}