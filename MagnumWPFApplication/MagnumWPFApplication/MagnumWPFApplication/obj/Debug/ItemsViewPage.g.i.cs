﻿#pragma checksum "..\..\ItemsViewPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51F52F85465ED398AC65E500812EC08A580DD118517692F188D50908393C38CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ActioRusApp;
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


namespace ActioRusApp {
    
    
    /// <summary>
    /// ItemsViewPage
    /// </summary>
    public partial class ItemsViewPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\ItemsViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchList;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ItemsViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox JenresList;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ItemsViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetFilters;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\ItemsViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Cart;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ItemsViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CarsViewPanel;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\ItemsViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ClientDataPAnel;
        
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
            System.Uri resourceLocater = new System.Uri("/ActioRusApp;component/itemsviewpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ItemsViewPage.xaml"
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
            this.SearchList = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\ItemsViewPage.xaml"
            this.SearchList.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchList_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.JenresList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\ItemsViewPage.xaml"
            this.JenresList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MarksList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ResetFilters = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\ItemsViewPage.xaml"
            this.ResetFilters.Click += new System.Windows.RoutedEventHandler(this.ResetFilters_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Cart = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 43 "..\..\ItemsViewPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CarsViewPanel = ((System.Windows.Controls.ListView)(target));
            
            #line 46 "..\..\ItemsViewPage.xaml"
            this.CarsViewPanel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CarsViewPanel_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ClientDataPAnel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

