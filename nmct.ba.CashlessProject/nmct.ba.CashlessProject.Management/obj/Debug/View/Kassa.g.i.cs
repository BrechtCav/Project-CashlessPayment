﻿#pragma checksum "..\..\..\View\Kassa.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "94033061C1C54BEFA1C6EEBE4BA10F39"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
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
using System.Windows.Interactivity;
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
using nmct.ba.CashlessProject.Management.Converters;
using nmct.ba.CashlessProject.Management.ViewModel;


namespace nmct.ba.CashlessProject.Management.View {
    
    
    /// <summary>
    /// Kassa
    /// </summary>
    public partial class Kassa : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\View\Kassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblKassaSelecteer;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\Kassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstKassaSelecteer;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\View\Kassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKassaNaam;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\View\Kassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKassaToestel;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\View\Kassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstKassaAanmeldingen;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\Kassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblKassaNaam;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\Kassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblKassaToestel;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\Kassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblKassaAameldingen;
        
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
            System.Uri resourceLocater = new System.Uri("/nmct.ba.CashlessProject.Management;component/view/kassa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Kassa.xaml"
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
            this.lblKassaSelecteer = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lstKassaSelecteer = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.txtKassaNaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtKassaToestel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.lstKassaAanmeldingen = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.lblKassaNaam = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblKassaToestel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblKassaAameldingen = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

