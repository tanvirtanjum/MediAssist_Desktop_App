#pragma checksum "..\..\..\..\Views\Doctor\DoctorDash.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DD6892A5B9B59F597B0C9189759B319AA9600868BDCAD152966EA0224A7D0872"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MediAssist_Desktop_App.Views.Doctor;
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


namespace MediAssist_Desktop_App.Views.Doctor {
    
    
    /// <summary>
    /// DoctorDash
    /// </summary>
    public partial class DoctorDash : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutBtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProfileBtn;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NoteBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AppointmentBtn;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReportBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/MediAssist_Desktop_App;component/views/doctor/doctordash.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
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
            this.logoutBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
            this.logoutBtn.Click += new System.Windows.RoutedEventHandler(this.logoutBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HomeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
            this.HomeBtn.Click += new System.Windows.RoutedEventHandler(this.HomeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ProfileBtn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
            this.ProfileBtn.Click += new System.Windows.RoutedEventHandler(this.ProfileBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NoteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
            this.NoteBtn.Click += new System.Windows.RoutedEventHandler(this.NoteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AppointmentBtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
            this.AppointmentBtn.Click += new System.Windows.RoutedEventHandler(this.AppointmentBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ReportBtn = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Views\Doctor\DoctorDash.xaml"
            this.ReportBtn.Click += new System.Windows.RoutedEventHandler(this.ReportBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

