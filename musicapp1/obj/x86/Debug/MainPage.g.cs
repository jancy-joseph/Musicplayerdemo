﻿#pragma checksum "C:\Users\jancy\source\repos\musicapp1\musicapp1\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "74094E0AC0F7AA182F23F6BDF402FCBF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace musicapp1
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 15
                {
                    this.Pause = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Pause).Click += this.Pause_Click;
                }
                break;
            case 3: // MainPage.xaml line 16
                {
                    this.ChoosePlaylist1 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ChoosePlaylist1).SelectionChanged += this.ChoosePlaylist1_SelectionChanged;
                }
                break;
            case 4: // MainPage.xaml line 18
                {
                    this.ChoosePlaylistButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ChoosePlaylistButton).Click += this.ChoosePlaylistButton_Click;
                }
                break;
            case 5: // MainPage.xaml line 19
                {
                    this.ChoosePlaylist2 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 6: // MainPage.xaml line 20
                {
                    this.CreatePlaylist = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.CreatePlaylist).Click += this.CreatePLaylist_Button_Click;
                }
                break;
            case 7: // MainPage.xaml line 21
                {
                    this.txtPlaylistName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

