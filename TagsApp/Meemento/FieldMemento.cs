using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Fabric_Method.Products;

namespace TagsApp
{
    public class FieldMemento:IMemento
    {
        //private readonly Tag[,] _tags;
        private readonly Field _activeField;
        private readonly Field _savedField;
        
        public FieldMemento(Field activeField, Field fieldToSave)
        {
            _activeField = activeField;
            _savedField = fieldToSave;
        }

        public void Restore()
        {
            _activeField.Length = _savedField.Length;
            _activeField.Width = _savedField.Width;
            _activeField.Tags = _savedField.Tags;
        }
    }
}
