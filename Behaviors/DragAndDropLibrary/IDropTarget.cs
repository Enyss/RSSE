/****************************************************************************/
/*                                                                          */
/*  Drag & drop library from                                                */
/*  https://bitbucket.org/mkaluza/sharpfellows.toolkit                      */
/*       Thanks for such a clean use !                                      */
/*                                                                          */
/****************************************************************************/


using System.Windows;

namespace RSSE
{
    public interface IDropTarget
    {
        /// <summary>
        /// Gets the effects.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <returns></returns>
        DragDropEffects GetDropEffects(IDataObject dataObject);

        /// <summary>
        /// Drops the specified data object
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        void Drop(IDataObject dataObject);
    }
}