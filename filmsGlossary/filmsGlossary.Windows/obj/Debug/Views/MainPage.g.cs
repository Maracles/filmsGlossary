﻿

#pragma checksum "C:\Github\filmsGlossary\filmsGlossary\filmsGlossary.Windows\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6C61DF7D6F86B949EB048C478C5102BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilmsGlossary
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
                #line 30 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.termClicked;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 22 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.SearchboxGotFocus;
                 #line default
                 #line hidden
                #line 22 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.OnSearchKeyPressDown;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 23 "..\..\Views\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SubmitSearch;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


