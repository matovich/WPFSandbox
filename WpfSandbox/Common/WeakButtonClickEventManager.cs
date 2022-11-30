//using System;
//using System.Windows;
//using System.Windows.Controls;

//namespace WpfSandbox.Common
//{
//    /// <summary>
//    /// https://learn.microsoft.com/en-us/dotnet/desktop/wpf/events/weak-event-patterns?view=netdesktop-6.0
//    /// </summary>
//    internal class WeakButtonClickEventManager : WeakEventManager
//    {
//        private WeakButtonClickEventManager()
//        {
//        }

//        /// <summary>
//        /// Add a handler for the given source's event.
//        /// </summary>
//        public static void AddHandler(Button source,
//                                      EventHandler<ButtonClickEventArgs> handler)
//        {
//            if (source == null)
//                throw new ArgumentNullException(nameof(source));
//            if (handler == null)
//                throw new ArgumentNullException(nameof(handler));

//            CurrentManager.ProtectedAddHandler(source, handler);
//        }

//        /// <summary>
//        /// Remove a handler for the given source's event.
//        /// </summary>
//        public static void RemoveHandler(Button source,
//                                         EventHandler<WeakButtonClickEventArgs> handler)
//        {
//            if (source == null)
//                throw new ArgumentNullException(nameof(source));
//            if (handler == null)
//                throw new ArgumentNullException(nameof(handler));

//            CurrentManager.ProtectedRemoveHandler(source, handler);
//        }

//        /// <summary>
//        /// Get the event manager for the current thread.
//        /// </summary>
//        private static WeakButtonClickEventManager CurrentManager
//        {
//            get
//            {
//                Type managerType = typeof(WeakButtonClickEventManager);
//                WeakButtonClickEventManager manager =
//                    (WeakButtonClickEventManager)GetCurrentManager(managerType);

//                // at first use, create and register a new manager
//                if (manager == null)
//                {
//                    manager = new WeakButtonClickEventManager();
//                    SetCurrentManager(managerType, manager);
//                }

//                return manager;
//            }
//        }

//        /// <summary>
//        /// Return a new list to hold listeners to the event.
//        /// </summary>
//        protected override ListenerList NewListenerList()
//        {
//            return new ListenerList<WeakButtonClickEventArgs>();
//        }

//        /// <summary>
//        /// Listen to the given source for the event.
//        /// </summary>
//        protected override void StartListening(object source)
//        {
//            Button typedSource = (Button)source;
//            typedSource.WeakButtonClick += new EventHandler<WeakButtonClickEventArgs>(OnWeakButtonClick);
//        }

//        /// <summary>
//        /// Stop listening to the given source for the event.
//        /// </summary>
//        protected override void StopListening(object source)
//        {
//            Button typedSource = (Button)source;
//            typedSource.WeakButtonClick -= new EventHandler<WeakButtonClickEventArgs>(OnWeakButtonClick);
//        }

//        /// <summary>
//        /// Event handler for the WeakButtonClick event.
//        /// </summary>
//        void OnWeakButtonClick(object sender, WeakButtonClickEventArgs e)
//        {
//            DeliverEvent(sender, e);
//        }
//    }
//}
