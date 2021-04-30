using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MovieLibrary.UI.Common
{
    public class MainDataTemplateSelector : System.Windows.Controls.DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null || Application.Current == null)
            {
                return null;
            }

            string name = item.GetType().Name.Replace("ViewModel", "View");
            var template = (DataTemplate)Application.Current.TryFindResource(name);

            if (template == null)
            {
                throw new ArgumentException(name + " is not found");
            }

            return template;
        }
    }
}
