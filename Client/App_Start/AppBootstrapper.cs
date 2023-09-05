namespace Client.App_Start
{
    #region Usings
    using Caliburn.Micro;
    using Client.Managers;
    using Contracts;
    using System.Collections.Generic;
    using System.Windows;
    using System;
    using Castle.Windsor;
    using System.Linq;
    #endregion

    #region AppBootstrapper
    internal class AppBootstrapper : BootstrapperBase
    {
        #region Private : Fields
        private readonly IWindsorContainer _container;
        #endregion

        #region Public : Constructor
        public AppBootstrapper()
        {
            _container = ContainerManager.Container!;
            Initialize();
        }
        #endregion

        #region Protected : Methods 
        protected override object GetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return _container.Resolve(serviceType);
            }
            return _container.Resolve(key, serviceType);
        }
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            var mainWindow = GetInstance(typeof(IMainWindow), string.Empty) as IMainWindow;
            mainWindow?.ShowDialog();
        }
        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
        }
        #endregion
    }
    #endregion
}