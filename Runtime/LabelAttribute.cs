using System;
using UnityEngine;

namespace ToolKid {
    /// <summary>
    /// Specify a label for a field in the Inspector window.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class LabelAttribute : PropertyAttribute {
        /// <summary>
        /// The label text.
        /// </summary>
        public readonly string text;
        /// <summary>
        /// Specify a label for a field.
        /// </summary>
        /// <param name="displayName">The label text.</param>
        public LabelAttribute(string displayName) {
            text = displayName;
        }
    }
}
