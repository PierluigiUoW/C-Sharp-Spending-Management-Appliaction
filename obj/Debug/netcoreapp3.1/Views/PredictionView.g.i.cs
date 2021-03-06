#pragma checksum "..\..\..\..\Views\PredictionView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C989BD454A6DD4D388AC648D58DD36CE830C62C2"
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
using System.Windows.Controls.Ribbon;
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
using w1640643CW2.Views;


namespace w1640643CW2.Views {
    
    
    /// <summary>
    /// PredictionView
    /// </summary>
    public partial class PredictionView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Views\PredictionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenHomeView;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\PredictionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PredictionNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\PredictionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FuturePreidictionDateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\PredictionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Views\PredictionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateNewPrediction;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\PredictionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndDateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Views\PredictionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PredictionCalulcationLabel;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\PredictionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PredictionDetailsListBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/w1640643CW2;V1.0.0.0;component/views/predictionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\PredictionView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.OpenHomeView = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Views\PredictionView.xaml"
            this.OpenHomeView.Click += new System.Windows.RoutedEventHandler(this.OpenHomeView_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PredictionNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.FuturePreidictionDateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.StartDateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.CreateNewPrediction = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Views\PredictionView.xaml"
            this.CreateNewPrediction.Click += new System.Windows.RoutedEventHandler(this.CreateNewPrediction_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EndDateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.PredictionCalulcationLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.PredictionDetailsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

