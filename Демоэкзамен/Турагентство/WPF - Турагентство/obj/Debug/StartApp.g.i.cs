#pragma checksum "..\..\StartApp.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6242636DAC32C61E3F9D4F9DF953EAA237EAB791765EF1D224438E38822E4200"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPF___Турагентство;


namespace WPF___Турагентство {
    
    
    /// <summary>
    /// StartApp
    /// </summary>
    public partial class StartApp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\StartApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonHotel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\StartApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonEditing;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\StartApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\StartApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF - Турагентство;component/startapp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StartApp.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.buttonHotel = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\StartApp.xaml"
            this.buttonHotel.Click += new System.Windows.RoutedEventHandler(this.buttonHotel_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonEditing = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\StartApp.xaml"
            this.buttonEditing.Click += new System.Windows.RoutedEventHandler(this.buttonEditing_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\StartApp.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.buttonBack_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            
            #line 25 "..\..\StartApp.xaml"
            this.MainFrame.ContentRendered += new System.EventHandler(this.framePages_Back);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
