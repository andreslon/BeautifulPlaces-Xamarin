using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Satrack.SpecialTransport.Cross.Controls
{
    public class ExtendedButton : Button
    {
        public static readonly BindableProperty PaddingProperty =
            BindableProperty.Create<ExtendedButton, Thickness>(o => o.Padding, default(Thickness));

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
    }
}
