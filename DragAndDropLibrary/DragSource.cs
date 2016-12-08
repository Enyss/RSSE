﻿using System;
using System.Windows;

namespace RSSE
{
    /// <summary>
    /// Drag source implementation with strongly typed payload
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DragSource<T> : IDragSource
    {
        private readonly Func<T, DragDropEffects> _getSupportedEffects;
        private readonly Func<T, object> _getData;

        /// <summary>
        /// Initializes a new instance of the <see cref="DragSource&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="getSupportedEffects">The get supported effects.</param>
        /// <param name="getData">The get data.</param>
        public DragSource(Func<T, DragDropEffects> getSupportedEffects, Func<T, object> getData)
        {
            #region Argument checks
            if (getSupportedEffects == null) 
                throw new ArgumentNullException("getSupportedEffects");
            
            if (getData == null) 
                throw new ArgumentNullException("getData");
            #endregion

            _getSupportedEffects = getSupportedEffects;
            _getData = getData;
        }

        /// <summary>
        /// Gets the supported drop effects.
        /// </summary>
        /// <param name="dataContext">The data context of the element initiating the drag oparation.</param>
        /// <returns></returns>
        public DragDropEffects GetDragEffects(object dataContext)
        {
            return _getSupportedEffects((T) dataContext);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="dataContext">The data context of the element initiating the drag operation.</param>
        /// <returns></returns>
        public object GetData(object dataContext)
        {
            return _getData((T) dataContext);
        }
    }
}
