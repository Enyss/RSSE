using System;
using System.Windows;

namespace RSSE
{
    /// <summary>
    /// Drop target with a strongly typed payload
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DropTarget<T> : IDropTarget
    {
        private readonly Func<T, DragDropEffects> _getEffects;
        private readonly Action<T> _drop;

        /// <summary>
        /// Initializes a new instance of the <see cref="DropTarget&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="getEffects">The method to be used to get allowed drop effects.</param>
        /// <param name="drop">The method invoked when a payload is dropped on the target.</param>
        public DropTarget(Func<T, DragDropEffects> getEffects, Action<T> drop)
        {
            #region Argument checks
            if (getEffects == null) 
                throw new ArgumentNullException("getEffects");
            
            if (drop == null) 
                throw new ArgumentNullException("drop");
            #endregion

            _getEffects = getEffects;
            _drop = drop;
        }

        /// <summary>
        /// Gets the effects.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <returns></returns>
        public DragDropEffects GetDropEffects(IDataObject dataObject)
        {
            if ( !dataObject.GetDataPresent(typeof(T)))
                return DragDropEffects.None;

            return _getEffects((T) dataObject.GetData(typeof(T)));
        }

        /// <summary>
        /// Drops the specified data object
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        public void Drop(IDataObject dataObject)
        {
            _drop((T) dataObject.GetData(typeof (T)));
        }
    }
}
