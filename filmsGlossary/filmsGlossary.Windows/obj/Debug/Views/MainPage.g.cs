﻿

#pragma checksum "C:\Users\james\OneDrive\Coding\Projects\filmGlossary\filmsGlossary\filmsGlossary\filmsGlossary.Windows\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "35E2BCB27CE143F04C6F86795786F0E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace filmsGlossary
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 18 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.textGotFocus;
                 #line default
                 #line hidden
                #line 18 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.checkEnter;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 19 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.onSearchSubmit;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 21 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.termButtonClicked;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 22 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.termButtonClicked;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


