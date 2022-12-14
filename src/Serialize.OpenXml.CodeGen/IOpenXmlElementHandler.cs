/* MIT License

Copyright (c) 2020 Ryan Boggs

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the "Software"), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify,
merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be included in all copies
or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
*/

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using DocumentFormat.OpenXml;

namespace Serialize.OpenXml.CodeGen
{
    /// <summary>
    /// Defines objects that provide custom code generation instructions for
    /// <see cref="OpenXmlElement"/> derived objects that the process may
    /// encounter.
    /// </summary>
    public interface IOpenXmlElementHandler : IOpenXmlHandler
    {
        #region Methods

        /// <summary>
        /// Builds custom code objects that would build the contents of
        /// <paramref name="element"/>.
        /// </summary>
        /// <param name="element">
        /// The <see cref="OpenXmlElement"/> object to codify.
        /// </param>
        /// <param name="settings">
        /// The <see cref="ISerializeSettings"/> to use during the code generation
        /// process.
        /// </param>
        /// <param name="types">
        /// A lookup <see cref="KeyedCollection{TKey, TItem}"/> containing the
        /// available <see cref="TypeMonitor"/> elements to use for variable naming
        /// purposes.
        /// </param>
        /// <param name="namespaces">
        /// Collection <see cref="IDictionary{TKey, TValue}"/> used to keep track of all
        /// openxml namespaces used during the process.
        /// </param>
        /// <param name="token">
        /// Task cancellation token from the parent method.
        /// </param>
        /// <param name="elementName">
        /// The variable name of the root <see cref="OpenXmlElement"/> object that was built
        /// from the <paramref name="element"/>.
        /// </param>
        /// <returns>
        /// A collection of code statements and expressions that could be used to generate
        /// a new <paramref name="element"/> object from code.
        /// </returns>
        /// <remarks>
        /// If this method returns <see langword="null"/>, the default implementation will
        /// be used instead.
        /// </remarks>
        CodeStatementCollection BuildCodeStatements(
            OpenXmlElement element,
            ISerializeSettings settings,
            KeyedCollection<Type, TypeMonitor> types,
            IDictionary<string, string> namespaces,
            CancellationToken token,
            out string elementName);

        #endregion
    }
}