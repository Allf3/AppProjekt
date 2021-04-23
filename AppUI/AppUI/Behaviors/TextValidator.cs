using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppUI.Behaviors
{
    public class TextValidator : Behavior<Editor>
    {
        protected override void OnAttachedTo(Editor editor)
        {
            editor.TextChanged += OnEditorTextChanged;
            base.OnAttachedTo(editor);
        }

        protected override void OnDetachingFrom(Editor editor)
        {
            editor.TextChanged -= OnEditorTextChanged;
            base.OnDetachingFrom(editor);
        }

        private void OnEditorTextChanged(object sender, TextChangedEventArgs args)
        {
            Regex reg = new Regex("[0-9]");
            bool isValid = reg.IsMatch(args.NewTextValue);
            ((Editor)sender).TextColor = isValid ? Color.Red : Color.Default;
            ((Editor)sender).BackgroundColor = isValid ? Color.FromHex("#FBC5D0") : Color.Default;
        }
    }
}
