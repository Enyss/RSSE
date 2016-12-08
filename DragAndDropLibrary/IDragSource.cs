using System.Windows;

namespace RSSE
{
    /// <summary>
    /// Business end of the drag source
    /// </summary>
    public interface IDragSource
    {
        /// <summary>
        /// Gets the supported drop effects.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <returns></returns>
        DragDropEffects GetDragEffects(object dataContext);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <returns></returns>
        object GetData(object dataContext);
    }
}